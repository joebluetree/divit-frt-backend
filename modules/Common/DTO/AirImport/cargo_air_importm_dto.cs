using System;
using Database.Models.BaseTables;

namespace Common.DTO.AirImport;

public class cargo_air_importm_dto : basetable_dto
{
public int mbl_id { get; set; }
public int mbl_cfno { get; set; }
public string? mbl_refno { get; set; }
public string? mbl_ref_date { get; set; }
public string? mbl_from_date { get; set; }
public string? mbl_to_date { get; set; }
public int? mbl_shipment_stage_id { get; set; }
public string? mbl_shipment_stage_name {get; set; }
public string? mbl_mode { get; set; }
public string? mbl_no { get; set; }
public int? mbl_agent_id { get; set; }
public string? mbl_agent_name { get; set; }
public string? mbl_frt_status_name { get; set; }
public int? mbl_pol_id { get; set; }
public string? mbl_pol_name { get; set; }
public string? mbl_pol_etd { get; set; }
public int? mbl_pod_id { get; set; }
public string? mbl_pod_name { get; set; }
public string? mbl_pod_eta { get; set; }

public int? mbl_country_id { get; set; }
public string? mbl_country_name { get; set; }
public int? mbl_liner_id { get; set; }
public string? mbl_liner_name { get; set; }
public int? mbl_handled_id { get; set; }
public string? mbl_handled_name { get; set; }
public int? mbl_salesman_id { get; set; }
public string? mbl_salesman_name { get; set; }
public decimal? mbl_mawb_weight { get; set; }
public decimal? mbl_mawb_chwt { get; set; }
public string? mbl_vessel_name { get; set; }

public int? mbl_cargo_loc_id { get; set; }
public string? mbl_cargo_loc_code { get; set; }
public string? mbl_cargo_loc_name { get; set; }
public string? mbl_cargo_loc_add1 { get; set; }
public string? mbl_cargo_loc_add2 { get; set; }
public string? mbl_cargo_loc_add3 { get; set; }
public string? mbl_cargo_loc_add4 { get; set; }
public int? mbl_incoterm_id { get; set; }
public string? mbl_incoterm { get; set; }

public string? mbl_stage_changed_date { get; set; }
public string? mbl_an_sent_dt { get; set; }

public List<cargo_air_importh_dto>? air_import {get; set;}       

}
