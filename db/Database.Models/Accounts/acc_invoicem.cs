using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Cargo;
using Database.Models.Masters;
using Database.Models.UserAdmin;

namespace Database.Models.Accounts
{
    public class acc_invoicem
    {
        [Key]
        public int inv_id { get; set; }
        public int inv_cfno { get; set; }
        public string? inv_no { get; set; }
        public DateTime? inv_date { get; set; }
        public int? inv_cust_id { get; set; }
        public string? inv_cust_name { get; set; }
        public string? inv_mbl_refno { get; set; }
        public string? inv_arrnotice { get; set; }
        public string? inv_cust_refno { get; set; }
        public string? inv_quoteno { get; set; }

        public string? inv_houseno { get; set; }
        public string? inv_shipper { get; set; }
        public string? inv_consignee { get; set; }
        public int? inv_pcs { get; set; }
        public int? inv_uom_id { get; set; }
        public decimal? inv_lbs { get; set; }
        public decimal? inv_kgs { get; set; }
        public decimal? inv_cbm { get; set; }
        public decimal? inv_cft { get; set; }
        public string? rec_deleted { get; set; }
        public decimal? inv_ftotal { get; set; }
        public int? inv_cur_id { get; set; }
        public decimal? inv_exrate { get; set; }
        public decimal? inv_total { get; set; }
        public decimal? inv_paid { get; set; }
        public string? inv_remarks1 { get; set; }
        public string? inv_remarks2 { get; set; }
        public string? inv_remarks3 { get; set; }
        public string? inv_cost_type { get; set; }
        public string? inv_arap { get; set; }
        public string? inv_type { get; set; }
        public int? inv_mbl_id { get; set; }
        public int? inv_hbl_id { get; set; }
        public string? rec_files_attached { get; set; }
        public int? rec_files_count { get; set; }
        public string? rec_check_attached { get; set; }
        public int? rec_check_count { get; set; }

        [ForeignKey("inv_cust_id")]
        public mast_customerm? customer { get; set; }

        [ForeignKey("inv_cur_id")]
        public mast_param? currency { get; set; }
    
        [ForeignKey("inv_uom_id")]
        public mast_param? unit { get; set; }
    
        [ForeignKey("inv_mbl_id")]
        public cargo_masterm? master { get; set; }

        [ForeignKey("inv_hbl_id")]
        public cargo_housem? house { get; set; }

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
