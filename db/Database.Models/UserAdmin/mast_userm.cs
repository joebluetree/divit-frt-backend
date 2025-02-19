using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database.Models.UserAdmin
{
    public class mast_userm
    {
        [Key]
        public int user_id { get; set; }
        public string? user_code { get; set; }
        public string? user_name { get; set; }
        public string? user_password { get; set; }
        public string? user_email { get; set; }
        public string? user_is_admin { get; set; }
        public List<mast_userbranches>? userbranches { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }
                
        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }

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
