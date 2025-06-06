using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;

namespace Database.Models.UserAdmin
{
    public class gen_remarkm
    {
        [Key]
        public int remk_id { get; set; }

        public int? remk_parent_id { get; set; }

        public string? remk_parent_type { get; set; }

        public string? remk_desc { get; set; }

        public int? remk_order { get; set; }

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
    }
}
