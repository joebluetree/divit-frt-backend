using System.ComponentModel.DataAnnotations;
using Database.Models.BaseTables;

namespace Database.Models.UserAdmin
{
    public class mast_rightsm : baseTable
    {
        public int rights_id { get; set; }
        public int rights_parent_id { get; set; }
        public int rights_user_id { get; set; }
        public int rights_menu_id { get; set; }
        public string? rights_company { get; set; }
        public string? rights_admin { get; set; }
        public string? rights_add { get; set; }
        public string? rights_edit { get; set; }
        public string? rights_view { get; set; }
        public string? rights_delete { get; set; }
        public string? rights_print { get; set; }
        public string? rights_doc_upload { get; set; }
        public string? rights_doc_view { get; set; }
        public string? rights_approver { get; set; }

        public string? rights_value { get; set; }

        public mast_userbranches? userbranches { get; set; }

        public mast_userm? user { get; set; }
        public mast_menum? menu { get; set; }

        /*
        public int rec_company_id { get; set; }
        public company company { get; set; }
        public int rec_branch_id { get; set; }
        public branch branch { get; set; }
        public string rec_locked { get; set; }
        public string rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        */
    }

}
