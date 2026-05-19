using Database;
using Database.Lib;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;
using System.Diagnostics.Eventing.Reader;
using Common.DTO.Email;
using Email.Interfaces;
using Database.Models.Email;

namespace Email.Repositories
{
    //Name : Sourav V
    //Created Date : 12/05/2026
    //Remark : Work on pending(on 18/05/2025)

    public class EmailRepository : IEmailRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        public EmailRepository(AppDbContext _context, IAuditLog _auditLog)
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
                // var title = data["title"].ToString();
                var user_name = data["global_user_name"].ToString();
                var email_status = "";

                var company_id = 0;
                var branch_id = 0;

                if (data.ContainsKey("email_status"))
                    email_status = data["email_status"].ToString();

                company_id = Lib.GetValidIntValue(data!, "rec_company_id", "Company Id Not Found");
                branch_id = Lib.GetValidIntValue(data!, "rec_branch_id", "Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<email_jobs> query = context.email_jobs;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);

                if (!Lib.IsBlank(email_status))
                    query = query.Where(w => w.email_status!.Contains(email_status!));

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

                int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                query = query
                    .OrderBy(c => c.email_ctr)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new email_jobs_dto
                {
                    email_id = e.email_id,
                    email_from_id = e.email_from_id,
                    email_to_id = e.email_to_id,
                    email_cc_id = e.email_cc_id,
                    email_bcc_id = e.email_bcc_id,
                    email_subject = e.email_subject,
                    email_message = e.email_message,
                    email_file_folder = e.email_file_folder,
                    email_ctr = e.email_ctr,
                    email_scheduled_on = Lib.FormatDate(e.email_scheduled_on, Lib.outputDateFormat),
                    email_send_date = Lib.FormatDate(e.email_send_date, Lib.outputDateFormat),
                    email_status = e.email_status,
                    email_error_msg = e.email_error_msg,
                    email_remarks = e.email_remarks,
                    
                }).ToListAsync();

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
        public async Task<email_jobs_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<email_jobs> query = context.email_jobs;

                query = query.Where(f => f.email_id == id);

