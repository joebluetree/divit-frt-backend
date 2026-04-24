using Database;
using Database.Lib;
using Common.DTO.Masters;

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

//Name : Sourav V
//Created Date : 30/12/2025
//Remark : this file defines functions getList and getRecords of operations for report/summary


namespace Report.Repositories
{
    public class CustomerListRepository : ICustomerListRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public CustomerListRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var cust_from_date = "";
                var cust_to_date = "";
                var cust_type = "";
                var cust_name = "";
                var cust_format = "";

                var company_id = 0;
                var branch_id = 0;

                DateTime? from_date = null;
                DateTime? to_date = null;

                if (data.ContainsKey("cust_from_date"))
                    cust_from_date = data["cust_from_date"].ToString();
                if (data.ContainsKey("cust_to_date"))
                    cust_to_date = data["cust_to_date"].ToString();
                if (data.ContainsKey("cust_type"))
                    cust_type = data["cust_type"].ToString();
                if (data.ContainsKey("cust_name"))
                    cust_name = data["cust_name"].ToString();

                if (data.ContainsKey("cust_format"))
                    cust_format = data["cust_format"].ToString();

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

                IQueryable<mast_customerm> query = context.mast_customerm;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);

                if(cust_format == "STANDARD")
                {
                    if (!Lib.IsBlank(cust_type) && cust_type != "ALL")
                    {
                        var custTypeCode = GetCustomerTypeCode(cust_type);
                        query = query.Where(w => w.cust_type!.Contains(custTypeCode!));
                    }
                }
                if (!Lib.IsBlank(cust_name))
                {
                    query = query.Where(w => w.cust_name!.Contains(cust_name!));
                }

                if (!Lib.IsBlank(cust_from_date))
                {
                    from_date = Lib.ParseDate(cust_from_date!);
                    query = query.Where(w => w.rec_created_date >= from_date);
                }
                if (!Lib.IsBlank(cust_to_date))
                {
                    to_date = Lib.ParseDate(cust_to_date!);
                    query = query.Where(w => w.rec_created_date <= to_date);
                }

                if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                {
                    _page.rows = query.Count();
                    _page.pages = Lib.getTotalPages(_page.rows, _page.pageSize);
                    _page.currentPageNo = 1;
                }
                else
                {
                    _page.currentPageNo = Lib.FindPage(action, _page.currentPageNo, _page.pages);
                }

                query = query
                    .OrderBy(c => c.rec_created_date);

                if (!isPrint)
                {
                    int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                    query = query
                        .Skip(StartRow)
                        .Take(_page.pageSize);
                }

                var Records = await query.Select(e => new rep_customerlist_dto
                {
                    cust_id = e.cust_id,
                    cust_code = e.cust_code,
                    cust_name = e.cust_name,
                    cust_official_name = e.cust_official_name,
                    cust_address1 = e.cust_address1,
                    cust_address2 = e.cust_address2,
                    cust_address3 = e.cust_address3,
                    cust_type = e.cust_type,
                    cust_contact = e.cust_contact,
                    cust_tel = e.cust_tel,
                    cust_mobile = e.cust_mobile,
                    cust_email = e.cust_email,
                    cust_city = e.cust_city,
                    cust_state_name = e.state!.param_name,
                    cust_country_code = e.country!.param_code,
                    cust_country_name = e.country!.param_name,
                    cust_is_splacc = e.cust_is_splacc,
                    cust_days = e.cust_days,
                    cust_credit_limit = e.cust_credit_limit,
                    cust_splacc_memo = e.cust_splacc_memo,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();

                var fileDataList = new List<filesm>();
                var searchInfo = new Dictionary<string, string>
                {
                    {"cust_from_date",cust_from_date!},
                    {"cust_to_date",cust_to_date!},
                    {"cust_name", cust_name!},
                    {"cust_type", cust_type!},
                    {"cust_format", cust_format!},
                };

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
        public string GetCustomerTypeCode(string? custTypeName)
        {
            var custTypeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Shipper", "S" },
                { "Consignee", "C" },
                { "Importer", "I" },
                { "Exporter", "X" },
                { "Customs Broker", "B" },
                { "Domestic Forwarder", "F" },
                { "Overseas Agent", "A" },
                { "Air Carrier", "L" },
                { "Sea Carrier", "R" },
                { "Trucker", "T" },
                { "Warehouse", "W" },
                { "Terminal Sea / Rail", "N" },
                { "Terminal Air", "P" },
                { "Shipping Vendor", "H" },
                { "General Vendor", "V" },
                { "Employees", "E" },
                { "Contractor", "O" },
                { "Miscellaneous", "M" },
                { "TBD", "D" },
                { "Bank / Financial Institute", "K" }
            };

            return custTypeMap.TryGetValue(custTypeName!.Trim(), out var code) ? code : "";
        }
        public filesm ProcessPdfFileAsync(List<rep_customerlist_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");

            CustomerListPdfFile bc = new CustomerListPdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("cust_from_date") ? searchInfo["cust_from_date"] : "",
                ToDate = searchInfo.ContainsKey("cust_to_date") ? searchInfo["cust_to_date"] : "",
                CustType = searchInfo.ContainsKey("cust_type") ? searchInfo["cust_type"] : "",
                CustName = searchInfo.ContainsKey("cust_name") ? searchInfo["cust_name"] : "",
                CustFormat = searchInfo.ContainsKey("cust_format") ? searchInfo["cust_format"] : "",

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
        public filesm ProcessExcelFileAsync(List<rep_customerlist_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            CustomerListExcelFile bc = new CustomerListExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("cust_from_date") ? searchInfo["cust_from_date"] : "",
                ToDate = searchInfo.ContainsKey("cust_to_date") ? searchInfo["cust_to_date"] : "",
                CustType = searchInfo.ContainsKey("cust_type") ? searchInfo["cust_type"] : "",
                CustName = searchInfo.ContainsKey("cust_name") ? searchInfo["cust_name"] : "",
                CustFormat = searchInfo.ContainsKey("cust_format") ? searchInfo["cust_format"] : ""
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
