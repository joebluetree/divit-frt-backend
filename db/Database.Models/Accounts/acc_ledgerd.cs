using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Masters;
using Database.Models.UserAdmin;

namespace Database.Models.Accounts
{
    public class acc_ledgerd
    {
        [Key]
        public int jv_id { get; set; }
        public int jv_header_id { get; set; }
        public int jv_year { get; set; }
        public int jv_vrno { get; set; }
        public string? jv_docno { get; set; }
        public string? jv_type { get; set; }
        public DateOnly? jv_date { get; set; }
        public string? jv_refno { get; set; }
        public DateOnly? jv_refdate { get; set; }
        public int? jv_acc_id { get; set; }
        public string? jv_acc_name { get; set; }
        public string? jv_shipment_ref { get; set; }
        public DateOnly? jv_shipment_date { get; set; }
        public string? jv_status { get; set; }
        public decimal? jv_famt { get; set; }
        public int? jv_cur_id { get; set; }
        public decimal? jv_exrate { get; set; }
        public string? jv_drcr { get; set; }
        public decimal? jv_dcamt { get; set; }
        public decimal? jv_debit { get; set; }
        public decimal? jv_credit { get; set; }
        public int? jv_inv_id { get; set; }
        public string? jv_remarks { get; set; }
        public string? jv_narration { get; set; }
        public string? jv_doc_type { get; set; }
        public string? jv_bank { get; set; }
        public string? jv_chqno { get; set; }
        public DateOnly? jv_chq_date { get; set; }
        public DateOnly? jv_master_date { get; set; }
        public string? jv_is_payroll { get; set; }
        public decimal? jv_tax_amt { get; set; }
        public decimal? jv_tax_per { get; set; }
        public int? jv_ctr { get; set; }

        [ForeignKey("jv_header_id")]
        public acc_ledgerh? header { get; set; }

        [ForeignKey("jv_acc_id")]
        public acc_acctm? accounts { get; set; }

        [ForeignKey("jv_cur_id")]
        public mast_param? currency { get; set; }

        [ForeignKey("jv_inv_id")]
        public acc_invoicem? invoice { get; set; }

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