                var Record = await query.Select(e => new email_jobs_dto
                {
                    email_id = e.email_id,
                    email_from_id = e.email_from_id,
                    email_to_id = e.email_to_id,
                    email_cc_id = e.email_cc_id,
                    email_bcc_id = e.email_bcc_id,
                    email_subject = e.email_subject,
                    email_message = e.email_message,
                    email_file_folder = e.email_file_folder,
                    email_ctr = e.email_ctr,
                    email_scheduled_on = Lib.FormatDate(e.email_scheduled_on, Lib.outputDateFormat),
                    email_send_date = Lib.FormatDate(e.email_send_date, Lib.outputDateFormat),
                    email_status = e.email_status,
                    email_error_msg = e.email_error_msg,
                    email_remarks = e.email_remarks,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
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
        
        // public async Task<email_jobs_dto> GetDefaultData()
        // {
        //     try
        //     {
        //         IQueryable<mast_param> query = context.mast_param;

        //         query = query.Where(f => f.param_type == "SHIPSTAGE-OTH" && f.param_name == "NIL");

        //         var Record = await query.Select(e => new email_jobs_dto
        //         {
        //             email_shipment_stage_id = e.param_id,
        //             email_shipment_stage_name = e.param_name,
        //         }).FirstOrDefaultAsync();

        //         if (Record == null)
        //             throw new Exception("Shipment Stage 'NIL' not found.");

        //         return Record;
        //     }
        //     catch (Exception Ex)
        //     {
        //         throw new Exception(Ex.Message.ToString());
        //     }
        // }

        public async Task<email_jobs_dto> SaveAsync(int id, string mode, email_jobs_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                email_jobs_dto _Record = await SaveParentAsync(id, mode, record_dto);

                context.Database.CommitTransaction();
                return _Record;
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


        private Boolean AllValid(string mode, email_jobs_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            string type = "";
            string cntr_no = "";
            string unit = "";

            // if (Lib.IsBlank(record_dto.email_handled_name))
            //     str += "Handled By Cannot Be Blank!";

            if (type != "")
                str += type;
            if (cntr_no != "")
                str += cntr_no;
            if (unit != "")
                str += unit;
            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<email_jobs_dto> SaveParentAsync(int id, string mode, email_jobs_dto record_dto)
        {
            email_jobs? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new email_jobs();

                    // Record.mbl_cfno = iNextNo;
                    // Record.mbl_refno = semail_no;
                    // Record.mbl_mode = stype;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.email_jobs
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                }

                Record.email_from_id = record_dto.email_from_id;
                Record.email_to_id = record_dto.email_to_id;
                Record.email_cc_id = record_dto.email_cc_id;
                Record.email_bcc_id = record_dto.email_bcc_id;
                Record.email_subject = record_dto.email_subject;
                Record.email_message = record_dto.email_message;
                Record.email_file_folder = record_dto.email_file_folder;
                Record.email_ctr = record_dto.email_ctr;
                
                Record.email_scheduled_on = Lib.ParseDate(record_dto.email_scheduled_on!);
                Record.email_send_date = Lib.ParseDate(record_dto.email_send_date!);
                Record.email_status = record_dto.email_status;
                Record.email_error_msg = record_dto.email_error_msg;
                Record.email_remarks = record_dto.email_remarks;

                if (mode == "add")
                    await context.email_jobs.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.email_id = Record.email_id;

                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);

                record_dto.rec_version = Record.rec_version;

                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
                // throw;
            }

        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.email_jobs
                    .FirstOrDefaultAsync(f => f.email_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    context.Remove(_Record);
                    context.SaveChanges();

                    context.Database.CommitTransaction();

                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }

        // public filesm ProcessPdfFileAsync(List<email_jobs_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        // {
        //     var Dt_List = Records;
        //     if (Dt_List.Count <= 0)
        //         throw new Exception("Print List Records error");

        //     OtherOpPdfFile bc = new OtherOpPdfFile
        //     {
        //         Dt_List = Dt_List,
        //         Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //         Title = title,
        //         Company_id = company_id,
        //         Branch_id = branch_id,
        //         context = context,
        //         User_name = user_name,
        //         Mbl_type = title,
        //         FromDate = searchInfo.ContainsKey("email_from_date") ? searchInfo["email_from_date"] : "",
        //         ToDate = searchInfo.ContainsKey("email_to_date") ? searchInfo["email_to_date"] : "",
        //         RefNo = searchInfo.ContainsKey("email_refno") ? searchInfo["email_refno"] : "",

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
        // public filesm ProcessExcelFileAsync(List<email_jobs_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        // {
        //     var Dt_List = Records;
        //     if (Dt_List.Count <= 0)
        //         throw new Exception("Excel List Records error");

        //     ProcessOtherOpExcelFile bc = new ProcessOtherOpExcelFile
        //     {
        //         Dt_List = Dt_List,
        //         report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //         Title = title,
        //         Company_id = company_id,
        //         Branch_id = branch_id,
        //         context = context,
        //         User_name = user_name,
        //         Mbl_type = title,
        //         FromDate = searchInfo.ContainsKey("email_from_date") ? searchInfo["email_from_date"] : "",
        //         ToDate = searchInfo.ContainsKey("email_to_date") ? searchInfo["email_to_date"] : "",
        //         RefNo = searchInfo.ContainsKey("email_refno") ? searchInfo["email_refno"] : "",

        //     };
        //     bc.Process();

        //     if (bc.fList == null || !bc.fList.Any())
        //         throw new Exception("Excel generation failed.");

        //     var file = bc.fList[0];

        //     var record = new filesm
        //     {
        //         filepath = file.filename!,
        //         filename = file.filedisplayname!,
        //         filetype = file.filetype!
        //     };
        //     return record;
        // }
    }
}
