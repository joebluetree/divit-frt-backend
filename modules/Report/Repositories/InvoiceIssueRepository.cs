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
using Database.Models.Accounts;

//Name : Sourav V
//Created Date : 14/03/2026
//Remark : this file defines functions getList of operations for Invoice Issue Report


namespace Report.Repositories
{
    public class InvoiceIssueRepository : IInvoiceIssueRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public InvoiceIssueRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var inv_date_type = "";
                var inv_from_date = "";
                var inv_to_date = "";
                var inv_mode = "";
                var inv_type = "";
                var inv_parent_name = "";
                var inv_cust_name = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("inv_date_type"))
                    inv_date_type = data["inv_date_type"].ToString();
                if (data.ContainsKey("inv_from_date"))
                    inv_from_date = data["inv_from_date"].ToString();
                if (data.ContainsKey("inv_to_date"))
                    inv_to_date = data["inv_to_date"].ToString();
                if (data.ContainsKey("inv_type"))
                    inv_type = data["inv_type"].ToString();
                if (data.ContainsKey("inv_mode"))
                    inv_mode = data["inv_mode"].ToString();
                if (data.ContainsKey("inv_parent_name"))
                    inv_parent_name = data["inv_parent_name"].ToString()!;
                if (data.ContainsKey("inv_cust_name"))
                    inv_cust_name = data["inv_cust_name"].ToString();

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
                    {"inv_date_type",inv_date_type!},
                    {"inv_from_date",inv_from_date!},
                    {"inv_to_date",inv_to_date!},
                    {"inv_mode", inv_mode!},
                    {"inv_type", inv_type!},
                    {"inv_parent_name", inv_parent_name!},
                    {"inv_cust_name", inv_cust_name!},
                };

                IQueryable<acc_invoicem> query = context.acc_invoicem;
                // .Include(h => h.shipper)


                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                // query = query.Where(w => w.inv_is_itshipment == "Y");

                if (!Lib.IsBlank(inv_from_date))
                {
                    from_date = Lib.ParseDateOnly(inv_from_date!);
                    if (inv_date_type == "REF. DATE")
                    {
                        query = query.Where(w => w.master!.mbl_ref_date >= from_date);
                    }
                    if (inv_date_type == "INV. DATE")
                    {
                        query = query.Where(w => w.inv_date >= from_date);
                    }
                }
                if (!Lib.IsBlank(inv_to_date))
                {
                    to_date = Lib.ParseDateOnly(inv_to_date!);
                    if (inv_date_type == "REF. DATE")
                    {
                        query = query.Where(w => w.master!.mbl_ref_date <= to_date);
                    }
                    if (inv_date_type == "INV. DATE")
                    {
                        query = query.Where(w => w.inv_date <= to_date);
                    }
                }

                if (!Lib.IsBlank(inv_mode))
                {
                    if (inv_mode == "ALL")
                    {
                        var Types = new[] { "SEA IMPORT", "SEA EXPORT", "AIR IMPORT", "AIR EXPORT", "OTHERS" };
                        query = query.Where(w => Types.Contains(w.master!.mbl_mode));
                    }
                    else
                    {
                        query = query.Where(w => w.master!.mbl_mode == inv_mode);
                    }
                }
                if (!Lib.IsBlank(inv_type))
                {
                    query = query.Where(w => w.inv_arap == inv_type);
                }
                if (!Lib.IsBlank(inv_parent_name))
                {
                    query = query.Where(w => w.master!.agent!.customer!.cust_name == inv_parent_name);
                }
                if (!Lib.IsBlank(inv_cust_name))
                {
                    query = query.Where(w => w.inv_cust_name == inv_cust_name);
                }

                query = query.OrderBy(o => o.inv_no);

                var Records = await query.Select(e => new rep_invoiceissue_dto
                {
                    inv_id = e.inv_id,
                    inv_no = e.inv_no,
                    inv_date = Lib.FormatDate(e.inv_date, Lib.outputDateFormat),
                    inv_mbl_id = e.inv_mbl_id,
                    inv_mbl_refno = e.master!.mbl_refno,
                    inv_ref_date = Lib.FormatDate(e.master.mbl_ref_date, Lib.outputDateFormat),
                    inv_cust_name = e.customer!.cust_name,
                    inv_mode = e.master.mbl_mode,

                    inv_liner_name = e.master.liner!.param_name,
                    inv_pol_name = e.master.pol!.param_name,
                    inv_pol_country = e.master.pol!.param_value1,
                    inv_pod_name = e.master.pod!.param_name,
                    inv_pod_country = e.master.pod!.param_value1,

                    inv_pol_etd = Lib.FormatDate(e.master.mbl_pol_etd, Lib.outputDateFormat),
                    inv_pod_eta = Lib.FormatDate(e.master.mbl_pod_eta, Lib.outputDateFormat),

                    inv_mbl_no = e.master.mbl_no,
                    inv_houseno = e.inv_houseno,
                    inv_amount = e.inv_total,
                    inv_cur_code = e.currency!.param_code,

                    // inv_mbl_cntr_type = e.master.mbl_cntr_nos,

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
        public filesm ProcessPdfFileAsync(List<rep_invoiceissue_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");

            InvoiceIssuePdfFile bc = new InvoiceIssuePdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                DateType = searchInfo.ContainsKey("inv_date_type") ? searchInfo["inv_date_type"] : "",
                FromDate = searchInfo.ContainsKey("inv_from_date") ? searchInfo["inv_from_date"] : "",
                ToDate = searchInfo.ContainsKey("inv_to_date") ? searchInfo["inv_to_date"] : "",
                InvType = searchInfo.ContainsKey("inv_type") ? searchInfo["inv_type"] : "",
                OpGroup = searchInfo.ContainsKey("inv_mode") ? searchInfo["inv_mode"] : "",
                ParentName = searchInfo.ContainsKey("inv_parent_name") ? searchInfo["inv_parent_name"] : "",
                CustName = searchInfo.ContainsKey("inv_cust_name") ? searchInfo["inv_cust_name"] : "",
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
        public filesm ProcessExcelFileAsync(List<rep_invoiceissue_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            InvoiceIssueExcelFile bc = new InvoiceIssueExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                DateType = searchInfo.ContainsKey("inv_date_type") ? searchInfo["inv_date_type"] : "",
                FromDate = searchInfo.ContainsKey("inv_from_date") ? searchInfo["inv_from_date"] : "",
                ToDate = searchInfo.ContainsKey("inv_to_date") ? searchInfo["inv_to_date"] : "",
                InvType = searchInfo.ContainsKey("inv_type") ? searchInfo["inv_type"] : "",
                OpGroup = searchInfo.ContainsKey("inv_mode") ? searchInfo["inv_mode"] : "",
                ParentName = searchInfo.ContainsKey("inv_parent_name") ? searchInfo["inv_parent_name"] : "",
                CustName = searchInfo.ContainsKey("inv_cust_name") ? searchInfo["inv_cust_name"] : "",
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