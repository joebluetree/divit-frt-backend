using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 28/03/2025
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.SeaImport
{
    public class cargo_sea_importm_dto : basetable_dto
    {
        public int mbl_id { get; set; } = 0;
        public int? mbl_cfno { get; set; } = 0;
        public string? mbl_refno { get; set; } = "";
        public string? mbl_mode { get; set; } = "";
        public string? mbl_ref_date { get; set; } = "";
        public int? mbl_shipment_stage_id { get; set; } = 0;
        public string? mbl_shipment_stage_name { get; set; } = "";
        public string? mbl_no { get; set; } = "";
        public int? mbl_agent_id { get; set; } = 0;
        public string? mbl_agent_name { get; set; } = "";        
        public int? mbl_liner_id { get; set; } = 0;
        public string? mbl_liner_name { get; set; } = "";
        public int? mbl_coloader_id { get; set; } = 0;
        public string? mbl_coloader_name { get; set; } = "";
        public int? mbl_handled_id { get; set; } = 0;
        public string? mbl_handled_name { get; set; } = "";
        public int? mbl_salesman_id { get; set; } = 0;
        public string? mbl_salesman_name { get; set; } = "";
        public string? mbl_frt_status_name { get; set; } = "";
        public int? mbl_ship_term_id { get; set; } = 0;
        public string? mbl_ship_term_name { get; set; } = "";
        public string? mbl_cntr_type { get; set; } = "";
        public int? mbl_incoterm_id { get; set; } = 0;
        public string? mbl_incoterm_name { get; set; } = "";
        public int? mbl_pol_id { get; set; } = 0;
        public string? mbl_pol_name { get; set; } = "";
        public string? mbl_pol_etd { get; set; } = "";
        public int? mbl_pod_id { get; set; } = 0;
        public string? mbl_pod_name { get; set; } = "";
        public string? mbl_pod_eta { get; set; } = "";
        public string? mbl_place_delivery { get; set; } = "";
        public string? mbl_pofd_eta { get; set; } = "";
        public int? mbl_country_id { get; set; } = 0;
        public string? mbl_country_name { get; set; } = "";
        public int? mbl_vessel_id { get; set; } = 0;
        public string? mbl_vessel_code { get; set; } = "";
        public string? mbl_vessel_name { get; set; } = "";
        public string? mbl_voyage { get; set; } = "";
        public int? mbl_status_id { get; set; } = 0;
        public string? mbl_status_name { get; set; } = "";
        public string? mbl_is_sea_waybill { get; set; } = "";
        public string? mbl_ombl_sent_on { get; set; } = "";
        public string? mbl_ombl_sent_ampm { get; set; } = "";
        public string? mbl_of_sent_on { get; set; } = "";
        public int? mbl_cargo_loc_id { get; set; }
        public string? mbl_cargo_loc_code { get; set; }
        public string? mbl_cargo_loc_name { get; set; }
        public string? mbl_cargo_loc_add1 { get; set; }
        public string? mbl_cargo_loc_add2 { get; set; }
        public string? mbl_cargo_loc_add3 { get; set; }
        public string? mbl_cargo_loc_add4 { get; set; }
        public int? mbl_devan_loc_id { get; set; }
        public string? mbl_devan_loc_code { get; set; }
        public string? mbl_devan_loc_name { get; set; }
        public string? mbl_devan_loc_add1 { get; set; }
        public string? mbl_devan_loc_add2 { get; set; }
        public string? mbl_devan_loc_add3 { get; set; }
        public string? mbl_devan_loc_add4 { get; set; }  
        public decimal? mbl_teu { get; set; } = 0;
        public decimal? mbl_20 { get; set; } = 0;
        public decimal? mbl_40 { get; set; } = 0;
        public decimal? mbl_40hq { get; set; } = 0;
        public decimal? mbl_45 { get; set; } = 0;
        public int? mbl_container_tot { get; set; } = 0;
        public int? mbl_house_tot { get; set; } = 0;
        public decimal? mbl_cbm_tot { get; set; } = 0;
        public int? rec_files_count { get; set; }
        public string? rec_files_attached { get; set; }
        public List<cargo_container_dto>? master_cntr { get; set; }
        public List<cargo_sea_importh_dto>? master_house { get; set; }

    }
}
