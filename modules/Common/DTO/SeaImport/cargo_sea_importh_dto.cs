using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 28/03/2025
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.SeaImport
{
    public class cargo_sea_importh_dto : basetable_dto
    {
        public int hbl_id { get; set; } = 0;
        public int hbl_mbl_id { get; set; } = 0;//fk
        public string? hbl_mbl_refno { get; set; }= "";
        public string? hbl_mbl_no { get; set; }= "";
        public string? hbl_mbl_pol_etd { get; set; }= "";
        public string? hbl_mbl_pod_eta { get; set; }= "";
        public int hbl_cfno { get; set; } = 0;
        public string? hbl_houseno { get; set; } = "";
        public int? hbl_shipment_stage_id { get; set; } = 0;
        public string? hbl_shipment_stage_name { get; set; } = "";
        public string? hbl_date { get; set; } = "";
        public string? hbl_bltype { get; set; } = "";
        public string? hbl_mode { get; set; } = "";
        public int? hbl_shipper_id { get; set; } = 0;
        public string? hbl_shipper_code { get; set; } = "";
        public string? hbl_shipper_name { get; set; } = "";
        public string? hbl_shipper_add1 { get; set; } = "";
        public string? hbl_shipper_add2 { get; set; } = "";
        public string? hbl_shipper_add3 { get; set; } = "";
        public string? hbl_shipper_add4 { get; set; } = "";
        public string? hbl_shipper_add5 { get; set; } = "";
        public int? hbl_consignee_id { get; set; } = 0;
        public string? hbl_consignee_code { get; set; } = "";
        public string? hbl_consignee_name { get; set; } = "";
        public string? hbl_consignee_add1 { get; set; } = "";
        public string? hbl_consignee_add2 { get; set; } = "";
        public string? hbl_consignee_add3 { get; set; } = "";
        public string? hbl_consignee_add4 { get; set; } = "";
        public string? hbl_consignee_add5 { get; set; } = "";
        public string? hbl_client_cat { get; set; } = "";
        public string? hbl_client_type { get; set; } = "";
        public int? hbl_location_id { get; set; } = 0;
        public string? hbl_location_code { get; set; } = "";
        public string? hbl_location_name { get; set; } = "";
        public string? hbl_location_add1 { get; set; } = "";
        public string? hbl_location_add2 { get; set; } = "";
        public string? hbl_location_add3 { get; set; } = "";
        public string? hbl_location_add4 { get; set; } = "";
        public string? hbl_location_add5 { get; set; } = "";
        public int? hbl_notify_id { get; set; } = 0;
        public string? hbl_notify_code { get; set; } = "";
        public string? hbl_notify_name { get; set; } = "";
        public string? hbl_notify_add1 { get; set; } = "";
        public string? hbl_notify_add2 { get; set; } = "";
        public string? hbl_notify_add3 { get; set; } = "";
        public string? hbl_notify_add4 { get; set; } = "";
        public string? hbl_notify_add5 { get; set; } = "";
        public int? hbl_careof_id { get; set; } = 0;
        public string? hbl_careof_name { get; set; } = "";
        public int? hbl_agent_id { get; set; } = 0;
        public string? hbl_agent_name { get; set; } = "";
        public int? hbl_cha_id { get; set; } = 0;
        public string? hbl_cha_code { get; set; } = "";
        public string? hbl_cha_name { get; set; } = "";
        public string? hbl_cha_attn { get; set; } = "";
        public string? hbl_cha_tel { get; set; } = "";
        public string? hbl_cha_fax { get; set; } = "";
        public string? hbl_place_final { get; set; } = "";

        public string? hbl_consigned_to1 { get; set; } = "";
        public string? hbl_consigned_to2 { get; set; } = "";
        public string? hbl_consigned_to3 { get; set; } = "";
        public string? hbl_consigned_to4 { get; set; } = "";
        public string? hbl_consigned_to5 { get; set; } = "";
        public string? hbl_place_delivery { get; set; } = "";
        public string? hbl_pld_eta { get; set; } = "";
        public string? hbl_plf_eta { get; set; } = "";
        public string? hbl_it_no { get; set; } = "";
        public string? hbl_is_itshipment { get; set; } = "";
        public string? hbl_it_port { get; set; } = "";
        public string? hbl_it_date { get; set; }= "";
        public int? hbl_packages { get; set; } = 0;
        public int? hbl_uom_id { get; set; } = 0;
        public string? hbl_uom_name { get; set; } = "";
        public decimal? hbl_cbm { get; set; } = 0;
        public decimal? hbl_weight { get; set; } = 0;
        public decimal? hbl_lbs { get; set; } = 0;
        public decimal? hbl_cft { get; set; } = 0;
        public int? hbl_pcs { get; set; } = 0;
        public string? hbl_commodity { get; set; } = "";
        public string? hbl_frt_status_name { get; set;} = "";
        public int? hbl_ship_term_id { get; set; } = 0;
        public string? hbl_ship_term_name { get; set; } = "";
        public int? hbl_incoterm_id { get; set; } = 0;
        public string? hbl_incoterm_name { get; set; } = "";
        public string? hbl_pono { get; set; } = "";
        public string? hbl_invoiceno { get; set; } = "";
        public string? hbl_ams_fileno { get; set; } = "";
        public string? hbl_sub_house { get; set; } = "";
        public string? hbl_isf_no { get; set; } = "";
        public int? hbl_telex_released_id { get; set; } = 0;
        public string? hbl_telex_released_code { get; set; } = "";
        public string? hbl_telex_released_name { get; set; } = "";
        public string? hbl_mov_dad { get; set; } = "";
        public string? hbl_bl_req { get; set; } = "";
        public string? hbl_book_slno { get; set; } = "";
        public string? hbl_is_pl { get; set; } = "";
        public string? hbl_is_ci { get; set; } = "";
        public string? hbl_is_carr_an { get; set; } = "";
        public string? hbl_custom_reles_status { get; set; } = "";
        public string? hbl_custom_clear_date { get; set; } = "";
        public string? hbl_is_delivery { get; set; } = "";
        public int? hbl_paid_status_id { get; set; } = 0;
        public string? hbl_paid_status_name { get; set; } = "";
        public string? hbl_bl_status { get; set; } = "";
        public string? hbl_cargo_release_status { get; set; } = "";
        public int? hbl_salesman_id { get; set; } = 0;
        public string? hbl_salesman_name { get; set; } = "";
        public int? hbl_handled_id { get; set; } = 0;
        public string? hbl_handled_name { get; set; } = "";
        public string? hbl_remark1 { get; set; } = "";
        public string? hbl_remark2 { get; set; } = "";
        public string? hbl_remark3 { get; set; } = "";
        public string? hbl_lfd_date { get; set; } = "";
        public string? hbl_go_date { get; set; } = "";
        public string? hbl_pickup_date { get; set; } = "";
        public string? hbl_empty_ret_date { get; set; } = "";
        public string? hbl_delivery_date { get; set; }

        public int desc_parent_id { get; set; } = 0;
        public string? desc_parent_type { get; set; } = "";
        public List<cargo_container_dto>? house_cntr { get; set; }
        
        public cargo_desc_dto? marks1 { get; set; }
        public cargo_desc_dto? marks2 { get; set; }
        public cargo_desc_dto? marks3 { get; set; }
        public cargo_desc_dto? marks4 { get; set; }
        public cargo_desc_dto? marks5 { get; set; }
        public cargo_desc_dto? marks6 { get; set; }
        public cargo_desc_dto? marks7 { get; set; }
        public cargo_desc_dto? marks8 { get; set; }
        public cargo_desc_dto? marks9 { get; set; }
        public cargo_desc_dto? marks10 { get; set; }
        public cargo_desc_dto? marks11 { get; set; }
        public cargo_desc_dto? marks12 { get; set; }
        public cargo_desc_dto? marks13 { get; set; }
        public cargo_desc_dto? marks14 { get; set; }
        public cargo_desc_dto? marks15 { get; set; }
        public cargo_desc_dto? marks16 { get; set; }
        public cargo_desc_dto? marks17 { get; set; }
        
        
    }
}

