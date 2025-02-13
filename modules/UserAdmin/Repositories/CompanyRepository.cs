using Database;
using Database.Lib;
using Microsoft.EntityFrameworkCore;


using Common.UserAdmin.DTO;
using UserAdmin.Interfaces;

using Database.Lib.Interfaces;

using Database.Models.BaseTables;
using Database.Models.UserAdmin;

using Common.Lib;

namespace UserAdmin.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;

        private DateTime log_date;



        public CompanyRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var comp_name = data["comp_name"].ToString();

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_companym> query = context.mast_companym;

                if (comp_name != "" && comp_name != null)
                    query = query.Where(w => w.comp_name!.Contains(comp_name));


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
                    .OrderBy(c => c.comp_name)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_companym_dto
                {
                    comp_id = e.comp_id,
                    comp_code = e.comp_code,
                    comp_name = e.comp_name,
                    comp_address1 = e.comp_address1,
                    comp_address2 = e.comp_address2,
                    comp_address3 = e.comp_address3,

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
        public async Task<mast_companym_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mast_companym> query = context.mast_companym;
                query = query.Where(f => f.comp_id == id);

                var Record = await query.Select(e => new mast_companym_dto
                {
                    comp_id = e.comp_id,
                    comp_code = e.comp_code,
                    comp_name = e.comp_name,
                    comp_address1 = e.comp_address1,
                    comp_address2 = e.comp_address2,
                    comp_address3 = e.comp_address3,
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

        public async Task<mast_companym_dto> SaveAsync(int id, string mode, mast_companym_dto record_dto)
        {
            try
            {
                log_date = DateTime.UtcNow;

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

        private Boolean AllValid(string mode, mast_companym_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";

            if (Lib.IsBlank(record_dto.comp_code))
                str += "Code Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.comp_name))
                str += "Name Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }





        public async Task<mast_companym_dto> SaveParentAsync(int id, string mode, mast_companym_dto record_dto)
        {
            mast_companym? Record;
            string error = "";

            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found To Save");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new mast_companym();
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.mast_companym
                        .Where(f => f.comp_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("No Record Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;

                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }

                if (mode == "edit")
                    await logHistory(Record, record_dto);



                Record.comp_code = record_dto.comp_code;
                Record.comp_name = record_dto.comp_name;
                Record.comp_address1 = record_dto.comp_address1;
                Record.comp_address2 = record_dto.comp_address2;
                Record.comp_address3 = record_dto.comp_address3;

                if (mode == "add")
                    await context.mast_companym.AddAsync(Record);

                context.SaveChanges();
                record_dto.comp_id = Record.comp_id;
                record_dto.rec_version = Record.rec_version;
                Lib.AssignDates2DTO(id, mode, Record, record_dto);
                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "comp_code", "Code Duplication");
                Lib.getErrorMessage(Ex, "uq", "comp_name", "Name Duplication");
                throw;
            }
        }

        public async Task logHistory(mast_companym old_record, mast_companym_dto record_dto)
        {

            var old_record_dto = new mast_companym_dto
            {
                comp_id = old_record.comp_id,
                comp_code = old_record.comp_code,
                comp_name = old_record.comp_name,
                comp_address1 = old_record.comp_address1,
                comp_address2 = old_record.comp_address2,
                comp_address3 = old_record.comp_address3,
            };

            await new LogHistorym<mast_companym_dto>(context)
                .Table("mast_companym", log_date)
                .PrimaryKey("comp_id", record_dto.comp_id)
                .SetCompanyInfo(record_dto.rec_version, record_dto.comp_id, 0, record_dto.rec_created_by!)
                .TrackColumn("comp_code", "company-code")
                .TrackColumn("comp_name", "company-name")
                .TrackColumn("comp_address1", "company-address1")
                .TrackColumn("comp_address2", "company-address2")
                .TrackColumn("comp_address3", "company-address3")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }




        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_companym
                    .Where(f => f.comp_id == id)
                    .FirstOrDefaultAsync();
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
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
