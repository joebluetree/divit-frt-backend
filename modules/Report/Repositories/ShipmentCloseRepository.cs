using Database;
using Database.Lib;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;

using Database.Models.Cargo;
using System.Threading.Tasks.Dataflow;
using System.Numerics;
using Report.Interfaces;
using Common.DTO.Report;
using System.ComponentModel.DataAnnotations;
using Common.DTO.Email;
using Database.Models.Email;
using Report.Printing;

//Name : Sourav V
//Created Date : 19/05/2026
//Remark : this file defines functions getList of operations for Shipment Closing report


namespace Report.Repositories
{
    public class ShipmentCloseRepository : IShipmentCloseRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public ShipmentCloseRepository(AppDbContext _context, IAuditLog _auditLog)
        {
            this.context = _context;
            this.auditLog = _auditLog;
        }

        public async Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();

                Page _page = new Page();

                var action = data["action"].ToString();
                if (action == null)
                    action = "search";
                bool isPrint = false;
                var title = data["title"].ToString();
                var user_name = data["global_user_name"].ToString();

                var mbl_from_date = "";
                var mbl_to_date = "";
                var mbl_mode = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("mbl_from_date"))
                    mbl_from_date = data["mbl_from_date"].ToString();
                if (data.ContainsKey("mbl_to_date"))
                    mbl_to_date = data["mbl_to_date"].ToString();
                if (data.ContainsKey("mbl_mode"))
                    mbl_mode = data["mbl_mode"].ToString();

                company_id = Lib.GetValidIntValue(data!, "rec_company_id", "Company Id Not Found");
                branch_id = Lib.GetValidIntValue(data!, "rec_branch_id", "Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);
                if (action == "PRINT" || action == "EXCEL" || action == "PDF")
                {
                    isPrint = true;
                }

                var fileDataList = new List<filesm>();
                var searchInfo = new Dictionary<string, string>
                {
                    {"mbl_from_date",mbl_from_date!},
                    {"mbl_to_date",mbl_to_date!},
                    {"mbl_mode", mbl_mode!},
                };


                IQueryable<cargo_housem> query = context.cargo_housem
                    .Include(h => h.master);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);

                if (!Lib.IsBlank(mbl_from_date))
                {
                    from_date = Lib.ParseDateOnly(mbl_from_date!);
                    query = query.Where(w => w.master!.mbl_ref_date >= from_date);
                }
                if (!Lib.IsBlank(mbl_to_date))
                {
                    to_date = Lib.ParseDateOnly(mbl_to_date!);
                    query = query.Where(w => w.master!.mbl_ref_date <= to_date);
                }
                if (!Lib.IsBlank(mbl_mode))
                {
                    query = query.Where(w => w.master!.mbl_mode == mbl_mode);
                }

                query = query.OrderBy(o => o.master!.mbl_refno);

                var Records = await query.Select(e => new rep_shipmentclose_dto
                {
                    mbl_id = e.master!.mbl_id,
                    mbl_hbl_id = e.hbl_id,
                    mbl_refno = e.master!.mbl_refno,
                    mbl_ref_date = Lib.FormatDate(e.master.mbl_ref_date, Lib.outputDateFormat),
                    mbl_mode = e.master.mbl_mode,

                    mbl_bl_req = e.hbl_bl_req,
                    mbl_cntr_type = e.master.mbl_cntr_type,
                    hbl_empty_ret_date = Lib.FormatDate(e.hbl_empty_ret_date, Lib.outputDateFormat),
                    hbl_pickup_date = Lib.FormatDate(e.hbl_pickup_date, Lib.outputDateFormat),

                    mbl_profit_req = e.master.mbl_profit_req == "Y" ? "YES":"NO",
                    mbl_loss_approved = e.master.mbl_loss_approved == "Y" ? "YES":"NO",
                    mbl_loss_memo = e.master.mbl_loss_memo,
                    mbl_revenue = e.master.mbl_revenue,

                    rec_locked = e.rec_locked == "Y" ? "YES":"NO",
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();
                // Records.AddRange(HRecords);

                if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                {
                    _page.rows = Records.Count();
                    _page.pages = Lib.getTotalPages(_page.rows, _page.pageSize);
                    _page.currentPageNo = 1;
                }
                else
                {
                    _page.currentPageNo = Lib.FindPage(action, _page.currentPageNo, _page.pages);
                }
                if (!isPrint)
                {
                    int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                    Records = Records.Skip(StartRow).Take(_page.pageSize).ToList();
                }

                RetData.Add("records", Records);

                if (action == "PDF" || action == "PRINT")
                {
                    var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo );
                    fileDataList.Add(pdfResult);
                }
                if (action == "EXCEL" || action == "PRINT")
                {
                    var excelResult = ProcessExcelFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo );
                    fileDataList.Add(excelResult);
                }

                RetData.Add("fileData", fileDataList);
                RetData.Add("action", action);
                RetData.Add("page", _page);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public filesm ProcessPdfFileAsync(List<rep_shipmentclose_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Not Found");

            ShipmentClosePdfFile bc = new ShipmentClosePdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
                ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
            };
            bc.Process();
            if (bc.FList == null || !bc.FList.Any())
                throw new Exception("File generation failed.");

            var file = bc.FList[0];

            var record = new filesm
            {
                filepath = file.filename!,
                filename = file.filedisplayname!,
                filetype = file.filetype!
            };

            return record;
        }
        public filesm ProcessExcelFileAsync(List<rep_shipmentclose_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            ShipmentCloseExcelFile bc = new ShipmentCloseExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
                ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
            };
            bc.Process();

            if (bc.fList == null || !bc.fList.Any())
                throw new Exception("Excel generation failed.");

            var file = bc.fList[0];

            var record = new filesm
            {
                filepath = file.filename!,
                filename = file.filedisplayname!,
                filetype = file.filetype!
            };

            return record;
        }
    }
}