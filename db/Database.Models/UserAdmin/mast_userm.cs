using System.ComponentModel.DataAnnotations;
using Database.Models.BaseTables;

namespace Database.Models.UserAdmin
{
    public class mast_userm : baseTable
    {
        public int user_id { get; set; }
        public string? user_code { get; set; }
        public string? user_name { get; set; }
        public string? user_password { get; set; }
        public string? user_email { get; set; }
        public string? user_is_admin { get; set; }
        public List<mast_userbranches>? userbranches { get; set; }


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
