using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.BaseTables;

namespace Database.Models.UserAdmin
{
    public class mast_branchm 
    {
        [Key]
        public int branch_id { get; set; }
        public string? branch_code { get; set; }
        public string? branch_name { get; set; }
        public string? branch_address1 { get; set; }
        public string? branch_address2 { get; set; }
        public string? branch_address3 { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }
        /*        
        public string rec_locked { get; set; }
        public string rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        */

    }

}
