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
using Database.Models.CommonShipment;

//Name : Sourav V
//Created Date : 25/06/2026
//Remark : this file defines functions getList of operations for Approval Request report


namespace Report.Repositories
{
    public class ApprovalRequestRepository : IApprovalRequestRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public ApprovalRequestRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var ca_parent_id = 0;
                var ca_from_date = "";
                var ca_to_date = "";
                var ca_doc_type = "";
                var ca_type = "";
                var ca_sortby = "";
                var ca_is_hide = "";
                var ca_ref_no = "";
                var ca_user = "";
                var ca_req_type = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("ca_from_date"))
                    ca_from_date = data["ca_from_date"].ToString();
                if (data.ContainsKey("ca_to_date"))
                    ca_to_date = data["ca_to_date"].ToString();
                if (data.ContainsKey("ca_doc_type"))
                    ca_doc_type = data["ca_doc_type"].ToString();
                if (data.ContainsKey("ca_type"))
                    ca_type = data["ca_type"].ToString();
                if (data.ContainsKey("ca_sortby"))
                    ca_sortby = data["ca_sortby"].ToString();
                if (data.ContainsKey("ca_is_hide"))
                    ca_is_hide = data["ca_is_hide"].ToString()!;
                if (data.ContainsKey("ca_ref_no"))
                    ca_ref_no = data["ca_ref_no"].ToString();
                if (data.ContainsKey("ca_user"))
                    ca_user = data["ca_user"].ToString();
                if (data.ContainsKey("ca_req_type"))
                    ca_req_type = data["ca_req_type"].ToString();
                if (data.ContainsKey("ca_parent_id"))
                    ca_parent_id = int.Parse(data["ca_parent_id"].ToString()!);

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
                    {"ca_from_date",ca_from_date!},
                    {"ca_to_date",ca_to_date!},
                    {"ca_type", ca_type!},
                    {"ca_doc_type", ca_doc_type!},
                    {"ca_ref_no", ca_ref_no!},
                    {"ca_user", ca_user!},
                    {"ca_req_type", ca_req_type!},
                    // {"ca_shipper_name", ca_shipper_name!},
                };

                IQueryable<cargo_approvedm> query = context.cargo_approvedm
                .Include(i => i.consignee);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.ca_is_hide == ca_is_hide);
                if (!Lib.IsBlank(ca_from_date))
                {
                    from_date = Lib.ParseDateOnly(ca_from_date!);
                    query = query.Where(w => w.ca_date >= from_date);
                }
                if (!Lib.IsBlank(ca_to_date))
                {
                    to_date = Lib.ParseDateOnly(ca_to_date!);
                    query = query.Where(w => w.ca_date <= to_date);
                }
                if (!Lib.IsBlank(ca_type) && ca_type != "ALL")
                {
                    query = query.Where(w => w.ca_type == ca_type);
                }
                if (!Lib.IsBlank(ca_doc_type) && ca_doc_type != "ALL")
                {
                    query = query.Where(w => w.ca_doc_type == ca_doc_type);
                }
                if (!Lib.IsBlank(ca_ref_no))
                {
                    query = query.Where(w => w.ca_ref_no == ca_ref_no);
                }

                var data_ =
                from m in query
                join d in context.cargo_approvedd
                    on m.ca_id equals d.cad_parent_id into ApproveGroup

                from d in ApproveGroup.DefaultIfEmpty()
                where Lib.IsBlank(ca_user) || (ca_req_type =="APPROVAL REQ REPORT" && m.user!.user_name == ca_user) || (ca_req_type =="APPROVAL REPORT" && d.approvedby!.user_name == ca_user )
                orderby m.ca_req_no
                select new rep_approvedd_dto
                {
                    ca_id = m.ca_id,
                    ca_req_no = m.ca_req_no,
                    ca_type = m.ca_type,
                    ca_doc_type = m.ca_doc_type,
                    ca_mbl_id = m.ca_mbl_id,
                    ca_ref_no = m.ca_ref_no,        //master ref
                    ca_remarks = m.ca_remarks,
                    ca_user_id = m.ca_user_id,
                    ca_user_name = m.user!.user_name,
                    ca_is_approved = m.ca_is_approved,
                    ca_date = Lib.FormatDate(m.ca_date, Lib.outputDateFormat),
                    ca_hbl_id = m.ca_hbl_id,
                    ca_hbl_no = m.house!.hbl_houseno,
                    ca_inv_id = m.ca_inv_id,
                    ca_inv_no = m.invoice!.inv_no,
                    ca_inv_cust = m.invoice!.inv_cust_name,
                    ca_inv_amt = m.invoice!.inv_total,
                    ca_consignee_id = m.ca_consignee_id,
                    ca_consignee_name = m.consignee!.cust_name,
                    cad_approvedby_name = d.approvedby!.user_name,
                    cad_approved_date = Lib.FormatDate(d.cad_approved_date, Lib.outputDateFormat),
                    cad_is_approved = d.cad_is_approved == null ? "NOT APPROVED" : d.cad_is_approved == "Y" ? "APPROVED" : "NOT APPROVED",

                    ca_approved_tot = m.ca_approved_tot,
                    ca_notapproved_tot = m.ca_notapproved_tot,
                    ca_obl_recvd_date = Lib.FormatDate(m.ca_obl_recvd_date, Lib.outputDateTimeFormat),
                    ca_payment_recvd_date = Lib.FormatDate(m.ca_payment_recvd_date, Lib.outputDateTimeFormat),
                    ca_is_hide = m.ca_is_hide,
                    ca_is_ar_issued = m.ca_is_ar_issued,
                    ca_is_hide2 = m.ca_is_hide2,
                    rec_files_attached = m.rec_files_attached,
                    // rec_record_id = m.rec_record_id,
                    // rec_location_id = m.rec_location_id,

                    rec_created_by = m.rec_created_by,
                    rec_created_date = Lib.FormatDate(m.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = m.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(m.rec_edited_date, Lib.outputDateTimeFormat),
                };

                var Records = await data_.ToListAsync();


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
                    var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                    fileDataList.Add(pdfResult);
                }
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
        public async Task<Dictionary<string, object>> HideRecordAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();
                
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_approvedm
                    .FirstOrDefaultAsync(f => f.ca_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                if (_Record!.ca_is_hide == "N")
                {
                    _Record.ca_is_hide = "Y";
                }
                else
                {
                    _Record.ca_is_hide = "N";
                }
                context.SaveChanges();
                context.Database.CommitTransaction();
             
                RetData.Add("status", true);
                RetData.Add("message", "");
                return RetData;
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }
        public filesm ProcessPdfFileAsync(List<rep_approvedd_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");

            ApprovalReportPdfFile bc = new ApprovalReportPdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("ca_from_date") ? searchInfo["ca_from_date"] : "",
                ToDate = searchInfo.ContainsKey("ca_to_date") ? searchInfo["ca_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("ca_doc_type") ? searchInfo["ca_doc_type"] : "",
                Type = searchInfo.ContainsKey("ca_type") ? searchInfo["ca_type"] : "",
                Reference = searchInfo.ContainsKey("ca_ref_no") ? searchInfo["ca_ref_no"] : "",
                RequestBy = searchInfo.ContainsKey("ca_user") ? searchInfo["ca_user"] : "",
                ReportType = searchInfo.ContainsKey("ca_req_type") ? searchInfo["ca_req_type"] : "",
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
        public filesm ProcessExcelFileAsync(List<rep_approvedd_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            ApprovalReportExcelFile bc = new ApprovalReportExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("ca_from_date") ? searchInfo["ca_from_date"] : "",
                ToDate = searchInfo.ContainsKey("ca_to_date") ? searchInfo["ca_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("ca_doc_type") ? searchInfo["ca_doc_type"] : "",
                Type = searchInfo.ContainsKey("ca_type") ? searchInfo["ca_type"] : "",
                Reference = searchInfo.ContainsKey("ca_ref_no") ? searchInfo["ca_ref_no"] : "",
                RequestBy = searchInfo.ContainsKey("ca_user") ? searchInfo["ca_user"] : "",
                ReportType = searchInfo.ContainsKey("ca_req_type") ? searchInfo["ca_req_type"] : "",
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