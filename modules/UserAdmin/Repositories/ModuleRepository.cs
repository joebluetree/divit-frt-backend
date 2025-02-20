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
    public class ModuleRepository : IModuleRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        public ModuleRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var module_name = data["module_name"].ToString();
                var module_is_installed = data["module_is_installed"].ToString();
                var company_id = int.Parse(data["rec_company_id"].ToString()!);

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_modulem> query = context.mast_modulem;

                query = query.Where(w => w.rec_company_id == company_id);

                if (module_name != "" && module_name != null)
                    query = query.Where(w => w.module_name!.Contains(module_name));

                if (module_is_installed != "NA")
                    query = query.Where(w => w.module_is_installed == module_is_installed);

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
                    .OrderBy(c => c.module_order)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_modulem_dto
                {
                    module_id = e.module_id,
                    module_name = e.module_name,
                    module_is_installed = e.module_is_installed,

                    module_parent_id = e.module_parent_id,
                    module_parent_name = e.module!.module_name,

                    module_order = e.module_order,

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
        public async Task<mast_modulem_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mast_modulem> query = context.mast_modulem;

                query = query.Where(f => f.module_id == id);

                var Record = await query.Select(e => new mast_modulem_dto
                {
                    module_id = e.module_id,
                    module_name = e.module_name,
                    module_is_installed = e.module_is_installed,
                    module_parent_id = e.module_parent_id,
                    module_parent_name = e.module!.module_name,
                    module_order = e.module_order,
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

        public async Task<mast_modulem_dto> SaveAsync(int id, string mode, mast_modulem_dto record_dto)
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

        private Boolean AllValid(string mode, mast_modulem_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";


            if (Lib.IsBlank(record_dto.module_name))
                str += "Name Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }


        public async Task<mast_modulem_dto> SaveParentAsync(int id, string mode, mast_modulem_dto record_dto)
        {
            mast_modulem? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found To Save");
                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new mast_modulem();
                    Record.module_id = record_dto.module_id;
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.mast_modulem
                        .Include(c => c.module)
                        .Where(f => f.module_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("No Record Found");

                    //context.Entry(Record).Property(p => p.rec_version).OriginalValue = Record_DTO.rec_version;
                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                if (mode == "edit")
                    await logHistory(Record, record_dto);

                Record.module_name = record_dto.module_name;
                Record.module_is_installed = record_dto.module_is_installed;

                if (Lib.IsZero(record_dto.module_parent_id))
                    Record.module_parent_id = null;
                else
                    Record.module_parent_id = record_dto.module_parent_id;

                Record.module_order = record_dto.module_order;
                if (mode == "add")
                    await context.mast_modulem.AddAsync(Record);
                context.SaveChanges();
                record_dto.module_id = Record.module_id;
                record_dto.rec_version = Record.rec_version;
                // Lib.AssignDates2DTO(id, mode, Record, record_dto);
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.module_id != 0)
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }
                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "module_name", "Module Name Duplication");
                Lib.getErrorMessage(Ex, "fk", "rec_company_id", "Invalid Company ID");
                throw;
            }
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>
                {
                    { "id", id }
                };
                var _Record = await context.mast_modulem
                    .Where(f => f.module_id == id)
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
        public async Task logHistory(mast_modulem old_record, mast_modulem_dto record_dto)
        {
            var old_record_dto = new mast_modulem_dto
            {
                module_id = old_record.module_id,
                module_name = old_record.module_name,
                module_parent_name = old_record.module?.module_name,
                module_is_installed = old_record.module_is_installed
            };

            await new LogHistorym<mast_modulem_dto>(context)
                .Table("mast_modulem", log_date)
                .PrimaryKey("module_id", record_dto.module_id)
                .RefNo(record_dto.module_name!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0 , record_dto.rec_created_by!)
                .TrackColumn("module_parent_name", "Parent")
                .TrackColumn("module_name", "Name")
                .TrackColumn("module_is_installed", "Visible")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }
    }
}
