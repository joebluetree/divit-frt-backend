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
using Report.Printing;

//Name : Sourav V
//Created Date : 09/02/2026
//Remark : this file defines functions getList of operations for IT Shipment report


namespace Report.Repositories
{
    public class ITShipmentRepository : IITShipmentRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public ITShipmentRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var hbl_date_type = "";
                var hbl_from_date = "";
                var hbl_to_date = "";
                var hbl_mode = "";
                var hbl_parent_name = "";
                var hbl_consignee_name = "";
                var hbl_shipper_name = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("hbl_date_type"))
                    hbl_date_type = data["hbl_date_type"].ToString();
                if (data.ContainsKey("hbl_from_date"))
                    hbl_from_date = data["hbl_from_date"].ToString();
                if (data.ContainsKey("hbl_to_date"))
                    hbl_to_date = data["hbl_to_date"].ToString();
                if (data.ContainsKey("hbl_mode"))
                    hbl_mode = data["hbl_mode"].ToString();
                if (data.ContainsKey("hbl_parent_name"))
                    hbl_parent_name = data["hbl_parent_name"].ToString()!;
                if (data.ContainsKey("hbl_consignee_name"))
                    hbl_consignee_name = data["hbl_consignee_name"].ToString();
                if (data.ContainsKey("hbl_shipper_name"))
                    hbl_shipper_name = data["hbl_shipper_name"].ToString();

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
                    {"hbl_date_type",hbl_date_type!},
                    {"hbl_from_date",hbl_from_date!},
                    {"hbl_to_date",hbl_to_date!},
                    {"hbl_mode", hbl_mode!},
                    {"hbl_parent_name", hbl_parent_name!},
                    {"hbl_consignee_name", hbl_consignee_name!},
                    {"hbl_shipper_name", hbl_shipper_name!},
                };

                IQueryable<cargo_housem> query = context.cargo_housem
                    .Include(h => h.shipper)
                    .Include(h => h.consignee)
                    .Include(h => h.incoterm)
                    .Include(h => h.master)
                        .ThenInclude(m => m!.liner)
                    .Include(h => h.master)
                        .ThenInclude(m => m!.pol)
                    .Include(h => h.master)
                        .ThenInclude(m => m!.pod)
                    .Include(h => h.master)
                        .ThenInclude(m => m!.agent);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.hbl_is_itshipment == "Y");

                if (!Lib.IsBlank(hbl_from_date))
                {
                    from_date = Lib.ParseDateOnly(hbl_from_date!);
                    if (hbl_date_type == "REF. DATE")
                    {
                        query = query.Where(w => w.master!.mbl_ref_date >= from_date);
                    }
                    if (hbl_date_type == "ETD")
                    {
                        query = query.Where(w => w.master!.mbl_pol_etd >= from_date);
                    }
                    if (hbl_date_type == "ETA")
                    {
                        query = query.Where(w => w.master!.mbl_pod_eta >= from_date);
                    }
                }
                if (!Lib.IsBlank(hbl_to_date))
                {
                    to_date = Lib.ParseDateOnly(hbl_to_date!);
                    if (hbl_date_type == "REF. DATE")
                    {
                        query = query.Where(w => w.master!.mbl_ref_date <= to_date);
                    }
                    if (hbl_date_type == "ETD")
                    {
                        query = query.Where(w => w.master!.mbl_pol_etd <= to_date);
                    }
                    if (hbl_date_type == "ETA")
                    {
                        query = query.Where(w => w.master!.mbl_pod_eta <= to_date);
                    }
                }
                if (!Lib.IsBlank(hbl_mode))
                {
                    query = query.Where(w => w.hbl_mode == hbl_mode);
                }

                query = query.OrderBy(o => o.hbl_houseno);
                
                var Records = await query.Select(e => new rep_itshipment_dto
                {
                            hbl_id = e.hbl_id,
                            hbl_mbl_id = e.hbl_mbl_id,
                            hbl_mbl_refno = e.master!.mbl_refno,
                            hbl_ref_date = Lib.FormatDate(e.master.mbl_ref_date, Lib.outputDateFormat),
                            hbl_mode = e.hbl_mode,

                            hbl_agent_name = e.master.agent!.cust_name,
                            hbl_shipper_name = e.shipper!.cust_name,
                            hbl_consignee_name = e.consignee!.cust_name,
                            hbl_pol_name = e.master.pol!.param_name,
                            hbl_pod_name = e.master.pod!.param_name,
                            hbl_pol_etd = Lib.FormatDate(e.master.mbl_pol_etd, Lib.outputDateFormat),
                            hbl_pod_eta = Lib.FormatDate(e.master.mbl_pod_eta, Lib.outputDateFormat),

                            hbl_mbl_no = e.master.mbl_no,
                            hbl_place_final = e.hbl_place_final,
                            hbl_houseno = e.hbl_houseno,

                            hbl_mbl_cntr_type = e.master.mbl_cntr_type,

                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        }).ToListAsync();
    
                


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

                // if (action == "PDF" || action == "PRINT")
                // {
                //     var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                //     fileDataList.Add(pdfResult);
                // }
                if (action == "EXCEL" || action == "PRINT")
                {
                    var excelResult = ProcessExcelFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
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
        // public filesm ProcessPdfFileAsync(List<rep_itshipment_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        // {
        //     var Dt_List = Records;
        //     if (Dt_List.Count <= 0)
        //         throw new Exception("Print List Records error");

        //     DSRPdfFile bc = new DSRPdfFile
        //     {
        //         Dt_List = Dt_List,
        //         Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //         Title = title,
        //         Company_id = company_id,
        //         Branch_id = branch_id,
        //         context = context,
        //         User_name = user_name,
        //         FromDate = searchInfo.ContainsKey("hbl_from_date") ? searchInfo["hbl_from_date"] : "",
        //         ToDate = searchInfo.ContainsKey("hbl_to_date") ? searchInfo["hbl_to_date"] : "",
        //         OpGroup = searchInfo.ContainsKey("hbl_mode") ? searchInfo["hbl_mode"] : "",
        //         ParentName = searchInfo.ContainsKey("hbl_parent_name") ? searchInfo["hbl_parent_name"] : "",
        //         AgentName = searchInfo.ContainsKey("hbl_agent_name") ? searchInfo["hbl_agent_name"] : "",
        //         ShipperName = searchInfo.ContainsKey("hbl_shipper_name") ? searchInfo["hbl_shipper_name"] : "",
        //         ConsigneeName = searchInfo.ContainsKey("hbl_consignee_name") ? searchInfo["hbl_consignee_name"] : "",
        //     };
        //     bc.Process();

        //     if (bc.FList == null || !bc.FList.Any())
        //         throw new Exception("File generation failed.");

        //     var file = bc.FList[0];

        //     var record = new filesm
        //     {
        //         filepath = file.filename!,
        //         filename = file.filedisplayname!,
        //         filetype = file.filetype!
        //     };
        //     return record;
        // }
        public filesm ProcessExcelFileAsync(List<rep_itshipment_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            ITShipmentExcelFile bc = new ITShipmentExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                DateType = searchInfo.ContainsKey("hbl_date_type") ? searchInfo["hbl_date_type"] : "",
                FromDate = searchInfo.ContainsKey("hbl_from_date") ? searchInfo["hbl_from_date"] : "",
                // ToDate = searchInfo.ContainsKey("hbl_to_date") ? searchInfo["hbl_to_date"] : "",
                // OpGroup = searchInfo.ContainsKey("hbl_mode") ? searchInfo["hbl_mode"] : "",
                // ParentName = searchInfo.ContainsKey("hbl_parent_name") ? searchInfo["hbl_parent_name"] : "",
                // ShipperName = searchInfo.ContainsKey("hbl_shipper_name") ? searchInfo["hbl_shipper_name"] : "",
                // ConsigneeName = searchInfo.ContainsKey("hbl_consignee_name") ? searchInfo["hbl_consignee_name"] : "",
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