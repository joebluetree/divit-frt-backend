using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database.Models.Accounts
{
    public class acc_acctm 
    {
        [Key]
        public int acc_id { get; set; }
        public string? acc_code { get; set; }
        public string? acc_short_name { get; set; }
        public string? acc_name { get; set; }
        public string? acc_type { get; set; }
        public string? acc_row_type { get; set; }

        public Nullable<int> acc_maincode_id { get; set; }
        
        [ForeignKey("acc_maincode_id")]
        public acc_acctm? acctm { get; set; }
        public int acc_grp_id { get; set; }

        [ForeignKey("acc_grp_id")]
        public acc_groupm? acc_groupm { get; set; }

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
    }
}
