using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Alen Cherian
//Created Date : 21/02/2025
//Remark : Version 1.0 , 22/02/2025

namespace Database.Models.Cargo;

public class cargo_masterm
{
    [Key]
    public int mbl_id { get; set; }
    public int mbl_cfno { get; set; }
    public string? mbl_refno { get; set; }
    public DateTime? mbl_ref_date { get; set; }
    public string? mbl_mode { get; set; }
    public DateTime? mbl_date { get; set; }
    public int? mbl_agent_id { get; set; }
    public int? mbl_liner_id { get; set; }
    public string? mbl_liner_bookingno { get; set; }
    public int? mbl_country_id { get; set; }
    public string? mbl_direct { get; set; }
    public int? mbl_pol_id { get; set; }
    public DateTime? mbl_pol_etd { get; set; }
    public int? mbl_pod_id { get; set; }
    public DateTime? mbl_pod_eta { get; set; }
    public string? mbl_place_delivery { get; set; }
    public int? mbl_pofd_id { get; set; }
    public DateTime? mbl_pofd_eta { get; set; }
    public string? mbl_frt_status_name { get; set; }
    public int? mbl_ship_term_id { get; set; }
    public string? mbl_cntr_type { get; set; }
    public DateTime? mbl_it_date { get; set; }
    public string? mbl_it_port { get; set; }
    public int? mbl_cargo_loc_id { get; set; }
    public string? mbl_cargo_loc_name { get; set; }
    public int? mbl_devan_loc_id { get; set; }
    public string? mbl_devan_loc_name { get; set; }
    public int? mbl_handled_id { get; set; }
    public string? mbl_is_held { get; set; }
    public int? mbl_shipper_id { get; set; }
    public int? mbl_consignee_id { get; set; }
    public int? mbl_house_tot { get; set; }
    public decimal? mbl_cntr_cbm { get; set; }
    public int? mbl_container_tot { get; set; }
    public string? mbl_remarks { get; set; }
    public int? mbl_shipper_tot { get; set; }
    public int? mbl_consignee_tot { get; set; }
    public string? mbl_profit_type { get; set; }
    public int? mbl_jobtype_id { get; set; }
    public int? mbl_salesman_id { get; set; }
    public string? mbl_rotation_no { get; set; }
    public string? mbl_status { get; set; }
    public string? mbl_is_sea_waybill { get; set; }
    public DateTime? mbl_ombl_sent_on { get; set; }
    public string? mbl_pending_status { get; set; }
    public DateTime? mbl_unlock_date { get; set; }
    public string? mbl_ombl_sent_ampm { get; set; }
    public int? mbl_book_slno { get; set; }
    public string? mbl_3rdparty { get; set; }
    public string? mbl_isfadjust { get; set; }
    public string? mbl_ulcode { get; set; }
    public string? mbl_inv_stage { get; set; }
    public string? mbl_cntr_desc { get; set; }
    public string? mbl_por { get; set; }
    public int? mbl_cooformat_id { get; set; }
    public DateTime? mbl_of_sent_on { get; set; }
    public int? mbl_coloader_id { get; set; }
    public int? mbl_customer_id { get; set; }
    public string? mbl_software_name { get; set; }
    public string? mbl_it_tot { get; set; }
    public string? mbl_incoterm { get; set; }
    public string? mbl_bo_status { get; set; }
    public string? mbl_bo_attended_code { get; set; }
    public DateTime? mbl_bo_attended_date { get; set; }
    public string? mbl_house_nos { get; set; }
    public DateTime? mbl_carrier_an_recd_dt { get; set; }
    public DateTime? mbl_an_sent_dt { get; set; }
    public DateTime? mbl_stage_changed_date { get; set; }
    public int? mbl_shipment_stage_id { get; set; }
    public string? mbl_no { get; set; }
    public int? mbl_vessel_id { get; set; }
    public string? mbl_vessel_name { get; set; }
    public string? mbl_voyage { get; set; }
    public string? mbl_telex_released { get; set; }
    public string? mbl_it_no { get; set; }
    public string? mbl_cargo_loc_add1 { get; set; }
    public string? mbl_cargo_loc_add2 { get; set; }
    public string? mbl_cargo_loc_add3 { get; set; }
    public string? mbl_cargo_loc_add4 { get; set; }
    public string? mbl_devan_loc_add1 { get; set; }
    public string? mbl_devan_loc_add2 { get; set; }
    public string? mbl_devan_loc_add3 { get; set; }
    public string? mbl_devan_loc_add4 { get; set; }
    public string? mbl_by_carrier1 { get; set; }
    public string? mbl_by_carrier2 { get; set; }
    public string? mbl_by_carrier3 { get; set; }
    public int? mbl_currency_id { get; set; }
    public string? mbl_to_port1 { get; set; }
    public string? mbl_to_port2 { get; set; }
    public string? mbl_to_port3 { get; set; }
    public decimal? mbl_teu { get; set; }
    public decimal? mbl_20 { get; set; }
    public decimal? mbl_40 { get; set; }
    public decimal? mbl_40hq { get; set; }
    public decimal? mbl_45 { get; set; }
    public decimal? mbl_pcs { get; set; }
    public decimal? mbl_weight { get; set; }
    public decimal? mbl_weight_lbs { get; set; }
    public decimal? mbl_chwt { get; set; }
    public decimal? mbl_chwt_lbs { get; set; }
    public decimal? mbl_cbm { get; set; }
    public decimal? mbl_cft { get; set; }
    public decimal? mbl_mawb_weight { get; set; }
    public decimal? mbl_mawb_chwt { get; set; }
    public decimal? mbl_inc_total { get; set; }
    public decimal? mbl_exp_total { get; set; }
    public decimal? mbl_revenue { get; set; }
    public string? mbl_type { get; set; }
    public string? mbl_sub_houseno { get; set; }
    public string? rec_files_attached { get; set; }
    public decimal? mbl_per { get; set; }
    public string? mbl_lock { get; set; }
    public int? mbl_zero_cbm { get; set; }
    public int? mbl_zero_chwt { get; set; }
    public int? mbl_zero_wt { get; set; }
    public string? mbl_loss_approved { get; set; }

