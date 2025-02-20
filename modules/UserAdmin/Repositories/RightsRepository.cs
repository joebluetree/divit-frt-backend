using Database;
using Database.Lib;
using Microsoft.EntityFrameworkCore;
using Common.UserAdmin.DTO;
using UserAdmin.Interfaces;
using Database.Lib.Interfaces;

using Database.Models.BaseTables;
using Database.Models.UserAdmin;

namespace UserAdmin.Repositories
{
    public class RightsRepository : IRightsRepository
    {


        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public RightsRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var company_id = int.Parse(data["rec_company_id"].ToString()!);

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_userbranches> query = context.mast_userbranches
                    .Include(e => e.branch)
                    .Include(e => e.user);

                query = query.Where(w => w.rec_company_id == company_id);

                if (user_name != "" && user_name != null)
                    query = query.Where(w => w.user!.user_name!.Contains(user_name));

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
                    .OrderBy(c => c.user!.user_name)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_userbranches_dto
                {
                    ub_id = e.ub_id,
                    ub_user_id = e.ub_user_id,
                    ub_user_name = e.user!.user_name,
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

        public async Task<rights_header_dto> GetRecordAsync(int id)
        {
            try
            {

                var userbranch = await context.mast_userbranches.
                                Where(a => a.ub_id == id).
                                Select(a => new rights_header_dto
                                {
                                    id = a.ub_id,
                                    comp_id = a.rec_company_id,
                                    branch_id = (int)a.rec_branch_id!,
                                    user_id = a.ub_user_id
                                }).SingleOrDefaultAsync();

                var query = from a in context.mast_menum
                            from b in context.mast_rightsm.Where(w =>
                                a.menu_id == w.rights_menu_id
                                && w.rec_company_id == userbranch!.comp_id
                                && w.rec_branch_id == userbranch.branch_id
                                && w.rights_user_id == userbranch.user_id
                                ).DefaultIfEmpty()

                            select (new mast_rightsm_dto
                            {
                                rights_menu_id = a.menu_id,
                                rights_menu_name = a.menu_name,
                                rights_module_name = a.module!.module_name,
                                rights_module_order = a.module.module_order,
                                rights_menu_order = a.menu_order,
                                rights_id = (int)Lib.ISNULL(b.rights_id, 0),
                                rights_parent_id = userbranch!.id,
                                rights_selected = b.rights_company == null ? "N" : "Y",
                                rights_company = (string)Lib.ISNULL(b.rights_company!, "N"),
                                rights_admin = (string)Lib.ISNULL(b.rights_admin!, "N"),
                                rights_add = (string)Lib.ISNULL(b.rights_add!, "N"),
                                rights_edit = (string)Lib.ISNULL(b.rights_edit!, "N"),
                                rights_delete = (string)Lib.ISNULL(b.rights_delete!, "N"),
                                rights_view = (string)Lib.ISNULL(b.rights_view!, "N"),
                                rights_print = (string)Lib.ISNULL(b.rights_print!, "N"),
                                rights_doc_upload = (string)Lib.ISNULL(b.rights_doc_upload!, "N"),
                                rights_doc_view = (string)Lib.ISNULL(b.rights_doc_view!, "N"),
                                rights_approver = (string)Lib.ISNULL(b.rights_approver!, "N"),
                                rights_value = (string)Lib.ISNULL(b.rights_value!, ""),
                                rec_company_id = userbranch.comp_id,
                                rec_branch_id = userbranch.branch_id
                            });


                var Records = await query.
                    OrderBy(o => o.rights_module_name).
                    ToListAsync();

                userbranch!.records = Records;

                return userbranch;

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
                var _Record = await context.mast_rightsm
                    .Where(f => f.rights_id == id)
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

        public async Task<rights_header_dto> SaveAsync(int id, string mode, rights_header_dto record_dto)
        {
            try
            {
                context.Database.BeginTransaction();
                record_dto = await SaveParentAsync(id, mode, record_dto);
                context.Database.CommitTransaction();
                return record_dto;
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }


        public async Task<rights_header_dto> SaveParentAsync(int id, string mode, rights_header_dto record_dto)
        {
            mast_rightsm? Record;
            List<mast_rightsm_dto> recordDet_dto;
            List<mast_rightsm> RecordDet;

            Boolean bDelete = false;

            try
            {
                if (record_dto == null)
                    throw new Exception("No Detail Data Found To Save");

                recordDet_dto = record_dto.records!;

                RecordDet = await context.mast_rightsm
                .Where(f => f.rights_parent_id == id)
                .ToListAsync();

                foreach (var Record_Old in RecordDet)
                {
                    bDelete = false;
                    var Rec = recordDet_dto.Find(f => f.rights_id == Record_Old.rights_id);
                    if (Rec == null)
                        bDelete = true;
                    else if (Rec.rights_selected == "N")
                        bDelete = true;
                    if (bDelete)
                        context.mast_rightsm.Remove(Record_Old);
                }

                foreach (var Record_New in recordDet_dto)
                {
                    if (Record_New.rights_selected == "Y")
                    {
                        if (Record_New.rights_id == 0)
                        {
                            Record = new mast_rightsm();
                            Record.rights_id = 0;
                            Record.rights_parent_id = id;
                            Record.rec_company_id = Record_New.rec_company_id;
                            Record.rec_branch_id = Record_New.rec_branch_id;
                            Record.rights_user_id = record_dto.user_id;
                            Record.rec_created_by = Record_New.rec_created_by;
                            Record.rec_created_date = DbLib.GetDateTime();
                            await context.mast_rightsm.AddAsync(Record);
                        }
                        else
                        {
                            Record = RecordDet.Find(f => f.rights_id == Record_New.rights_id);
                            if (Record == null)
                                throw new Exception("No Records Found");

                            Record.rec_edited_by = Record_New.rec_created_by;
                            Record.rec_edited_date = DbLib.GetDateTime();
                        }
                        Record.rights_menu_id = Record_New.rights_menu_id;
                        Record.rights_admin = Record_New.rights_admin;
                        Record.rights_company = Record_New.rights_company;

                        Record.rights_add = Record_New.rights_add;
                        Record.rights_edit = Record_New.rights_edit;
                        Record.rights_delete = Record_New.rights_delete;
                        Record.rights_view = Record_New.rights_view;
                        Record.rights_print = Record_New.rights_print;
                        Record.rights_doc_upload = Record_New.rights_doc_upload;
                        Record.rights_doc_view = Record_New.rights_doc_view;
                        Record.rights_approver = Record_New.rights_approver;
                        Record.rights_value = Record_New.rights_value;
                    }
                }
                context.SaveChanges();
                //Record_DTO.user_id = Record.user_id;
                // Lib.AssignDates2DTO(id, Record, Record_DTO);
                // record_dto.rec_created_by = Record.rec_created_by;
                // record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                // if (record_dto.rights_id != 0)
                // {
                //     record_dto.rec_edited_by = Record.rec_edited_by;
                //     record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                // }
                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "user_name", "User Name Duplication");
                throw;
            }
        }

    }
}
