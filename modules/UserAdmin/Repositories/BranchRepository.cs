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
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;

        public BranchRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var branch_name = data["branch_name"].ToString();
                var company_id = int.Parse(data["rec_company_id"].ToString()!);

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_branchm> query = context.mast_branchm;
                query = query.Where(w => w.rec_company_id == company_id);

                if (branch_name != "" && branch_name != null)
                    query = query.Where(w => w.branch_name!.Contains(branch_name));


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
                    .OrderBy(c => c.branch_name)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_branchm_dto
                {
                    branch_id = e.branch_id,
                    branch_code = e.branch_code,
                    branch_name = e.branch_name,
                    branch_address1 = e.branch_address1,
                    branch_address2 = e.branch_address2,
                    branch_address3 = e.branch_address3,
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
        public async Task<mast_branchm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mast_branchm> query = context.mast_branchm;
                query = query.Where(f => f.branch_id == id);

                var Record = await query.Select(e => new mast_branchm_dto
                {
                    branch_id = e.branch_id,
                    branch_code = e.branch_code,
                    branch_name = e.branch_name,
                    branch_address1 = e.branch_address1,
                    branch_address2 = e.branch_address2,
                    branch_address3 = e.branch_address3,
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

        public async Task<mast_branchm_dto> SaveAsync(int id, string mode, mast_branchm_dto record_dto)
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

        private Boolean AllValid(string mode, mast_branchm_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";

            if (Lib.IsBlank(record_dto.branch_code))
                str += "Code Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.branch_name))
                str += "Name Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }





        public async Task<mast_branchm_dto> SaveParentAsync(int id, string mode, mast_branchm_dto record_dto)
        {
            mast_branchm? Record;
            string error = "";

            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found To Save");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);


                if (mode == "add")
                {
                    Record = new mast_branchm();
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.mast_branchm
                        .Where(f => f.branch_id == id)
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

                Record.branch_code = record_dto.branch_code;
                Record.branch_name = record_dto.branch_name;
                Record.branch_address1 = record_dto.branch_address1;
                Record.branch_address2 = record_dto.branch_address2;
                Record.branch_address3 = record_dto.branch_address3;

                if (mode == "add")
                    await context.mast_branchm.AddAsync(Record);

                context.SaveChanges();
                record_dto.branch_id = Record.branch_id;
                record_dto.rec_version = Record.rec_version;
                // Lib.AssignDates2DTO(id, mode, Record, record_dto);
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.branch_id != 0)
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }
                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "branch_code", "Code Duplication");
                Lib.getErrorMessage(Ex, "uq", "branch_name", "Name Duplication");
                Lib.getErrorMessage(Ex, "fk", "rec_company_id", "Invalid Company ID");
                throw;
            }
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_branchm
                    .Where(f => f.branch_id == id)
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
        public async Task logHistory(mast_branchm old_record, mast_branchm_dto record_dto)
        {
            var old_record_dto = new mast_branchm_dto
            {
                branch_id = old_record.branch_id,
                branch_code = old_record.branch_code,
                branch_name = old_record.branch_name,
                branch_address1 = old_record.branch_address1,
                branch_address2 = old_record.branch_address2,
                branch_address3 = old_record.branch_address3,
            };

            await new LogHistorym<mast_branchm_dto>(context)
                .Table("mast_branchm", log_date)
                .PrimaryKey("branch_id", record_dto.branch_id)
                .RefNo(record_dto.branch_name!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("branch_code", "code")
                .TrackColumn("branch_name", "name")
                .TrackColumn("branch_address1", "address 1")
                .TrackColumn("branch_address2", "address 2")
                .TrackColumn("branch_address3", "address 3")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }

    }
}
