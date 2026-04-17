
using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 09/02/2026
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Report
{
    public class rep_masterprofit_dto : basetable_dto
    {
        public int mbl_id { get; set; } = 0;
        public string? mbl_refno { get; set; } = "";
        public string? mbl_mode { get; set; } = "";
        public string? mbl_ref_date { get; set; } = "";
        public string? mbl_no { get; set; } = "";
        public string? mbl_inv { get; set; } = "";
        public int? mbl_agent_id { get; set; } = 0;
        public string? mbl_agent_name { get; set; } = "";
        public int? mbl_liner_id { get; set; } = 0;
        public string? mbl_liner_name { get; set; } = "";
        public int? mbl_shipper_id { get; set; } = 0;
        public string? mbl_shipper_name { get; set; } = "";
        public int? mbl_consignee_id { get; set; } = 0;
        public string? mbl_consignee_name { get; set; } = "";
        public string? mbl_cntr_type { get; set; } = "";
        public int? mbl_ref_count { get; set; } = 0;
        public int? mbl_house_tot { get; set; } = 0;
        public int? mbl_pcs { get; set; } = 0;
        public decimal? mbl_teu { get; set; } = 0;
        public int? mbl_20 { get; set; } = 0;
        public int? mbl_40 { get; set; } = 0;
        public int? mbl_40hq { get; set; } = 0;
        public int? mbl_45 { get; set; } = 0;
        public int? mbl_container_tot { get; set; } = 0;
        public int? mbl_master_tot { get; set; } = 0;
        public decimal? mbl_cbm { get; set; } = 0;
        public decimal? mbl_weight { get; set; } = 0;
        public bool? IsAgentTitle { get; set; } = false;
        public decimal? mbl_revenue { get; set; } = 0;
        public decimal? mbl_inc_total { get; set; } = 0;
        public decimal? mbl_exp_total { get; set; } = 0;
        public decimal? mbl_profit { get; set; } = 0;
        public decimal? mbl_profit_per { get; set; } = 0;
        public string? mbl_customer_name { get; set; } = ""; // billing party
        public string? mbl_link { get; set; } = "";
        public string? mbl_menuid { get; set; } = "";
        public string? mbl_type { get; set; } = "";

    }
}
