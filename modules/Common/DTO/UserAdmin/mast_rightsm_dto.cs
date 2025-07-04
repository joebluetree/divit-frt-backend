using Database.Models.BaseTables;

namespace Common.UserAdmin.DTO
{
    public class rights_header_dto
    {
        public int id { get; set; }
        public int comp_id { get; set; }
        public int branch_id { get; set; }
        public int user_id { get; set; }
        public List<mast_rightsm_dto>? records { get; set; }
    }
    public class mast_rightsm_dto : basetable_dto
    {
        public int rights_id { get; set; }
        public int rights_parent_id { get; set; }
        public int rights_user_id { get; set; }
        public int rights_user_name { get; set; }

        public int rights_menu_id { get; set; }
        public string? rights_menu_name { get; set; } = "";

        public string? rights_module_name { get; set; } = "";
        public string? rights_selected { get; set; } = "";
        public string? rights_company { get; set; } = "";
        public string? rights_admin { get; set; } = "";
        public string? rights_add { get; set; } = "";
        public string? rights_edit { get; set; } = "";
        public string? rights_view { get; set; } = "";
        public string? rights_delete { get; set; } = "";
        public string? rights_print { get; set; } = "";
        public string? rights_pdf { get; set; } = "";
        public string? rights_excel { get; set; } = "";
        public string? rights_email { get; set; } = "";
        public string? rights_doc_upload { get; set; } = "";
        public string? rights_doc_view { get; set; } = "";
        public string? rights_approver { get; set; } = "";
        public string? rights_value { get; set; } = "";

        public int rights_module_order { get; set; }
        public int rights_menu_order { get; set; }

    }

}
