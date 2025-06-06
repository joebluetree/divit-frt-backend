using System;
using Database.Models.BaseTables;

namespace Common.DTO.AirExport;

public class cargo_air_exportm_dto : basetable_dto
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
public string? mbl_by_carrier1 { get; set; }
public string? mbl_by_carrier2 { get; set; }
public string? mbl_by_carrier3 { get; set; }
public string? mbl_to_port1 { get; set; }
public string? mbl_to_port2 { get; set; }
public string? mbl_to_port3 { get; set; }
public int? mbl_currency_id { get; set; }
public string? mbl_currency_code { get; set; }
public int? mbl_handled_id { get; set; }
public string? mbl_handled_name { get; set; }
public int? mbl_salesman_id { get; set; }
public string? mbl_salesman_name { get; set; }
public decimal? mbl_mawb_weight { get; set; }
public decimal? mbl_mawb_chwt { get; set; }
public string? mbl_3rdparty { get; set; }
public string? mbl_direct { get; set; }
public string? mbl_vessel_name { get; set; }
public string? mbl_voyage { get; set; }
public int? rec_files_count { get; set; }
public string? rec_files_attached { get; set; }
public int? rec_memo_count { get; set; }
public string? rec_memo_attached { get; set; }
public List<cargo_air_exporth_dto>? air_export {get; set;}       

}
