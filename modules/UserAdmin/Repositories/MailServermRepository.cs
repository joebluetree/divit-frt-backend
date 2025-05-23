using Database;
using Database.Lib;
using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.BaseTables;
using UserAdmin.Interfaces;
using Database.Models.UserAdmin;
using Common.DTO.UserAdmin;
using Common.Lib;


namespace UserAdmin.Repositories
{

    //Name : Alen Cherian
    //Date : 20/01/2025
    //Command :  Create Repository for the Mail Server Settings.

    public class MailServermRepository : IMailServermRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        public MailServermRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var mail_name = "";
                var company_id = 0;

                if (data.ContainsKey("mail_name"))
                    mail_name = data["mail_name"].ToString();

                if (data.ContainsKey("rec_company_id"))
                    company_id = int.Parse(data["rec_company_id"].ToString()!);
                if (company_id == 0)
                    throw new Exception("Company Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_mail_serverm> query = context.mast_mail_serverm;

                query = query.Where(i => i.rec_company_id == company_id);


                if (!Lib.IsBlank(mail_name))
                    query = query.Where(w => w.mail_name!.Contains(mail_name!));

                if (action == "SEARCH")
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
                    .OrderBy(c => c.mail_id)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_mail_serverm_dto
                {
                    mail_id = e.mail_id,
                    mail_name = e.mail_name,
                    mail_smtp_name = e.mail_smtp_name,
                    mail_smtp_port = e.mail_smtp_port,
                    mail_is_ssl = e.mail_is_ssl,
                    mail_is_auth = e.mail_is_auth,
                    mail_is_spa = e.mail_is_spa,
                    mail_bulk_tot = e.mail_bulk_tot,
                    mail_bulk_sub = e.mail_bulk_sub,
                    mail_smtp_username = e.mail_smtp_username,
                    mail_smtp_pwd = e.mail_smtp_pwd,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();

                RetData.Add("records", Records);
                RetData.Add("page", _page);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<mast_mail_serverm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mast_mail_serverm> query = context.mast_mail_serverm;
                query = query.Where(f => f.mail_id == id);

                var Record = await query.Select(e => new mast_mail_serverm_dto
                {
                    mail_id = e.mail_id,
                    mail_name = e.mail_name,
                    mail_smtp_name = e.mail_smtp_name,
                    mail_smtp_port = e.mail_smtp_port,
                    mail_is_ssl = e.mail_is_ssl,
                    mail_is_auth = e.mail_is_auth,
                    mail_is_spa = e.mail_is_spa,
                    mail_bulk_tot = e.mail_bulk_tot,
                    mail_bulk_sub = e.mail_bulk_sub,
                    mail_smtp_username = e.mail_smtp_username,
                    mail_smtp_pwd = e.mail_smtp_pwd,

                    rec_version = e.rec_version,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
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

        public async Task<mast_mail_serverm_dto> SaveAsync(int id, string mode, mast_mail_serverm_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                record_dto = await SaveParentAsync(id, mode, record_dto);
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
        private Boolean AllValid(string mode, mast_mail_serverm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            if (Lib.IsBlank(record_dto.mail_name))
                str += "Name Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mail_smtp_name))
                str += "Smtp Name Cannot Be Blank!";
            if (record_dto.mail_bulk_sub > record_dto.mail_bulk_tot)
                str += "Batch Split Count must be less than Bulkmail Batch Total.";


            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<mast_mail_serverm_dto> SaveParentAsync(int id, string mode, mast_mail_serverm_dto record_dto)
        {
            mast_mail_serverm? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {

                    Record = new mast_mail_serverm();
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.mast_mail_serverm
                        .Where(f => f.mail_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                if (mode == "edit")
                    await logHistory(Record, record_dto);

                Record.mail_name = record_dto.mail_name;
                Record.mail_smtp_name = record_dto.mail_smtp_name;
                Record.mail_smtp_port = record_dto.mail_smtp_port;
                Record.mail_is_ssl = record_dto.mail_is_ssl;
                Record.mail_is_auth = record_dto.mail_is_auth;
                Record.mail_is_spa = record_dto.mail_is_spa;
                Record.mail_bulk_tot = record_dto.mail_bulk_tot;
                Record.mail_bulk_sub = record_dto.mail_bulk_sub;
                Record.mail_smtp_username = record_dto.mail_smtp_username;
                Record.mail_smtp_pwd = record_dto.mail_smtp_pwd;
                if (mode == "add")
                    await context.mast_mail_serverm.AddAsync(Record);
                context.SaveChanges();
                record_dto.mail_id = Record.mail_id;
                record_dto.rec_version = Record.rec_version;
                //Lib.AssignDates2DTO(id, mode, Record, record_dto);
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.mail_id != 0)
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }

                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "mail_name", "Name Duplication");
                throw;
            }
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_mail_serverm
                    .Where(f => f.mail_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    context.Remove(_Record);
                    await context.SaveChangesAsync();

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

        public async Task logHistory(mast_mail_serverm old_record, mast_mail_serverm_dto record_dto)
        {

            var old_record_dto = new mast_mail_serverm_dto
            {
                mail_id = old_record.mail_id,
                mail_name = old_record.mail_name,
                mail_smtp_name = old_record.mail_smtp_name,
                mail_smtp_port = old_record.mail_smtp_port,
                mail_is_ssl = old_record.mail_is_ssl,
                mail_is_auth = old_record.mail_is_auth,
                mail_is_spa = old_record.mail_is_spa,
                mail_bulk_tot = old_record.mail_bulk_tot,
                mail_bulk_sub = old_record.mail_bulk_sub,
                mail_smtp_username = old_record.mail_smtp_username,
                mail_smtp_pwd = old_record.mail_smtp_pwd,

            };

            await new LogHistorym<mast_mail_serverm_dto>(context)
                .Table("mast_mail_serverm", log_date)
                .PrimaryKey("mail_id", record_dto.mail_id)
                .RefNo(record_dto.mail_name!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("mail_name", "Name")
                .TrackColumn("mail_smtp_name", "SMTP Name")
                .TrackColumn("mail_smtp_port", "Smtp Port ")
                .TrackColumn("mail_is_ssl", "Require SSL")
                .TrackColumn("mail_is_auth", "Mail Authorization")
                .TrackColumn("mail_is_spa", "Secured Pwd Authentication")
                .TrackColumn("mail_bulk_tot", "Bulkmail Batch Total")
                .TrackColumn("mail_bulk_sub", "Batch Split Count")
                .TrackColumn("mail_smtp_username", "Smtp User")
                .TrackColumn("mail_smtp_pwd", "Smtp Password")


                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }

    }
}
