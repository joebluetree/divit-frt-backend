using Database.Models.Accounts;
using Database.Models.BaseTables;

namespace Common.DTO.Accounts
{
    public class acc_invoicem_dto : basetable_dto
    {
        public int inv_id { get; set; }
        public int inv_cfno { get; set; }
        public string? inv_no { get; set; }
        public string? inv_date { get; set; }
        public int? inv_cust_id { get; set; }
        public string? inv_cust_code { get; set; }
        public string? inv_cust_name { get; set; }
        public string? inv_mbl_refno { get; set; }
        public string? inv_arrnotice { get; set; }
        public string? inv_cust_refno { get; set; }
        public string? inv_quoteno { get; set; }

        public string? inv_mbl_code { get; set; }
        public string? inv_houseno { get; set; }
        public string? inv_shipper { get; set; }
        public string? inv_consignee { get; set; }
        public int? inv_pcs { get; set; }
        public int? inv_uom_id { get; set; }
        public string? inv_uom_code { get; set; }
        public decimal? inv_lbs { get; set; }
        public decimal? inv_kgs { get; set; }
        public decimal? inv_cbm { get; set; }
        public decimal? inv_cft { get; set; }
        public string? rec_deleted { get; set; }
        public decimal? inv_ftotal { get; set; }
        public int? inv_cur_id { get; set; }
        public string? inv_cur_code { get; set; }
        public decimal? inv_exrate { get; set; }
        public int? exrate_decimal { get; set; }
        public decimal? inv_total { get; set; }
        public decimal? inv_ar_total { get; set; }
        public decimal? inv_ap_total { get; set; }
        public decimal? inv_balance { get; set; }
        public decimal? inv_paid { get; set; }

        public string? inv_remarks1 { get; set; }
        public string? inv_remarks2 { get; set; }
        public string? inv_remarks3 { get; set; }

        public string? inv_cost_type { get; set; }
        public string? inv_arap { get; set; }
        public string? inv_type { get; set; }
        public int? inv_mbl_id { get; set; }
        public int? inv_hbl_id { get; set; }
        public string? inv_mbl_stage { get; set; }
        public string? inv_loss_memo { get; set; }
        public string? inv_loss_approved { get; set; }
        public string? inv_profit_req { get; set; }
        public string? inv_bo_status { get; set; }
        public decimal? inv_inc_total { get; set; }
        public decimal? inv_exp_total { get; set; }
        public decimal? inv_revenue { get; set; }
        public decimal? inv_ar_balance { get; set; }
        public decimal? inv_ap_balance { get; set; }
        public string? inv_remarks { get; set; }
        public int? rec_files_count { get; set; }
        public string? rec_files_attached { get; set; }
        public int? rec_check_count { get; set; }
        public string? rec_check_attached { get; set; }
        public List<acc_invoiced_dto>? invoiced { get; set; } 
    }
}
