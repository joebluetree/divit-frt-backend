using System;
using Database.Models.BaseTables;

namespace Common.DTO.AirExport;

public class cargo_air_exporth_dto : basetable_dto
{
    public int hbl_id { get; set; }
    public int hbl_cfno { get; set; }
    public string? hbl_houseno { get; set; }
    public int hbl_mbl_id { get; set; }
    public string? hbl_mbl_refno { get; set; }
    public int? hbl_shipment_stage_id { get; set; }
    public string? hbl_shipment_stage_name { get; set; }
    public string? hbl_date { get; set; }
    public string? hbl_from_date { get; set; }
    public string? hbl_to_date { get; set; }
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
    public string? hbl_consigned_code { get; set; }
    public string? hbl_consigned_to1 { get; set; }
    public string? hbl_consigned_to2 { get; set; }
    public string? hbl_consigned_to3 { get; set; }
    public string? hbl_consigned_to4 { get; set; }
    public string? hbl_consigned_to5 { get; set; }
    public string? hbl_consigned_to6 { get; set; }
    public string? hbl_notify_name { get; set; }
    public string? hbl_notify_add1 { get; set; }
    public string? hbl_notify_add2 { get; set; }
    public string? hbl_notify_add3 { get; set; }


    public string? hbl_exp_ref1 { get; set; }
    public string? hbl_exp_ref2 { get; set; }
    public string? hbl_exp_ref3 { get; set; }
    public string? hbl_agent_name { get; set; }
    public string? hbl_agent_city { get; set; }
    public string? hbl_place_delivery { get; set; }
    public string? hbl_iata { get; set; }
    public string? hbl_accno { get; set; }
    public string? hbl_frt_status_name { get; set; }
    public string? hbl_oc_status { get; set; }
    public string? hbl_carriage_value { get; set; }
    public string? hbl_customs_value { get; set; }
    public string? hbl_ins_amt { get; set; }
    public string? hbl_aesno { get; set; }
    public string? hbl_lcno { get; set; }


    public string? hbl_bltype { get; set; }
    public int? hbl_handled_id { get; set; }
    public string? hbl_handled_name { get; set; }
    public int? hbl_salesman_id { get; set; }
    public string? hbl_salesman_name { get; set; }
    public string? hbl_goods_nature { get; set; }
    public string? hbl_commodity { get; set; }
    public int? hbl_format_id { get; set; }
    public string? hbl_format_name { get; set; }
    public string? hbl_rout1 { get; set; }
    public string? hbl_rout2 { get; set; }
    public string? hbl_rout3 { get; set; }
    public string? hbl_pol_name { get; set; }
    public string? hbl_pod_name { get; set; }

    public string? hbl_asarranged_consignee { get; set; }
    public string? hbl_asarranged_shipper { get; set; }

    public int? hbl_packages { get; set; }
    public decimal? hbl_weight { get; set; }
    public string? hbl_weight_unit { get; set; }
    public string? hbl_class { get; set; }
    public string? hbl_comm { get; set; }
    public decimal? hbl_chwt { get; set; }
    public decimal? hbl_rate { get; set; }
    public decimal? hbl_total { get; set; }


    public string? hbl_toagent1 { get; set; }
    public decimal? hbl_rate1 { get; set; }
    public decimal? hbl_total1 { get; set; }
    public string? hbl_printsc1 { get; set; }
    public string? hbl_printsc2 { get; set; }

    public string? hbl_toagent2 { get; set; }
    public decimal? hbl_rate2 { get; set; }
    public decimal? hbl_total2 { get; set; }
    public string? hbl_printsc3 { get; set; }
    public string? hbl_printsc4 { get; set; }

    public string? hbl_toagent3 { get; set; }
    public decimal? hbl_rate3 { get; set; }
    public decimal? hbl_total3 { get; set; }
    public string? hbl_printsc5 { get; set; }
    public string? hbl_printsc6 { get; set; }

    public string? hbl_toagent4 { get; set; }
    public decimal? hbl_rate4 { get; set; }
    public decimal? hbl_total4 { get; set; }
    public string? hbl_printsc7 { get; set; }
    public string? hbl_printsc8 { get; set; }

