using Database;
using Database.Lib;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;

using Common.DTO.SeaExport;
using Database.Models.Cargo;
using SeaExport.Interfaces;
using System.Threading.Tasks.Dataflow;
using System.Numerics;
using SeaExport.Printing;
using Report.Interfaces;
using Common.DTO.Report;
using Report.Printing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

//Name : Sourav V
//Created Date : 26/05/2026
//Remark : this file defines functions getList and getRecords of operations for Pending A/R list


namespace Report.Repositories
{
    public class PendingARRepository : IPendingARRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public PendingARRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var action = data["action"].ToString()!.ToUpper();
                if (action == null)
                    action = "SEARCH";
                bool isPrint = false;
                var title = data["title"].ToString();
                var user_name = data["global_user_name"].ToString();

                var mbl_bltype = "";
                var mbl_mode = "";
                var mbl_pending_status = "";
                var mbl_handled_name = "";

                var company_id = 0;
                var branch_id = 0;

                if (data.ContainsKey("mbl_bltype"))
                    mbl_bltype = data["mbl_bltype"].ToString();
                if (data.ContainsKey("mbl_mode"))
                    mbl_mode = data["mbl_mode"].ToString();
                if (data.ContainsKey("mbl_handled_name"))
                    mbl_handled_name = data["mbl_handled_name"].ToString();
                if (data.ContainsKey("mbl_pending_status"))
                    mbl_pending_status = data["mbl_pending_status"].ToString();

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
                    {"mbl_mode", mbl_mode!},
                    {"mbl_handled_name", mbl_handled_name!},
                    {"mbl_bltype", mbl_bltype!},
                    {"mbl_pending_status", mbl_pending_status!},
                };

                IQueryable<cargo_masterm> query = context.cargo_masterm;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.mbl_inc_total == 0);

                if (!Lib.IsBlank(mbl_pending_status))
                {
                    query = query.Where(w => w.mbl_pending_status == mbl_pending_status);
                }
                if (!Lib.IsBlank(mbl_handled_name))
                {
                    query = query.Where(w => w.handledby!.param_name == mbl_handled_name);
                }
                if (!Lib.IsBlank(mbl_mode))
                {
                    if (mbl_mode == "ALL")
                    {
                        var Types = new[] { "SEA IMPORT", "SEA EXPORT", "AIR IMPORT", "AIR EXPORT", "OTHERS" };
                        query = query.Where(w => Types.Contains(w.mbl_mode));
                    }
                    else
                    {
                        query = query.Where(w => w.mbl_mode == mbl_mode);
                    }
                }

                query = query.OrderBy(o => o.mbl_refno);

                var data_ =
                from m in query
                join h in context.cargo_housem
                    on m.mbl_id equals h.hbl_mbl_id into houseGroup
                from h in houseGroup.DefaultIfEmpty()
                where mbl_bltype == "ALL" || (h != null && h.hbl_bltype == mbl_bltype)
                orderby m.mbl_refno
                select new rep_pendingar_dto
                {
                    mbl_id = m.mbl_id,
                    mbl_refno = m.mbl_refno,
                    mbl_ref_date = Lib.FormatDate(m.mbl_ref_date, Lib.outputDateFormat),
                    mbl_mode = m.mbl_mode,
                    mbl_no = m.mbl_no,
                    mbl_houseno = h.hbl_houseno,
                    mbl_hbl_id = h.hbl_id,

                    mbl_bltype = h.hbl_bltype,
                    mbl_pod_eta = Lib.FormatDate(m.mbl_pod_eta, Lib.outputDateFormat),
                    mbl_handled_name = h.handledby!.param_name,
                    mbl_remarks = $"NO AR ISSUED AFTER {DateOnly.FromDateTime(DbLib.GetDateTime()).DayNumber - m.mbl_pod_eta!.Value.DayNumber } DAYS",
                    mbl_pending_status = m.mbl_pending_status == "Y" ? "HIDE THIS RECORD" : "SHOW THIS RECORD",
                    

                    rec_created_by = h != null ? h.rec_created_by : m.rec_created_by,
                    rec_created_date = h != null ? Lib.FormatDate(h.rec_created_date, Lib.outputDateTimeFormat) : Lib.FormatDate(m.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = h != null ? h.rec_edited_by : m.rec_edited_by,
                    rec_edited_date = h != null ? Lib.FormatDate(h.rec_edited_date, Lib.outputDateTimeFormat) : Lib.FormatDate(m.rec_edited_date, Lib.outputDateTimeFormat),
                };
                // data = data.Where(mbl_bltype != "ALL" || h.hbl_bltype == mbl_bltype) 

                var Records = await data_.ToListAsync();

                if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                {
                    _page.rows = Records.Count(); // add 1 for total count if needed
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


                if (action == "PDF" || action == "PRINT")
                {
                    var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                    fileDataList.Add(pdfResult);
                }
                if (action == "EXCEL" || action == "PRINT")
                {
                    var excelResult = ProcessExcelFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                    fileDataList.Add(excelResult);
                }
                RetData.Add("records", Records);
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
        public async Task<Dictionary<string, object>> HideRecordAsync(int id)
        {
            try
            {

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_masterm
                    .Where(f => f.mbl_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                if (_Record!.mbl_pending_status == "Y")
                {
                    _Record.mbl_pending_status = "N";
                }
                else if (_Record.mbl_pending_status == "N" || _Record.mbl_pending_status == null)
                {
                    _Record.mbl_pending_status = "Y";
                }
                context.SaveChanges();

                RetData.Add("status", true);
                RetData.Add("message", "");
                return RetData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public filesm ProcessPdfFileAsync(List<rep_pendingar_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Not Found");

            PendingARPdfFile bc = new PendingARPdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = "Pending A/R List",
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
                HandledBy = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
                BLType = searchInfo.ContainsKey("mbl_bltype") ? searchInfo["mbl_bltype"] : "",
                HiddenRec = searchInfo.ContainsKey("mbl_pending_status") ? searchInfo["mbl_pending_status"] : "",
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
        public filesm ProcessExcelFileAsync(List<rep_pendingar_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            PendingARExcelFile bc = new PendingARExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = "Pending A/R List",
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
                HandledBy = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
                BLType = searchInfo.ContainsKey("mbl_bltype") ? searchInfo["mbl_bltype"] : "",
                HiddenRec = searchInfo.ContainsKey("mbl_pending_status") ? searchInfo["mbl_pending_status"] : "",
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