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
using System.ComponentModel.DataAnnotations;
using Common.DTO.Email;
using Database.Models.Email;

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

                if (action == "PRINT" || action == "EXCEL" || action == "PDF" || action == "Pending A/N")
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

                // List<rep_shipmentclose_dto> Records = new List<rep_shipmentclose_dto>();

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
                    

                    mbl_agent_name = e.master.agent!.cust_name,
                    mbl_shipper_name = e.shipper!.cust_name,
                    mbl_consignee_name = e.consignee!.cust_name,
                    mbl_handled_name = e.handledby!.param_name,
                    mbl_handled_email = e.handledby!.param_email!.ToLower(),
                    mbl_liner_name = e.master.liner!.param_name,
                    mbl_incoterm = e.incoterm!.param_name,
                    mbl_cntr_type = e.master.mbl_cntr_type,
                    mbl_pol_name = e.master.pol!.param_name,
                    mbl_pod_name = e.master.pod!.param_name,
                    mbl_pol_etd = Lib.FormatDate(e.master.mbl_pol_etd, Lib.outputDateFormat),
                    mbl_pod_eta = Lib.FormatDate(e.master.mbl_pod_eta, Lib.outputDateFormat),
                    mbl_firm_code = e.location!.cust_firm_code,

                    mbl_ams_fileno = e.hbl_ams_fileno,
                    mbl_it_tot = e.hbl_is_itshipment,
                    mbl_bo_status = e.master.mbl_bo_status,
                    mbl_bo_attended_code = e.master.mbl_bo_attended_code,
                    mbl_isf_no = e.hbl_isf_no,
                    mbl_mstatus = e.master.mblstatus!.param_name,
                    mbl_hstatus = e.telexrelease!.param_name,
                    mbl_custom_reles_status = e.hbl_custom_reles_status,
                    mbl_frt_status_name = e.hbl_frt_status_name,
                    mbl_paid_status = $"{e.paidstatus!.param_name} {e.hbl_paid_remarks}",
                    mbl_lfd = Lib.FormatDate(e.hbl_lfd_date, Lib.outputDateFormat),
                    mbl_is_delivery = e.hbl_is_delivery,
                    mbl_packages = e.hbl_packages,
                    mbl_place_final = e.hbl_place_final,
                    hbl_plf_eta = Lib.FormatDate(e.hbl_plf_eta, Lib.outputDateFormat),// delivery date

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

                // if (action == "PDF" || action == "PRINT")
                // {
                //     var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo, mbl_list_format!);
                //     fileDataList.Add(pdfResult);
                // }
                // if (action == "EXCEL" || action == "PRINT")
                // {
                //     var excelResult = ProcessExcelFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo, mbl_list_format!);
                //     fileDataList.Add(excelResult);
                // }
                // if (action == "Pending A/N")
                // {
                //     var excelResult = ProcessPendingANFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo, mbl_list_format!);
                //     fileDataList.AddRange(excelResult);
                //     action = "EXCEL";
                // }

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
        // public filesm ProcessPdfFileAsync(List<rep_shipmentclose_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo, string mbl_list_format)
        // {
        //     var Dt_List = Records;
        //     if (Dt_List.Count <= 0)
        //         throw new Exception("Print List Records error");
        //     object bc = null!;

        //     if (mbl_list_format == null)
        //         throw new Exception("Print List Format error");
        //     if (mbl_list_format == "F1")
        //     {
        //         bc = new ShipmentLogF1PdfFile //ShipmentLogF1PdfFile
        //         {
        //             Dt_List = Dt_List,
        //             Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //             Title = title,
        //             Company_id = company_id,
        //             Branch_id = branch_id,
        //             context = context,
        //             User_name = user_name,
        //             DateType = searchInfo.ContainsKey("mbl_date_type") ? searchInfo["mbl_date_type"] : "",
        //             FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
        //             ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
        //             OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
        //             ShipperName = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
        //             ConsigneeName = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
        //             AgentName = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
        //             UserRole = searchInfo.ContainsKey("mbl_user_role") ? searchInfo["mbl_user_role"] : "",
        //             handledBy = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
        //             CreatedBy = searchInfo.ContainsKey("rec_created_name") ? searchInfo["rec_created_name"] : "",
        //         };
        //     }
        //     if (mbl_list_format == "F2")
        //     {
        //         bc = new ShipmentLogF2PdfFile //ShipmentLogF2PdfFile 
        //         {
        //             Dt_List = Dt_List,
        //             Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //             Title = title,
        //             Company_id = company_id,
        //             Branch_id = branch_id,
        //             context = context,
        //             User_name = user_name,
        //             DateType = searchInfo.ContainsKey("mbl_date_type") ? searchInfo["mbl_date_type"] : "",
        //             FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
        //             ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
        //             OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
        //             ShipperName = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
        //             ConsigneeName = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
        //             AgentName = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
        //             UserRole = searchInfo.ContainsKey("mbl_user_role") ? searchInfo["mbl_user_role"] : "",
        //             handledBy = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
        //             CreatedBy = searchInfo.ContainsKey("rec_created_name") ? searchInfo["rec_created_name"] : "",
        //         };
        //     }
        //     if (mbl_list_format == "F3")
        //     {
        //         bc = new ShipmentLogF3PdfFile //ShipmentLogF3PdfFile 
        //         {
        //             Dt_List = Dt_List,
        //             Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //             Title = title,
        //             Company_id = company_id,
        //             Branch_id = branch_id,
        //             context = context,
        //             User_name = user_name,
        //             DateType = searchInfo.ContainsKey("mbl_date_type") ? searchInfo["mbl_date_type"] : "",
        //             FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
        //             ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
        //             OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
        //             ShipperName = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
        //             ConsigneeName = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
        //             AgentName = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
        //             UserRole = searchInfo.ContainsKey("mbl_user_role") ? searchInfo["mbl_user_role"] : "",
        //             handledBy = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
        //             CreatedBy = searchInfo.ContainsKey("rec_created_name") ? searchInfo["rec_created_name"] : "",
        //         };
        //     }
        //     if (bc == null)
        //         throw new Exception("File generation error");
        //     dynamic pdf = bc!;
        //     pdf.Process();

        //     if (pdf.FList == null || pdf.FList.Count == 0)
        //         throw new Exception("File generation failed.");

        //     var file = pdf.FList[0];

        //     var record = new filesm
        //     {
        //         filepath = file.filename!,
        //         filename = file.filedisplayname!,
        //         filetype = file.filetype!
        //     };
        //     return record;
        // }
        // public filesm ProcessExcelFileAsync(List<rep_shipmentclose_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo, string mbl_list_format)
        // {
        //     var Dt_List = Records;
        //     if (Dt_List.Count <= 0)
        //         throw new Exception("Excel List Records error");

        //     object bc = null!;

        //     if (mbl_list_format == null)
        //         throw new Exception("Print List Format error");
        //     if (mbl_list_format == "F1")
        //     {
        //         bc = new ShipmentLogF1ExcelFile
        //         {
        //             Dt_List = Dt_List,
        //             report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //             Title = title,
        //             Company_id = company_id,
        //             Branch_id = branch_id,
        //             context = context,
        //             User_name = user_name,
        //             DateType = searchInfo.ContainsKey("mbl_date_type") ? searchInfo["mbl_date_type"] : "",
        //             FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
        //             ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
        //             OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
        //             ShipperName = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
        //             ConsigneeName = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
        //             AgentName = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
        //             UserRole = searchInfo.ContainsKey("mbl_user_role") ? searchInfo["mbl_user_role"] : "",
        //             handledBy = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
        //             CreatedBy = searchInfo.ContainsKey("rec_created_name") ? searchInfo["rec_created_name"] : "",
        //         };
        //     }
        //     if (mbl_list_format == "F2")
        //     {
        //         bc = new ShipmentLogF2ExcelFile
        //         {
        //             Dt_List = Dt_List,
        //             report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //             Title = title,
        //             Company_id = company_id,
        //             Branch_id = branch_id,
        //             context = context,
        //             User_name = user_name,
        //             DateType = searchInfo.ContainsKey("mbl_date_type") ? searchInfo["mbl_date_type"] : "",
        //             FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
        //             ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
        //             OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
        //             ShipperName = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
        //             ConsigneeName = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
        //             AgentName = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
        //             UserRole = searchInfo.ContainsKey("mbl_user_role") ? searchInfo["mbl_user_role"] : "",
        //             handledBy = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
        //             CreatedBy = searchInfo.ContainsKey("rec_created_name") ? searchInfo["rec_created_name"] : "",
        //         };
        //     }
        //     if (mbl_list_format == "F3")
        //     {
        //         bc = new ShipmentLogF3ExcelFile
        //         {
        //             Dt_List = Dt_List,
        //             report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //             Title = title,
        //             Company_id = company_id,
        //             Branch_id = branch_id,
        //             context = context,
        //             User_name = user_name,
        //             DateType = searchInfo.ContainsKey("mbl_date_type") ? searchInfo["mbl_date_type"] : "",
        //             FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
        //             ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
        //             OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
        //             ShipperName = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
        //             ConsigneeName = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
        //             AgentName = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
        //             UserRole = searchInfo.ContainsKey("mbl_user_role") ? searchInfo["mbl_user_role"] : "",
        //             handledBy = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
        //             CreatedBy = searchInfo.ContainsKey("rec_created_name") ? searchInfo["rec_created_name"] : "",
        //         };
        //     }
        //     if (bc == null)
        //         throw new Exception("File generation error");
        //     dynamic excell = bc!;
        //     excell.Process();

        //     if (excell.fList == null || excell.fList.Count == 0)
        //         throw new Exception("Excel generation failed.");

        //     var file = excell.fList[0];

        //     var record = new filesm
        //     {
        //         filepath = file.filename!,
        //         filename = file.filedisplayname!,
        //         filetype = file.filetype!
        //     };

        //     return record;
        // }
        // public List<filesm> ProcessPendingANFileAsync(List<rep_shipmentclose_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo, string mbl_list_format)
        // {
        //     var Dt_List = Records;
        //     if (Dt_List.Count <= 0)
        //         throw new Exception("Excel List Records error");

        //     ShipmentLogANPendingExcelFile bc = new ShipmentLogANPendingExcelFile
        //     {
        //         Dt_List = Dt_List,
        //         report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //         Title = "A/N Pending Report",
        //         Company_id = company_id,
        //         Branch_id = branch_id,
        //         context = context,
        //         User_name = user_name,
        //         DateType = searchInfo.ContainsKey("mbl_date_type") ? searchInfo["mbl_date_type"] : "",
        //         FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
        //         ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
        //         OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
        //         ShipperName = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
        //         ConsigneeName = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
        //         AgentName = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
        //         UserRole = searchInfo.ContainsKey("mbl_user_role") ? searchInfo["mbl_user_role"] : "",
        //         handledBy = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
        //         CreatedBy = searchInfo.ContainsKey("rec_created_name") ? searchInfo["rec_created_name"] : "",
        //         IsHandledbyWise = searchInfo.ContainsKey("rec_handledby_wise") ? searchInfo["rec_handledby_wise"] : "",
        //     };
        //     bc.Process();

        //     if (bc.fList == null || !bc.fList.Any())
        //         throw new Exception("Excel generation failed.");

        //     // var file = bc.fList[0];

        //     List<filesm> fileList = new List<filesm>();

        //     foreach (var file in bc.fList)
        //     {
        //         fileList.Add(new filesm
        //         {
        //             filepath = file.filename!,
        //             filename = file.filedisplayname!,
        //             filetype = file.filetype!,
        //             file_value1 = file.file_value1
        //         });
        //     }

        //     return fileList;
        // }
    }
}