    public string? hbl_toagent5 { get; set; }
    public decimal? hbl_rate5 { get; set; }
    public decimal? hbl_total5 { get; set; }
    public string? hbl_printsc9 { get; set; }
    public string? hbl_printsc10 { get; set; }

    public string? hbl_tocarrier1 { get; set; }
    public decimal? hbl_carrate1 { get; set; }
    public decimal? hbl_cartotal1 { get; set; }
    public string? hbl_carprintsc1 { get; set; }
    public string? hbl_carprintsc2 { get; set; }

    public string? hbl_tocarrier2 { get; set; }
    public decimal? hbl_carrate2 { get; set; }
    public decimal? hbl_cartotal2 { get; set; }
    public string? hbl_carprintsc3 { get; set; }
    public string? hbl_carprintsc4 { get; set; }

    public string? hbl_tocarrier3 { get; set; }
    public decimal? hbl_carrate3 { get; set; }
    public decimal? hbl_cartotal3 { get; set; }
    public string? hbl_carprintsc5 { get; set; }
    public string? hbl_carprintsc6 { get; set; }


    public string? hbl_charges1 { get; set; }
    public string? hbl_charges2 { get; set; }
    public string? hbl_charges3 { get; set; }
    public string? hbl_charges4 { get; set; }
    public string? hbl_charges5 { get; set; }
    public string? hbl_charges1_carrier { get; set; }
    public string? hbl_charges2_carrier { get; set; }
    public string? hbl_charges3_carrier { get; set; }

    public string? hbl_remark1 { get; set; }
    public string? hbl_remark2 { get; set; }
    public string? hbl_remark3 { get; set; }
    public string? hbl_by1 { get; set; }
    public string? hbl_by1_carrier { get; set; }
    public string? hbl_by2 { get; set; }
    public string? hbl_by2_carrier { get; set; }
    public string? hbl_issued_date { get; set; }
    public string? hbl_delivery_date { get; set; }
    public string? hbl_issued_by { get; set; }


    public int desc_parent_id { get; set; } = 0;
    public string? desc_parent_type { get; set; } = "";
    public int? desc_ctr { get; set; } = 0;
    public int desc_id1 { get; set; } = 0;
    public int desc_id2 { get; set; } = 0;
    public int desc_id3 { get; set; } = 0;
    public int desc_id4 { get; set; } = 0;
    public int desc_id5 { get; set; } = 0;
    public int desc_id6 { get; set; } = 0;
    public int desc_id7 { get; set; } = 0;
    public int desc_id8 { get; set; } = 0;
    public int desc_id9 { get; set; } = 0;
    public int desc_id10 { get; set; } = 0;
    public int desc_id11 { get; set; } = 0;
    public int desc_id12 { get; set; } = 0;
    public int desc_id13 { get; set; } = 0;
    public int desc_id14 { get; set; } = 0;
    public int desc_id15 { get; set; } = 0;
    public int desc_id16 { get; set; } = 0;
    public int desc_id17 { get; set; } = 0;

    public string desc_mark1 { get; set; } = "";
    public string desc_mark2 { get; set; } = "";
    public string desc_mark3 { get; set; } = "";
    public string desc_mark4 { get; set; } = "";
    public string desc_mark5 { get; set; } = "";
    public string desc_mark6 { get; set; } = "";
    public string desc_mark7 { get; set; } = "";
    public string desc_mark8 { get; set; } = "";
    public string desc_mark9 { get; set; } = "";
    public string desc_mark10 { get; set; } = "";

    public string desc_description1 { get; set; } = "";
    public string desc_description2 { get; set; } = "";
    public string desc_description3 { get; set; } = "";
    public string desc_description4 { get; set; } = "";
    public string desc_description5 { get; set; } = "";
    public string desc_description6 { get; set; } = "";
    public string desc_description7 { get; set; } = "";
    public string desc_description8 { get; set; } = "";
    public string desc_description9 { get; set; } = "";
    public string desc_description10 { get; set; } = "";
    public string desc_description11 { get; set; } = "";
    public string desc_description12 { get; set; } = "";
    public string desc_description13 { get; set; } = "";
    public string desc_description14 { get; set; } = "";
    public string desc_description15 { get; set; } = "";
    public string desc_description16 { get; set; } = "";
    public string desc_description17 { get; set; } = "";


}