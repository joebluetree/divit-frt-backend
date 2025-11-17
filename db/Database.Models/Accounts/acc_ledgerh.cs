using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Masters;
using Database.Models.UserAdmin;

namespace Database.Models.Accounts
{
    public class acc_ledgerh
    {
        [Key]
        public int jvh_id { get; set; } 
        public int jvh_year { get; set; }
        public int jvh_vrno { get; set; }
        public string? jvh_docno { get; set; }
        public string? jvh_type { get; set; }
        public DateOnly? jvh_date { get; set; }
        public string? jvh_refno { get; set; }
        public DateOnly? jvh_refdate { get; set; }
        public string? jvh_status { get; set; }
        public int? jvh_cur_id { get; set; }
        public decimal? jvh_exrate { get; set; }
        public string? jvh_remarks { get; set; }
        public string? jvh_narration { get; set; }
        public DateOnly? jvh_master_date { get; set; }
        public string? jvh_is_payroll { get; set; }
        public string? jvh_shipment_ref { get; set; }
        public DateOnly? jvh_shipment_date { get; set; }
        public decimal? jvh_credit { get; set; }
        public decimal? jvh_debit { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }

        [ForeignKey("jvh_cur_id")]
        public mast_param? currency { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }
    }
}