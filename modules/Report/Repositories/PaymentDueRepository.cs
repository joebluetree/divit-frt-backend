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
using Database.Models.Accounts;
using Report.Printing;

//Name : Sourav V
//Created Date : 20/05/2026
//Remark : this file defines functions getList of operations for Payment Due report


namespace Report.Repositories
{
    public class PaymentDueRepository : IPaymentDueRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public PaymentDueRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var inv_from_date = "";
                var inv_to_date = "";
                var inv_mode = "";
                var inv_cust_name = "";
                var inv_refno = "";
                var inv_sort_order = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("inv_sort_order"))
                    inv_sort_order = data["inv_sort_order"].ToString();
                if (data.ContainsKey("inv_from_date"))
                    inv_from_date = data["inv_from_date"].ToString();
                if (data.ContainsKey("inv_to_date"))
                    inv_to_date = data["inv_to_date"].ToString();
                if (data.ContainsKey("inv_mode"))
                    inv_mode = data["inv_mode"].ToString();
                if (data.ContainsKey("inv_cust_name"))
                    inv_cust_name = data["inv_cust_name"].ToString();
                if (data.ContainsKey("inv_refno"))
                    inv_refno = data["inv_refno"].ToString();

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
                    {"inv_from_date",inv_from_date!},
                    {"inv_to_date",inv_to_date!},
                    {"inv_mode", inv_mode!},
                    {"inv_cust_name", inv_cust_name!},
                };

                IQueryable<acc_invoicem> query = context.acc_invoicem
                    .Include(i => i.master)
                    .Include(i => i.house)
                    .Include(i => i.unit)
                    .Include(i => i.customer);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.inv_arap == "A/P");

                if (!Lib.IsBlank(inv_from_date))
                {
                    from_date = Lib.ParseDateOnly(inv_from_date!);
                    query = query.Where(w => w.inv_date >= from_date);
                }
                if (!Lib.IsBlank(inv_to_date))
                {
                    to_date = Lib.ParseDateOnly(inv_to_date!);
                    query = query.Where(w => w.inv_date <= to_date);
                }
                // if (!Lib.IsBlank(inv_mode))
                // {
                //     query = query.Where(w => w.master!.mbl_mode == inv_mode);
                // }
                if (!Lib.IsBlank(inv_mode))
                {
                    var types = inv_mode!.Split(',');
                    query = query.Where(w => types.Contains(w.master!.mbl_mode));
                }
                if (!Lib.IsBlank(inv_cust_name))
                {
                    query = query.Where(w => w.customer!.cust_name == inv_cust_name);
                }
                if (!Lib.IsBlank(inv_refno))
                {
                    query = query.Where(w => w.master!.mbl_refno!.Contains(inv_refno!));
                }
                query = query.OrderBy(o => o.inv_no);

                var Records = await query.Select(e => new rep_paymentdue_dto
                {
                    inv_id = e.inv_id,
                    inv_mbl_id = e.inv_mbl_id,
                    inv_hbl_id = e.inv_hbl_id,
                    inv_no = e.inv_no,
                    inv_refno = e.inv_mbl_refno,
                    inv_houseno = e.house!.hbl_houseno,
                    inv_date = Lib.FormatDate(e.inv_date, Lib.outputDateFormat),
                    inv_mode = e.master!.mbl_mode,
                    inv_cust_id = e.inv_cust_id,
                    inv_cust_name = e.customer!.cust_name,

                    inv_payment_date = Lib.FormatDate(e.inv_date!.Value.AddDays(e.customer.cust_days ?? 0), Lib.outputDateFormat),
                    inv_amount = e.inv_total,
                    inv_balance = e.inv_total - e.inv_paid,

                    rec_locked = e.rec_locked,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();
                // Records.AddRange(HRecords);
                Func<rep_paymentdue_dto, object> groupSelector = x => "";

                if (inv_sort_order == "REF#")
                    groupSelector = x => x.inv_refno!;
                if (inv_sort_order == "HOUSE#")
                    groupSelector = x => x.inv_houseno!;
                if (inv_sort_order == "CUSTOMER")
                    groupSelector = x => x.inv_cust_name!;
                if (inv_sort_order == "INVOICE #")
                    groupSelector = x => x.inv_no!;
                if (inv_sort_order == "INVOICE DATE")
                    groupSelector = x => x.inv_date!;
                if (inv_sort_order == "PAYMENT DATE")
                    groupSelector = x => x.inv_payment_date!;
                if (inv_sort_order == "INVOICE AMOUNT")
                    groupSelector = x => x.inv_amount!;
                if (inv_sort_order == "BALANCE")
                    groupSelector = x => x.inv_balance!;

                Records = Records.OrderBy(groupSelector).ToList();

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
        public filesm ProcessPdfFileAsync(List<rep_paymentdue_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Not Found");

            PaymentDuePdfFile bc = new PaymentDuePdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("inv_from_date") ? searchInfo["inv_from_date"] : "",
                ToDate = searchInfo.ContainsKey("inv_to_date") ? searchInfo["inv_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("inv_mode") ? searchInfo["inv_mode"] : "",
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
        public filesm ProcessExcelFileAsync(List<rep_paymentdue_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            PaymentDueExcelFile bc = new PaymentDueExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("inv_from_date") ? searchInfo["inv_from_date"] : "",
                ToDate = searchInfo.ContainsKey("inv_to_date") ? searchInfo["inv_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("inv_mode") ? searchInfo["inv_mode"] : "",
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