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
//Created Date : 10/07/2026
//Remark : this file defines functions getList of operations for payment Request report
// version 2 : 


namespace Report.Repositories
{
    public class PaymentRequestRepository : IPaymentRequestRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public PaymentRequestRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var cp_parent_id = 0;
                var cp_from_date = "";
                var cp_to_date = "";
                var cp_status = "";
                var cp_request_by = "";
                var cp_group = "";
                var cp_is_hide = "";
                var cp_ref_no = "";
                var cp_user = "";
                var cp_req_type = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("cp_from_date"))
                    cp_from_date = data["cp_from_date"].ToString();
                if (data.ContainsKey("cp_to_date"))
                    cp_to_date = data["cp_to_date"].ToString();
                if (data.ContainsKey("cp_status"))
                    cp_status = data["cp_status"].ToString();
                if (data.ContainsKey("cp_request_by"))
                    cp_request_by = data["cp_request_by"].ToString();
                if (data.ContainsKey("cp_group"))
                    cp_group = data["cp_group"].ToString();
                if (data.ContainsKey("cp_is_hide"))
                    cp_is_hide = data["cp_is_hide"].ToString()!;
                if (data.ContainsKey("cp_ref_no"))
                    cp_ref_no = data["cp_ref_no"].ToString();
                if (data.ContainsKey("cp_user"))
                    cp_user = data["cp_user"].ToString();
                if (data.ContainsKey("cp_req_type"))
                    cp_req_type = data["cp_req_type"].ToString();
                if (data.ContainsKey("cp_parent_id"))
                    cp_parent_id = int.Parse(data["cp_parent_id"].ToString()!);

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
                    {"cp_from_date",cp_from_date!},
                    {"cp_to_date",cp_to_date!},
                    {"cp_request_by", cp_request_by!},
                    {"cp_status", cp_status!},
                    {"cp_group", cp_group!},
                };

                IQueryable<cargo_payrequest> query = context.cargo_payrequest
                .Include(i => i.master);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.rec_deleted == "N");
                if (!Lib.IsBlank(cp_from_date))
                {
                    from_date = Lib.ParseDateOnly(cp_from_date!);
                    query = query.Where(w => w.cp_payment_date >= from_date);
                }
                if (!Lib.IsBlank(cp_to_date))
                {
                    to_date = Lib.ParseDateOnly(cp_to_date!);
                    query = query.Where(w => w.cp_payment_date <= to_date);
                }
                if (!Lib.IsBlank(cp_status))
                {
                    query = query.Where(w => w.cp_pay_status == cp_status);
                }
                if (!Lib.IsBlank(cp_request_by))
                {
                    query = query.Where(w => w.rec_created_by == cp_request_by);
                }
                if (!Lib.IsBlank(cp_group) && cp_group != "ALL")
                {
                    query = query.Where(w => w.cp_mode == cp_group);
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
                if (!isPrint)
                {
                    int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);
                    query = query.Skip(StartRow).Take(_page.pageSize);
                }

                var Records = await query.Select(e => new rep_payrequest_dto
                {
                    cp_id = e.cp_id,
                    cp_slno = e.cp_slno,
                    cp_mode = e.cp_mode,
                    cp_source = e.cp_source,
                    cp_master_id = e.cp_master_id,
                    cp_master_no = e.master!.mbl_refno,
                    cp_paytype_needed = e.cp_paytype_needed,
                    cp_spl_notes = e.cp_spl_notes,
                    cp_payment_date = Lib.FormatDate(e.cp_payment_date, Lib.outputDateFormat),
                    cp_pay_status = e.cp_pay_status,
                    cp_cust_id = e.cp_cust_id,
                    cp_cust_name = e.customer!.cust_name,
                    cp_inv_id = e.cp_inv_id,
                    cp_inv_no = e.invoice!.inv_no,
                    cp_inv_hid = e.invoice!.house!.hbl_id,
                    cp_attachment = "ATTACHMENT",
                    cp_checkcopy = "CHECK COPY",
                    cp_approval = "APPROVAL",
                    cp_arap = "AR/AP",

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();

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
                RetData.Add("records", Records);
                RetData.Add("page", _page);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<rep_payrequest_dto?> GetDefaultData(int id)
        {
            try
            {
                IQueryable<cargo_payrequest> query = context.cargo_payrequest;

                query = query.Where(f => f.cp_id == id);

                var Record = await query.Select(e => new rep_payrequest_dto
                {
                    su_id = e.cp_id,
                    su_ref_no = e.master!.mbl_refno,
                    su_status = e.cp_pay_status,

                    rec_version = e.rec_version,
                    rec_branch_id = e.rec_branch_id,
                    rec_company_id = e.rec_company_id,
                }).FirstOrDefaultAsync();
                if (Record == null)
                    throw new Exception("No Data Found");
                     return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<rep_payrequest_dto> SaveStatusAsync(int id, string mode, rep_payrequest_dto record_dto)
        {
            cargo_payrequest? Record;

            try
            {
                context.Database.BeginTransaction();

                if (record_dto == null)
                    throw new Exception("No Data Found");

                Record = await context.cargo_payrequest
                    .Include(c => c.master)
                    .Where(f => f.cp_id == id)
                    .FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("Record Not Found");

                //concurency checking code by using rec_version
                context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                Record.rec_version++; //incrementing the rec_version after the concurrency check
                record_dto.rec_version = Record.rec_version; //asigning the rec_version value to the dto.
                Record.rec_edited_by = record_dto.rec_created_by;
                Record.rec_edited_date = DbLib.GetDateTime();
                

                Record.cp_pay_status = record_dto.su_status;

                await context.SaveChangesAsync();

                record_dto.cp_pay_status = Record.cp_pay_status;
                record_dto.rec_version = Record.rec_version;

                if (mode == "add")
                {
                    record_dto.rec_created_by = Record.rec_created_by;
                    record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                }
                if (mode == "edit")
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }
                context.Database.CommitTransaction();
                return record_dto;
            }
            catch (DbUpdateConcurrencyException)
            {
                context.Database.RollbackTransaction();
                throw new Exception("Kindly reload the record, Another User May have modified the same record");
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }
        public async Task<Dictionary<string, object>> HideRecordAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();
                
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_payrequest
                    .FirstOrDefaultAsync(f => f.cp_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                if (_Record!.rec_deleted == "N")
                {
                    _Record.rec_deleted = "Y";
                }
                else
                {
                    _Record.rec_deleted = "N";
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
        public filesm ProcessPdfFileAsync(List<rep_payrequest_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");

            PaymentRequestPdfFile bc = new PaymentRequestPdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("cp_from_date") ? searchInfo["cp_from_date"] : "",
                ToDate = searchInfo.ContainsKey("cp_to_date") ? searchInfo["cp_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("cp_group") ? searchInfo["cp_group"] : "",
                PayType = searchInfo.ContainsKey("cp_status") ? searchInfo["cp_status"] : "",
                RequestBy = searchInfo.ContainsKey("cp_request_by") ? searchInfo["cp_request_by"] : "",
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
        public filesm ProcessExcelFileAsync(List<rep_payrequest_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            PaymentRequestExcelFile bc = new PaymentRequestExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("cp_from_date") ? searchInfo["cp_from_date"] : "",
                ToDate = searchInfo.ContainsKey("cp_to_date") ? searchInfo["cp_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("cp_group") ? searchInfo["cp_group"] : "",
                PayType = searchInfo.ContainsKey("cp_status") ? searchInfo["cp_status"] : "",
                RequestBy = searchInfo.ContainsKey("cp_request_by") ? searchInfo["cp_request_by"] : "",
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