    [ForeignKey("mbl_agent_id")]
    public mast_customerm? agent { get; set; }

    [ForeignKey("mbl_liner_id")]
    public mast_param? liner { get; set; }

    [ForeignKey("mbl_country_id")]
    public mast_param? country { get; set; }

    [ForeignKey("mbl_pol_id")]
    public mast_param? pol { get; set; }

    [ForeignKey("mbl_pod_id")]
    public mast_param? pod { get; set; }

    [ForeignKey("mbl_pofd_id")]
    public mast_param? pofd { get; set; }

    [ForeignKey("mbl_vessel_id")]
    public mast_param? vessel { get; set; }

    [ForeignKey("mbl_currency_id")]
    public mast_param? currency { get; set; }

    [ForeignKey("mbl_shipment_stage_id")]
    public mast_param? shipstage { get; set; }

    [ForeignKey("mbl_ship_term_id")]
    public mast_param? shipterm { get; set; }

    [ForeignKey("mbl_cargo_loc_id")]
    public mast_param? cargoloc { get; set; }

    [ForeignKey("mbl_devan_loc_id")]
    public mast_param? devanloc { get; set; }

    [ForeignKey("mbl_handled_id")]
    public mast_param? handledby { get; set; }

    [ForeignKey("mbl_shipper_id")]
    public mast_customerm? shipper { get; set; }

    [ForeignKey("mbl_customer_id")]
    public mast_customerm? customer { get; set; }

    [ForeignKey("mbl_consignee_id")]
    public mast_param? consignee { get; set; }

    [ForeignKey("mbl_jobtype_id")]
    public mast_param? jobtype { get; set; }

    [ForeignKey("mbl_salesman_id")]
    public mast_param? salesman { get; set; }

    [ConcurrencyCheck]
    public int? rec_year { get; set; }
    public int rec_version { get; set; }
    public string? rec_locked { get; set; }
    public string? rec_created_by { get; set; }
    public DateTime rec_created_date { get; set; }
    public string? rec_edited_by { get; set; }
    public DateTime? rec_edited_date { get; set; }
    public int rec_company_id { get; set; }
    public int rec_branch_id { get; set; }

    [ForeignKey("rec_company_id")]
    public mast_companym? company { get; set; }

    [ForeignKey("rec_branch_id")]
    public mast_branchm? branch { get; set; }
}
