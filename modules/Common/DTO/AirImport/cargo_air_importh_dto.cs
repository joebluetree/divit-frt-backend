using System;
using Database.Models.BaseTables;

namespace Common.DTO.AirImport;

public class cargo_air_importh_dto : basetable_dto
{
    public int hbl_id { get; set; }
    public int hbl_cfno { get; set; }
    public string? hbl_houseno { get; set; }
    public int hbl_mbl_id { get; set; }
    public string? hbl_mbl_refno { get; set; }
    public int? hbl_shipment_stage_id { get; set; }
    public string? hbl_shipment_stage_name { get; set; }
    public string? hbl_from_date { get; set; }
    public string? hbl_to_date { get; set; }
    public string? hbl_bltype { get; set; }
    public string? hbl_mode { get; set; }
    public int? hbl_shipper_id { get; set; }
    public string? hbl_shipper_code { get; set; }
    public string? hbl_shipper_name { get; set; }
    public string? hbl_shipper_add1 { get; set; }
    public string? hbl_shipper_add2 { get; set; }
    public string? hbl_shipper_add3 { get; set; }
    public string? hbl_shipper_add4 { get; set; }
    public string? hbl_shipper_add5 { get; set; }

    public int? hbl_consignee_id { get; set; }
    public string? hbl_consignee_code { get; set; }
    public string? hbl_consignee_name { get; set; }
    public string? hbl_consignee_add1 { get; set; }
    public string? hbl_consignee_add2 { get; set; }
    public string? hbl_consignee_add3 { get; set; }
    public string? hbl_consignee_add4 { get; set; }
    public string? hbl_consignee_add5 { get; set; }
    public int? hbl_agent_id { get; set; }
    public string? hbl_agent_name { get; set; }
    public int? hbl_cha_id { get; set; }
    public string? hbl_cha_code { get; set; }
    public string? hbl_cha_name { get; set; }
    public string? hbl_cha_attn { get; set; }
    public string? hbl_cha_tel { get; set; }
    public string? hbl_cha_fax { get; set; }
    public int? hbl_location_id { get; set; }
    public string? hbl_location_code { get; set; }
    public string? hbl_location_name { get; set; }
    public string? hbl_location_add1 { get; set; }
    public string? hbl_location_add2 { get; set; }
    public string? hbl_location_add3 { get; set; }
    public string? hbl_location_add4 { get; set; }

    public string? hbl_it_no { get; set; }
    public string? hbl_it_date { get; set; }
    public string? hbl_it_port { get; set; }
    public int? hbl_it_pcs { get; set; }
    public decimal? hbl_it_wt { get; set; }
    public string? hbl_it_no2 { get; set; }//
    public string? hbl_it_date2 { get; set; }//
    public string? hbl_it_port2 { get; set; }//
    public int? hbl_it_pcs2 { get; set; }//
    public decimal? hbl_it_wt2 { get; set; }//
    public string? hbl_it_no3 { get; set; }//
    public string? hbl_it_date3 { get; set; }//
    public string? hbl_it_port3 { get; set; }
    public int? hbl_it_pcs3 { get; set; }
    public decimal? hbl_it_wt3 { get; set; }

    public string? hbl_place_final { get; set; }
    public string? hbl_plf_eta { get; set; }
    public string? hbl_frt_status_name { get; set; }
    public int? hbl_uom_id { get; set; }
    public string? hbl_uom_name { get; set; }
    public int? hbl_packages { get; set; }
    public decimal? hbl_weight { get; set; }
    public decimal? hbl_lbs { get; set; }
    public decimal? hbl_chwt_lbs { get; set; }
    public decimal? hbl_chwt { get; set; }
    public string? hbl_commodity { get; set; }
    public int? hbl_handled_id { get; set; }
    public string? hbl_handled_name { get; set; }
    public int? hbl_salesman_id { get; set; }
    public string? hbl_salesman_name { get; set; }
    public string? hbl_remark1 { get; set; }
    public string? hbl_remark2 { get; set; }
    public string? hbl_remark3 { get; set; }
    public string? hbl_lfd_date { get; set; }

    public string? hbl_pickup_date { get; set; }
    public int? hbl_careof_id { get; set; }
    public string? hbl_careof_name { get; set; }
    public string? hbl_pono { get; set; }
    public int? hbl_paid_status_id { get; set; }
    public string? hbl_paid_status_name { get; set; }
    public string? hbl_cargo_release_status { get; set; }
    public string? hbl_is_itshipment { get; set; }
    public string? hbl_book_slno { get; set; }
    public string? hbl_is_pl { get; set; }
    public string? hbl_is_ci { get; set; }
    public string? hbl_is_carr_an { get; set; }
    public string? hbl_custom_reles_status { get; set; }
    public string? hbl_is_delivery { get; set; }
    public string? hbl_paid_remarks { get; set; }
    public string? hbl_delivery_date { get; set; }
    public int? hbl_incoterm_id { get; set; }
    public string? hbl_incoterm { get; set; }
    public string? hbl_invoiceno { get; set; }    

    public int desc_parent_id { get; set; }
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