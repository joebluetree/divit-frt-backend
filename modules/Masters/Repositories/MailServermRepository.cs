using Database;
using Database.Lib;
using Common.DTO.Masters;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Database.Models.Marketing;
using Common.DTO.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Masters.Interfaces;


namespace Marketing.Repositories
{

    //Name : Alen Cherian
    //Date : 03/01/2025
    //Command :  Create Repository for the Quotation Fcl.

    public class MailServermRepository : IMailServermRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
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


                query = query.Where(f => f. mail_id == id );

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
                    throw new Exception("No Qtn Found");

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
                context.Database.BeginTransaction();
                mast_mail_serverm_dto _Record = await SaveParentAsync(id, mode, record_dto);
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


        private Boolean AllValid(string mode, mast_mail_serverm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            if (Lib.IsBlank(record_dto.mail_name))
                str += "Name Date Cannot Be Blank!";


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
                Lib.AssignDates2DTO(id, mode, Record, record_dto);
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }

        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mark_qtnm
                    .Where(f => f.qtnm_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    var Qtnd_Fcl = context.mark_qtnd_fcl
                     .Where(c => c.qtnd_qtnm_id == id);
                    if (Qtnd_Fcl.Any())
                    {
                        context.mark_qtnd_fcl.RemoveRange(Qtnd_Fcl);

                    }
                    context.Remove(_Record);
                    context.SaveChanges();
                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

    }
}
