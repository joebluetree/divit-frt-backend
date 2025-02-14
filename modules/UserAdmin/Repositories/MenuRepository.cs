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
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;

        public MenuRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var menu_name = data["menu_name"].ToString();
                var menu_visible = data["menu_visible"].ToString();
                var module_id = int.Parse(data["module_id"].ToString()!);
                var company_id = int.Parse(data["rec_company_id"].ToString()!);


                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_menum> query = context.mast_menum; //.Include(m => m.module);

                query = query.Where(w => w.rec_company_id == company_id);

                if (menu_name != "" && menu_name != null)
                    query = query.Where(w => w.menu_name!.Contains(menu_name));

                if (module_id != 0)
                    query = query.Where(w => w.menu_module_id == module_id);

                if (menu_visible != "NA")
                    query = query.Where(w => w.menu_visible == menu_visible);

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
                    .OrderBy(c => c.menu_order)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_menum_dto
                {
                    menu_id = e.menu_id,
                    menu_module_id = e.menu_module_id,
                    menu_code = e.menu_code,
                    menu_name = e.menu_name,
                    menu_route = e.menu_route,
                    menu_param = e.menu_param,

                    menu_visible = e.menu_visible,

                    menu_submenu_id = e.menu_submenu_id,
                    menu_submenu_name = e.submenu!.module_name,

                    menu_order = e.menu_order,
                    menu_module_name = e.module!.module_name,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),



                }).ToListAsync();

                RetData.Add("records", Records);
                RetData.Add("page", _page);

                //menu_submenu_id = e.menu_submenu_id,
                //menu_submenu_name = e.submenu.module_name,

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<mast_menum_dto?> GetRecordAsync(int id)
        {
            try
            {

                IQueryable<mast_menum> query = context.mast_menum;//.Include(m => m.module);

                query = query.Where(f => f.menu_id == id);

                var Record = await query.Select(e => new mast_menum_dto
                {
                    menu_id = e.menu_id,
                    menu_module_id = e.menu_module_id,
                    menu_module_name = e.module!.module_name,
                    menu_code = e.menu_code,
                    menu_name = e.menu_name,
                    menu_route = e.menu_route,
                    menu_param = e.menu_param,
                    menu_visible = e.menu_visible,
                    menu_submenu_id = e.menu_submenu_id,
                    menu_submenu_name = e.submenu!.module_name,
                    menu_order = e.menu_order,
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

        public async Task<mast_menum_dto> SaveAsync(int id, string mode, mast_menum_dto record_dto)
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

        private Boolean AllValid(string mode, mast_menum_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";

            if (Lib.IsBlank(record_dto.menu_code))
                str += "Code Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.menu_name))
                str += "Name Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }


        public async Task<mast_menum_dto> SaveParentAsync(int id, string mode, mast_menum_dto record_dto)
        {
            mast_menum? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found To Save");
                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new mast_menum();
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {

                    Record = await context.mast_menum.Include(c => c.module)
                        .Where(f => f.menu_id == id)
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

                Record.menu_code = record_dto.menu_code;
                Record.menu_name = record_dto.menu_name;
                Record.menu_route = record_dto.menu_route;
                Record.menu_param = record_dto.menu_param;
                Record.menu_visible = record_dto.menu_visible;
                Record.menu_module_id = record_dto.menu_module_id;
                if (Lib.IsZero(record_dto.menu_submenu_id))
                    Record.menu_submenu_id = null;
                else
                    Record.menu_submenu_id = record_dto.menu_submenu_id;
                Record.menu_order = record_dto.menu_order;

                if (mode == "add")
                    await context.mast_menum.AddAsync(Record);

                context.SaveChanges();
                record_dto.menu_id = Record.menu_id;
                record_dto.rec_version = Record.rec_version;
                Lib.AssignDates2DTO(id, mode, Record, record_dto);
                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "menu_name", "Code Duplication");
                Lib.getErrorMessage(Ex, "fk", "menu_module_id", "Invalid Module");
                Lib.getErrorMessage(Ex, "fk", "rec_company_id", "Invalid Company");
                throw;
            }
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_menum
                    .Where(f => f.menu_id == id)
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
        public async Task logHistory(mast_menum old_record, mast_menum_dto record_dto)
        {
            var old_record_dto = new mast_menum_dto
            {
                menu_id = old_record.menu_id,
                menu_code = old_record.menu_code,
                menu_name = old_record.menu_name,
                menu_route = old_record.menu_route,
                menu_param = old_record.menu_param,
                menu_module_id = old_record.menu_module_id,
                menu_submenu_id = old_record.menu_submenu_id,
            };

            await new LogHistorym<mast_menum_dto>(context)
                .Table("mast_menum", log_date)
                .PrimaryKey("menu_id", record_dto.menu_id)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0 , record_dto.rec_created_by!)
                .TrackColumn("menu_code", "code")
                .TrackColumn("menu_name", "name")
                .TrackColumn("menu_route", "routes")
                .TrackColumn("menu_param", "menu-param")
                .TrackColumn("menu_module_id", "module")
                .TrackColumn("menu_submenu_id", "sub-menu")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }

    }
}

