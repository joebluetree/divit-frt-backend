using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Database.Models.UserAdmin
{
    public class mast_rightsm 
    {
        [Key]
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
        public string? rights_pdf { get; set; }
        public string? rights_excel { get; set; }
        public string? rights_email { get; set; }
        public string? rights_doc_upload { get; set; }
        public string? rights_doc_view { get; set; }
        public string? rights_approver { get; set; }

        public string? rights_value { get; set; }
        
        [ForeignKey("rights_parent_id")]
        public mast_userbranches? userbranches { get; set; }

        [ForeignKey("rights_user_id")]
        public mast_userm? user { get; set; }
        
        [ForeignKey("rights_menu_id")]
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
        [ConcurrencyCheck]
        public int rec_version { get; set; }
        // public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int? rec_company_id { get; set; }
        public int? rec_branch_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }
        
        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }
    }

}
