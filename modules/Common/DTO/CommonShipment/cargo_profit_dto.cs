using Database.Models.Accounts;
using Database.Models.BaseTables;

namespace Common.DTO.CommonShipment
{
    public class cargo_profit_dto : basetable_dto
    {
        public int inv_id { get; set; }
        public int inv_cfno { get; set; }
        public string? inv_no { get; set; }
        public string? inv_date { get; set; }
        public int inv_year { get; set; }
        public int? inv_cust_id { get; set; }
        public string? inv_cust_code { get; set; }
        public string? inv_cust_name { get; set; }
        public string? inv_mbl_refno { get; set; }
        public string? inv_arrnotice { get; set; }
        public string? inv_cust_refno { get; set; }
        public string? inv_quoteno { get; set; }

        public string? inv_arap { get; set; }
        public string? inv_houseno { get; set; }
        public int? inv_mbl_id { get; set; }
        public int? inv_hbl_id { get; set; }
        public int? inv_pcs { get; set; }
        public int? inv_uom_id { get; set; }
        public string? inv_uom_code { get; set; }
        public decimal? inv_lbs { get; set; }
        public decimal? inv_kgs { get; set; }
        
        public decimal? inv_cft { get; set; }
        public string? rec_deleted { get; set; }
        public decimal? inv_inc_total { get; set; }
        public decimal? inv_exp_total { get; set; }
        public decimal? inv_profit { get; set; }

        public string? inv_refno { get; set; }
        public string? inv_mbl_no { get; set; }
        public string? inv_pol_name { get; set; }
        public string? inv_pod_name { get; set; }
        public decimal? inv_wt { get; set; }
        public decimal? inv_chwt { get; set; }
        public decimal? inv_cbm { get; set; }
    }
}
