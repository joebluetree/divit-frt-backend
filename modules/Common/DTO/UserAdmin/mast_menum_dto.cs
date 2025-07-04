using Database.Models.BaseTables;

namespace Common.UserAdmin.DTO
{
    public class mast_menum_dto : basetable_dto
    {
        public int menu_id { get; set; }

        public string? menu_code { get; set; }
        public string? menu_name { get; set; }
        public string? menu_route { get; set; }

        public string? menu_param { get; set; }
        public string? menu_visible { get; set; }
        public int menu_order { get; set; }

        public int menu_module_id { get; set; }
        public string? menu_module_name { get; set; }


        public int? menu_submenu_id { get; set; }
        public string? menu_submenu_name { get; set; }

        public int menu_module_order { get; set; }

        public string? rights_selected { get; set; }
        public string? rights_company { get; set; }
        public string? rights_admin { get; set; }
        public string? rights_add { get; set; }
        public string? rights_edit { get; set; }
        public string? rights_delete { get; set; }
        public string? rights_view { get; set; }
        public string? rights_print { get; set; }
        public string? rights_pdf { get; set; }
        public string? rights_excel { get; set; }
        public string? rights_email { get; set; }
        public string? rights_doc_upload { get; set; }
        public string? rights_doc_view { get; set; }
        public string? rights_approver { get; set; }
        public string? rights_value { get; set; }

    }
}
