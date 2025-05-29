using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 03/01/2025
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.SeaExport
{
    public class cargo_sea_exportm_dto : basetable_dto
    {
        public int mbl_id { get; set; } = 0;
        public int? mbl_cfno { get; set; } = 0;
        public string? mbl_mode { get; set; } = "";
        public string? mbl_refno { get; set; } = "";
        public string? mbl_ref_date { get; set; } = "";
        public int? mbl_shipment_stage_id { get; set; } = 0;
        public string? mbl_shipment_stage_name { get; set; } = "";
        public string? mbl_no { get; set; } = "";
        public string? mbl_sub_houseno { get; set; } = "";
        public string? mbl_liner_bookingno { get; set; } = "";
        public int? mbl_agent_id { get; set; } = 0;
        public string? mbl_agent_name { get; set; } = "";
        public int? mbl_liner_id { get; set; } = 0;
        public string? mbl_liner_name { get; set; } = "";
        public int? mbl_handled_id { get; set; } = 0;
        public string? mbl_handled_name { get; set; } = "";
        public int? mbl_salesman_id { get; set; } = 0;
        public string? mbl_salesman_name { get; set; } = "";
        public string? mbl_frt_status_name { get; set; } = "";
        public int? mbl_ship_term_id { get; set; } = 0;
        public string? mbl_ship_term_name { get; set; } = "";
        public string? mbl_cntr_type { get; set; } = "";
        public string? mbl_direct { get; set; } = "";
        public string? mbl_place_delivery { get; set; } = "";
        public int? mbl_pol_id { get; set; } = 0;
        public string? mbl_pol_name { get; set; } = "";
        public string? mbl_pol_etd { get; set; } = "";
        public int? mbl_pod_id { get; set; } = 0;
        public string? mbl_pod_name { get; set; } = "";
        public string? mbl_pod_eta { get; set; } = "";
        public int? mbl_pofd_id { get; set; } = 0;
        public string? mbl_pofd_name { get; set; } = "";
        public string? mbl_pofd_eta { get; set; } = "";
        public int? mbl_country_id { get; set; } = 0;
        public string? mbl_country_name { get; set; } = "";
        public int? mbl_vessel_id { get; set; } = 0;
        public string? mbl_vessel_code { get; set; } = "";
        public string? mbl_vessel_name { get; set; } = "";
        public string? mbl_voyage { get; set; } = "";
        public int? mbl_book_slno { get; set; } = 0;
        public decimal? mbl_teu { get; set; } = 0;
        public decimal? mbl_20 { get; set; } = 0;
        public decimal? mbl_40 { get; set; } = 0;
        public decimal? mbl_40hq { get; set; } = 0;
        public decimal? mbl_45 { get; set; } = 0;
        public int? mbl_container_tot { get; set; } = 0;
        public int? mbl_house_tot { get; set; } = 0;
        public int? rec_files_count { get; set; }
        public string? rec_files_attached { get; set; }
        public List<cargo_container_dto>? master_cntr { get; set; }
        public List<cargo_sea_exporth_dto>? master_house { get; set; }

    }
}
