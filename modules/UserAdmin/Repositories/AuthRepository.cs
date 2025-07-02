using Microsoft.EntityFrameworkCore;
using Database;
using UserAdmin.Interfaces;
using Common.UserAdmin.DTO;

using Database.Lib;
using Database.Models.UserAdmin;
using System.Linq;

namespace UserAdmin.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext context;
        public AuthRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        public async Task<mast_userm?> AuthenticateAsync(string username, string password)
        {

            try {
            var user = await context.mast_userm
                .Where(x => x.user_code == username.ToUpper() && x.user_password == password.ToUpper())
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            /*
            var userRoles = await context.Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();
            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await nZWalksDbContext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }
            */
            user.user_password = string.Empty;
            return user;
            }
            catch ( Exception ex ){
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<Dictionary<string, object>> GetBranchListAsync(Dictionary<string, object> data)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                int comp_id = 0;
                int user_id = 0;

                if (data.ContainsKey("company_id"))
                    comp_id = int.Parse(data["company_id"].ToString()!);

                if (data.ContainsKey("user_id"))
                    user_id = int.Parse(data["user_id"].ToString()!);

                var query = from rec in context.mast_branchm
                            where rec.rec_company_id == comp_id
                            select new
                            {
                                rec.branch_id,
                                rec.branch_code,
                                rec.branch_name,
                            };

                query = query
                    .OrderBy(c => c.branch_name);

                var Records = await query
                    .ToListAsync();

                RetData.Add("records", Records);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<Dictionary<string, object>> BranchLoginAsync(Dictionary<string, object> data)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                int comp_id = 0;
                int branch_id = 0;
                int user_id = 0;
                string isAdmin = "N";

                if (data.ContainsKey("company_id"))
                    comp_id = int.Parse(data["company_id"].ToString()!);
                if (data.ContainsKey("branch_id"))
                    branch_id = int.Parse(data["branch_id"].ToString()!);
                if (data.ContainsKey("user_id"))
                    user_id = int.Parse(data["user_id"].ToString()!);

                var user = await context.mast_userm
                    .Where(e => e.user_id == user_id)
                    .SingleOrDefaultAsync();

                if (user == null)
                    throw new Exception("User Data Not Found");

                isAdmin = user.user_is_admin!;

                var Records = new List<mast_menum_dto>();

                var query = context.mast_modulem.Include(e => e.module)
                    .Where(e => e.rec_company_id == comp_id)
                    .OrderBy(e => e.module_order);

                var module_list = await query.Select(e => new mast_modulem_dto
                {
                    module_id = e.module_id,
                    module_name = e.module_name,
                    module_parent_id = e.module_parent_id,
                    module_parent_name = e.module!.module_name,
                    module_is_installed = "N"
                }).ToListAsync();

                if (isAdmin == "Y")
                    Records = await this.getAdminMenu(user_id, comp_id, branch_id);
                else
                    Records = await this.getUserMenu(user_id, comp_id, branch_id);



                var module_list_selected = Records
                    .Where(e => e.menu_visible == "Y")
                    .Select(e => new { e.menu_module_id, e.menu_submenu_id })
                    .Distinct()
                    .ToList();

                foreach (var rec in module_list_selected)
                {
                    var modules = module_list.FindAll(f => f.module_id == rec.menu_module_id || f.module_id == rec.menu_submenu_id);
                    foreach (mast_modulem_dto module in modules)
                        module.module_is_installed = "Y";
                }

                module_list = module_list.FindAll(f => f.module_is_installed == "Y");

                List<string> valueList = new List<string> { "DEICMALS", "DATE-FORMAT" };
                List<mast_settings_dto> company_settings_list = await context.mast_settings
                            .Where(w => w.rec_company_id == comp_id && valueList.Contains(w.caption!))
                            .Select(e => new mast_settings_dto
                            {
                                caption = e.caption,
                                type = e.type,
                                code = e.code,
                                name = e.name,
                                value = e.value,
                                param_id = e.param_id,
                            }).ToListAsync();

                RetData.Add("company_id", comp_id);
                RetData.Add("branch_id", branch_id);
                RetData.Add("user_id", user_id);
                RetData.Add("module_list", module_list);
                RetData.Add("menu_list", Records);
                RetData.Add("company_settings_list", company_settings_list);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }


        private async Task<List<mast_menum_dto>> getAdminMenu(int user_id, int comp_id, int branch_id)
        {
            var query = from a in context.mast_menum
                        where a.rec_company_id == comp_id
                        select (new mast_menum_dto
                        {
                            menu_id = a.menu_id,
                            menu_code = a.menu_code,
                            menu_name = a.menu_name,
                            menu_route = a.menu_route,
                            menu_param = a.menu_param,
                            menu_module_id = a.menu_module_id,
                            menu_module_name = a.module!.module_name,
                            menu_module_order = a.module.module_order,
                            menu_submenu_id = a.menu_submenu_id == null ? a.menu_module_id : a.menu_submenu_id,
                            menu_submenu_name = a.menu_submenu_id == null ? a.module.module_name : a.submenu!.module_name,
                            menu_order = a.menu_order,
                            menu_visible = a.menu_visible,
                            rights_selected = "Y",
                            rights_company = "Y",
                            rights_admin = "Y",
                            rights_add = "Y",
                            rights_edit = "Y",
                            rights_delete = "Y",
                            rights_view = "Y",
                            rights_print = "Y",
                            rights_doc_upload = "Y",
                            rights_doc_view = "Y",
                            rights_approver = "Y",
                            rights_value = "",
                            rec_company_id = comp_id,
                            rec_branch_id = branch_id
                        });

            var Records = await query
                .OrderBy(c => c.menu_module_order).ThenBy(c => c.menu_order)
                .ToListAsync();

            return Records;

        }

        private async Task<List<mast_menum_dto>> getUserMenu(int user_id, int comp_id, int branch_id)
        {

            var query = from a in context.mast_menum
                        from b in context.mast_rightsm.Where(w =>
                            a.menu_id == w.rights_menu_id
                            && w.rec_company_id == comp_id
                            && w.rec_branch_id == branch_id
                            && w.rights_user_id == user_id
                            )
                        select (new mast_menum_dto
                        {
                            menu_id = a.menu_id,
                            menu_code = a.menu_code,
                            menu_name = a.menu_name,
                            menu_route = a.menu_route,
                            menu_param = a.menu_param,
                            menu_order = a.menu_order,
                            menu_visible = a.menu_visible,
                            menu_module_id = a.menu_module_id,
                            menu_module_name = a.module!.module_name,
                            menu_submenu_id = a.menu_submenu_id == null ? a.menu_module_id : a.menu_submenu_id,
                            menu_submenu_name = a.menu_submenu_id == null ? a.module.module_name : a.submenu!.module_name,
                            menu_module_order = a.module.module_order,
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
                            rec_company_id = comp_id,
                            rec_branch_id = branch_id
                        });

            var Records = await query
                .OrderBy(c => c.menu_module_order).ThenBy(c => c.menu_order)
                .ToListAsync();

            return Records;

        }

    }
}

