using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database.Models.Masters
{
    public class mast_param 
    {
        [Key]
        public int param_id { get; set; }
        public string? param_type { get; set; }
        public string? param_code { get; set; }
        public string? param_name { get; set; }
        public string? param_value1 { get; set; }
        public string? param_value2 { get; set; }
        public string? param_value3 { get; set; }
        public string? param_value4 { get; set; }
        public string? param_value5 { get; set; }
        public int param_order { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        // public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }
        // public int rec_branch_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        // [ForeignKey("rec_branch_id")]
        // public mast_branchm? branch { get; set; }
        /*
        public int rec_company_id { get; set; }
        public company company { get; set; }
        public int? rec_branch_id { get; set; }
        public branch branch { get; set; }
        public string rec_locked { get; set; }
        public string rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }

        */
    }

}