//using Database;
using Database.Lib;
using Microsoft.EntityFrameworkCore;
using Common.UserAdmin.DTO;
using UserAdmin.Interfaces;
using Database.Lib.Interfaces;

using Database.Models.BaseTables;
using Database.Models.UserAdmin;
using Database;

using Common.Lib;

namespace UserAdmin.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;

        public UserRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var user_name = data["user_name"].ToString();
                var user_is_admin = data["user_is_admin"].ToString();
                var company_id = int.Parse(data["rec_company_id"].ToString()!);

                var global_user_code = data["global_user_code"].ToString()!.ToUpper();

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_userm> query = context.mast_userm.Include(e => e.branch);
                query = query.Where(w => w.rec_company_id == company_id);

                if (user_name != "" && user_name != null)
                    query = query.Where(w => w.user_name!.Contains(user_name));

                if (global_user_code != "ADMIN")
                    query = query.Where(w => w.user_code != "ADMIN");

                if (user_is_admin == "N")
                    query = query.Where(w => w.user_is_admin == "N");

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
                    .OrderBy(c => c.user_name)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_userm_dto
                {
                    user_id = e.user_id,
                    user_code = e.user_code,
                    user_name = e.user_name,
                    user_is_admin = e.user_is_admin,
                    user_email = e.user_email,
                    user_password = e.user_password,
                    rec_branch_id = e.rec_branch_id,
                    rec_branch_name = e.branch!.branch_name,

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
        public async Task<mast_userm_dto?> GetRecordAsync(int comp_id, int id)
        {
            try
            {
                IQueryable<mast_userm> query = context.mast_userm.Include(e => e.branch);
                query = query.Where(f => f.user_id == id);

                var Record = await query.Select(e => new mast_userm_dto
                {
                    user_id = e.user_id,
                    user_code = e.user_code,
                    user_name = e.user_name,
                    user_is_admin = e.user_is_admin,
                    user_email = e.user_email,
                    user_password = e.user_password,
                    rec_company_id = e.rec_company_id,
                    rec_branch_id = e.rec_branch_id,
                    rec_branch_name = e.branch!.branch_name,
                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),



                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                var records = await this.GetuserBranchesAsync(comp_id, id);

                Record.userbranches = records;

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<mast_userbranches_dto>> GetuserBranchesAsync(int comp_id, int id)
        {

            try {
            var query = (from a in context.mast_branchm
                         from b in context.mast_userbranches
                         .Include(c => c.user)
                         .Where(b =>
                               a.rec_company_id == b.rec_company_id
                               && a.branch_id == b.rec_branch_id
                               && b.ub_user_id == id).DefaultIfEmpty()
                         where a.rec_company_id == comp_id
                         select (new mast_userbranches_dto
                         {
                             ub_id = b.ub_id,
                             ub_user_id = id,
                             ub_user_name = "",
                             ub_selected = b.ub_id == null ? "N" : "Y",
                             rec_branch_id = a.branch_id,
                             rec_company_id = a.rec_company_id,
                             rec_branch_name = a.branch_name,
                             rec_created_by = b.rec_created_by,
                             rec_created_date = b.rec_created_date.ToString(Lib.outputDateTimeFormat),
                             rec_edited_by = b.rec_edited_by,
                             rec_edited_date = b.rec_edited_date.HasValue ? b.rec_edited_date.Value.ToString(Lib.outputDateTimeFormat) : null,
                         }));


            var Record = await query.ToListAsync();

            //var sql = query.ToQueryString();

            return Record;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<mast_userm_dto> SaveAsync(int id, string mode, mast_userm_dto record_dto)
        {
            try
            {
                log_date = DateTime.UtcNow;

                context.Database.BeginTransaction();
                mast_userm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await SaveDetAsync(_Record.user_id, _Record);
                _Record.userbranches = await GetuserBranchesAsync(_Record.rec_company_id, id);
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


        private Boolean AllValid(string mode, mast_userm_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";

            if (Lib.IsBlank(record_dto.user_code))
                str += "Code Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.user_name))
                str += "Name Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }


        public async Task<mast_userm_dto> SaveParentAsync(int id, string mode, mast_userm_dto record_dto)
        {
            mast_userm? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found To Save");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new mast_userm();
                    Record.user_id = record_dto.user_id;
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.mast_userm
                        .Where(f => f.user_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("No Record Found");

                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                }
                if (mode == "edit")
                    await logHistory(Record, record_dto);

                Record.user_code = record_dto.user_code;
                Record.user_name = record_dto.user_name;
                Record.user_email = record_dto.user_email;
                Record.user_password = record_dto.user_password;
                Record.user_is_admin = record_dto.user_is_admin;
                Record.rec_branch_id = record_dto.rec_branch_id;

                if (mode == "add")
                    await context.mast_userm.AddAsync(Record);

                context.SaveChanges();
                record_dto.user_id = Record.user_id;
                record_dto.rec_version = Record.rec_version;
                // Lib.AssignDates2DTO(id, mode, Record, record_dto);
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.user_id != 0)
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }
                return record_dto;
            }

            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "user_code", "Code Duplication");
                Lib.getErrorMessage(Ex, "uq", "user_name", "Name Duplication");
                Lib.getErrorMessage(Ex, "fk", "rec_branch_id", "Default Branch Not Selected");
                throw;
            }
        }

        public async Task<mast_userm_dto> SaveDetAsync(int id, mast_userm_dto Record_DTO)
        {
            // mast_userbranches Record;
            List<mast_userbranches_dto> RecordDet_DTO;
            List<mast_userbranches> RecordDet;
            // int ub_id = 0;
            Boolean bDelete = false;
            try
            {
                if (Record_DTO == null)
                    throw new Exception("No Detail Data Found To Save");

                RecordDet_DTO = Record_DTO.userbranches!;

                RecordDet = await context.mast_userbranches
                    .Where(f => f.ub_user_id == id)
                    .ToListAsync();

                foreach (var Record_Old in RecordDet)
                {
                    bDelete = false;
                    var Rec = RecordDet_DTO.Find(f => f.ub_id == Record_Old.ub_id);
                    if (Rec == null)
                        bDelete = true;
                    else if (Rec.ub_selected == "N")
                        bDelete = true;
                    if (bDelete)
                        context.mast_userbranches.Remove(Record_Old);
                }
                foreach (var Record_New in RecordDet_DTO)
                {
                    if (Record_New.ub_selected == "N")
                    {
                        Record_New.ub_id = 0;
                        // continue; 
                    }
                    if (Record_New.ub_id == 0 && Record_New.ub_selected == "Y")
                    {
                        var Record = new mast_userbranches
                        {
                            // ub_id = 0,
                            ub_user_id = id,
                            rec_branch_id = Record_New.rec_branch_id,
                            rec_company_id = Record_DTO.rec_company_id,
                            rec_created_by = Record_DTO.rec_created_by,
                            rec_created_date = DbLib.GetDateTime(),
                            rec_locked = "N"
                        };
                        context.mast_userbranches.Add(Record);

                        await context.SaveChangesAsync();
                        Record_New.ub_id = Record.ub_id;
                    }
                context.SaveChanges();
                }
                // RecordDet_DTO.ub_id = Record.ub_id;
                //Lib.AssignDates2DTO(id, Record, Record_DTO);
                return Record_DTO;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "user_code", "Name Duplication");
                Lib.getErrorMessage(Ex, "uq", "user_name", "Name Duplication");
                
                Lib.getErrorMessage(Ex, "fk", "rec_company_code", "Invalid Company ID");

                throw;
            }
        }


        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_userm
                    .Where(f => f.user_id == id)
                    .FirstOrDefaultAsync();
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else if (_Record.user_code!.ToUpper() == "ADMIN")
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "Cannot Delete ADMIN User");
                }
                else
                {
                    var _Contact = context.mast_userbranches
                    .Where(c => c.ub_user_id == id);
                    if (_Contact.Any())
                    {
                        context.mast_userbranches.RemoveRange(_Contact);

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
        public async Task logHistory(mast_userm old_record, mast_userm_dto record_dto)
        {
            var old_record_dto = new mast_userm_dto
            {
                user_id = old_record.user_id,
                user_code = old_record.user_code,
                user_name = old_record.user_name,
                user_email = old_record.user_email,
                user_password = old_record.user_password,
                user_is_admin = old_record.user_is_admin,
                rec_branch_id = old_record.rec_branch_id
            };

            await new LogHistorym<mast_userm_dto>(context)
                .Table("mast_userm", log_date)
                .PrimaryKey("user_id", record_dto.user_id)
                .RefNo(record_dto.user_name!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0 , record_dto.rec_created_by!)
                .TrackColumn("user_code", "code")
                .TrackColumn("user_name", "name")
                .TrackColumn("user_email", "email")
                .TrackColumn("user_password", "password")
                .TrackColumn("user_is_admin", "admin")
                .TrackColumn("rec_branch_id", "branch-id")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }

    }
}
