using Common.DTO.OtherOp;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 06/05/2025
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.OtherOp
{
    public class cargo_otherop_dto : basetable_dto
    {
        public int oth_id { get; set; } = 0;
        public int oth_hbl_id { get; set; } = 0;
        public int? oth_parent_id { get; set; } = 0;
        public int? oth_cfno { get; set; } = 0;
        public string? oth_mode { get; set; } = "";
        public string? oth_refno { get; set; } = "";
        public string? oth_ref_date { get; set; } = "";
        public int? oth_shipment_stage_id { get; set; } = 0;
        public string? oth_shipment_stage_name { get; set; } = "";
        public string? oth_mbl_no { get; set; } = "";
        public int? oth_agent_id { get; set; } = 0;
        public string? oth_agent_name { get; set; } = "";        
        public int? oth_liner_id { get; set; } = 0;
        public string? oth_liner_name { get; set; } = "";
        public int? oth_handled_id { get; set; } = 0;
        public string? oth_handled_name { get; set; } = "";
        public int? oth_salesman_id { get; set; } = 0;
        public string? oth_salesman_name { get; set; } = "";
        public string? oth_mbl_frt_status { get; set; } = "";
        public int? oth_pol_id { get; set; } = 0;
        public string? oth_pol_name { get; set; } = "";
        public string? oth_pol_etd { get; set; } = "";
        public int? oth_pod_id { get; set; } = 0;
        public string? oth_pod_name { get; set; } = "";
        public string? oth_pod_eta { get; set; } = "";
        public string? oth_place_delivery { get; set; } = "";
        public int? oth_country_id { get; set; } = 0;
        public string? oth_country_name { get; set; } = "";
        public string? oth_vessel_name { get; set; } = "";
        public string? oth_voyage { get; set; } = "";
        public string? oth_hbl_no { get; set; } = "";
        public int? oth_shipper_id { get; set; } = 0;
        public string? oth_shipper_code { get; set; } = "";
        public string? oth_shipper_name { get; set; } = "";
        public string? oth_shipper_add1 { get; set; } = "";
        public string? oth_shipper_add2 { get; set; } = "";
        public string? oth_shipper_add3 { get; set; } = "";
        public string? oth_shipper_add4 { get; set; } = "";
        public int? oth_consignee_id { get; set; } = 0;
        public string? oth_consignee_code { get; set; } = "";
        public string? oth_consignee_name { get; set; } = "";
        public string? oth_consignee_add1 { get; set; } = "";
        public string? oth_consignee_add2 { get; set; } = "";
        public string? oth_consignee_add3 { get; set; } = "";
        public string? oth_consignee_add4 { get; set; } = "";
        public string? oth_bltype { get; set; } = "";
        public string? oth_hbl_frt_status { get; set; } = "";
        public string? oth_commodity { get; set; } = "";
        public string? oth_isf_no { get; set; } = "";
        public int? oth_packages { get; set; } = 0;
        public decimal? oth_cbm { get; set; } = 0;
        public decimal? oth_weight { get; set; } = 0;
        public decimal? oth_lbs { get; set; } = 0;
        public decimal? oth_cft { get; set; } = 0;
        public decimal? oth_chwt { get; set; } = 0;
        public decimal? oth_chwt_lbs { get; set; } = 0;
        public int? oth_location_id { get; set; } = 0;
        public string? oth_location_code { get; set; } = "";
        public string? oth_location_name { get; set; } = "";
        public string? oth_location_add1 { get; set; } = "";
        public string? oth_location_add2 { get; set; } = "";
        public string? oth_location_add3 { get; set; } = "";
        public string? oth_location_add4 { get; set; } = "";
        public string? oth_is_pl { get; set; } = "";
        public string? oth_is_ci { get; set; } = "";
        public string? oth_is_carr_an { get; set; } = "";
        public string? oth_custom_reles_status { get; set; } = "";
        public string? oth_is_delivery { get; set; } = "";
        public string? oth_lfd_date { get; set; } = ""; 
        public string? oth_it_no { get; set; } = "";
        public string? oth_it_date { get; set; }= "";
        public string? oth_it_port { get; set; } = "";
        public decimal? oth_teu { get; set; } = 0;
        public decimal? oth_20 { get; set; } = 0;
        public decimal? oth_40 { get; set; } = 0;
        public decimal? oth_40hq { get; set; } = 0;
        public decimal? oth_45 { get; set; } = 0;
        public int? oth_container_tot { get; set; } = 0;
        public int? rec_files_count { get; set; }
        public string? rec_files_attached { get; set; }
        public List<cargo_container_dto>? otherop_cntr { get; set; }
        public cargo_otherop_dto? otherop_house { get; set; }

    }
}
