
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Masters;
using Database.Models.UserAdmin;

    //Name : Alen Cherian
    //Created Date : 21/02/2025
    //Remark : Version 1.0 , 22/02/2025

namespace Database.Models.Cargo;

public class cargo_housem
{
    [Key]
    public int hbl_id { get; set; }
    public int hbl_cfno { get; set; }
    public int hbl_mbl_id { get; set; }
    public string? hbl_houseno { get; set; }
    public DateTime? hbl_date { get; set; }
    public string? hbl_bltype { get; set; }
    public string? hbl_mode { get; set; }
    public int? hbl_shipper_id { get; set; }
    public string? hbl_shipper_name { get; set; }
    public string? hbl_shipper_add1 { get; set; }
    public string? hbl_shipper_add2 { get; set; }
    public string? hbl_shipper_add3 { get; set; }
    public string? hbl_shipper_add4 { get; set; }
    public string? hbl_shipper_add5 { get; set; }
    public int? hbl_consignee_id { get; set; }
    public string? hbl_consignee_name { get; set; }
    public string? hbl_consignee_add1 { get; set; }
    public string? hbl_consignee_add2 { get; set; }
    public string? hbl_consignee_add3 { get; set; }
    public string? hbl_consignee_add4 { get; set; }
    public string? hbl_consignee_add5 { get; set; }//
    public int? hbl_notify_id { get; set; }
    public string? hbl_notify_name { get; set; }
    public string? hbl_notify_add1 { get; set; }
    public string? hbl_notify_add2 { get; set; }
    public string? hbl_notify_add3 { get; set; }
    public string? hbl_notify_add4 { get; set; }
    public string? hbl_notify_add5 { get; set; }
    public int? hbl_agent_id { get; set; }
    public int? hbl_cha_id { get; set; }
    public string? hbl_cha_name { get; set; }
    public string? hbl_cha_attn { get; set; }
    public string? hbl_cha_tel { get; set; }
    public string? hbl_cha_fax { get; set; }
    public int? hbl_location_id { get; set; }
    public string? hbl_location_name { get; set; }
    public string? hbl_location_add1 { get; set; }
    public string? hbl_location_add2 { get; set; }
    public string? hbl_location_add3 { get; set; }
    public string? hbl_location_add4 { get; set; }
    public string? hbl_location_add5 { get; set; }
    public string? hbl_consigned_to1 { get; set; }
    public string? hbl_consigned_to2 { get; set; }
    public string? hbl_consigned_to3 { get; set; }
    public string? hbl_consigned_to4 { get; set; }
    public string? hbl_consigned_to5 { get; set; }
    public string? hbl_ams_fileno { get; set; }
    public string? hbl_sub_house { get; set; }//
    public string? hbl_it_no { get; set; }
    public DateTime? hbl_it_date { get; set; }
    public string? hbl_it_port { get; set; }
    public int? hbl_it_pcs { get; set; }
    public decimal? hbl_it_wt { get; set; }
    public string? hbl_it_no2 { get; set; }//
    public DateTime? hbl_it_date2 { get; set; }//
    public string? hbl_it_port2 { get; set; }//
    public int? hbl_it_pcs2 { get; set; }//
    public decimal? hbl_it_wt2 { get; set; }//
    public string? hbl_it_no3 { get; set; }//
    public DateTime? hbl_it_date3 { get; set; }//
    public string? hbl_it_port3 { get; set; }
    public int? hbl_it_pcs3 { get; set; }
    public decimal? hbl_it_wt3 { get; set; }
    public string? hbl_telex_released { get; set; }
    public string? hbl_place_delivery { get; set; }
    public string? hbl_place_final { get; set; }
    public DateTime? hbl_pld_eta { get; set; }
    public DateTime? hbl_plf_eta { get; set; }
    public string? hbl_frt_status_name { get; set; }
    public int? hbl_ship_term_id { get; set; }
    public int? hbl_uom_id { get; set; }
    public int? hbl_pcs { get; set; }
    public int? hbl_packages { get; set; }
    public decimal? hbl_cbm { get; set; }
    public decimal? hbl_weight { get; set; }
    public decimal? hbl_chwt { get; set; }
    public decimal? hbl_lbs { get; set; }
    public decimal? hbl_cft { get; set; }
    public decimal? hbl_chwt_lbs { get; set; }
    public string? hbl_commodity { get; set; }
    public int? hbl_salesman_id { get; set; }
    public int? hbl_handled_id { get; set; }
    public string? hbl_isf_no { get; set; }
    public string? hbl_mov_dad { get; set; }
    public string? hbl_bl_req { get; set; }
    public string? hbl_remark1 { get; set; }
    public string? hbl_remark2 { get; set; }
    public string? hbl_remark3 { get; set; }

    public string? hbl_devan_instr1 { get; set; }
    public string? hbl_devan_instr2 { get; set; }
    public string? hbl_devan_instr3 { get; set; }
    public DateTime? hbl_lfd_date { get; set; }
    public DateTime? hbl_go_date { get; set; }
    public string? hbl_place_receipt { get; set; }
    public string? hbl_pod_name { get; set; }
    public DateTime? hbl_pofd_eta { get; set; }
    public int? hbl_pofd_id { get; set; }
    public string? hbl_pofd_name { get; set; }
    public string? hbl_pol_name { get; set; }
    public string? hbl_pre_carriage { get; set; }
    public string? hbl_print_kgs { get; set; }
    public string? hbl_print_lbs { get; set; }
    public decimal? hbl_rate { get; set; }
    public string? hbl_accno { get; set; }
    public string? hbl_aesno { get; set; }
    public string? hbl_agent_name { get; set; }
    public string? hbl_agent_city { get; set; }
    public string? hbl_asarranged_consignee { get; set; }
    public string? hbl_asarranged_shipper { get; set; }
    public string? hbl_by1 { get; set; }
    public string? hbl_by1_carrier { get; set; }
    public string? hbl_by2 { get; set; }
    public string? hbl_by2_carrier { get; set; }
    public string? hbl_carriage_value { get; set; }
    public string? hbl_charges1 { get; set; }
    public string? hbl_charges1_carrier { get; set; }
    public string? hbl_charges2 { get; set; }
    public string? hbl_charges2_carrier { get; set; }
    public string? hbl_charges3 { get; set; }
    public string? hbl_charges3_carrier { get; set; }
    public string? hbl_charges4 { get; set; }
    public string? hbl_charges5 { get; set; }
    public string? hbl_class { get; set; }
    public string? hbl_clean { get; set; }
    public string? hbl_comm { get; set; }
    public string? hbl_customs_value { get; set; }
    public string? hbl_exp_ref1 { get; set; }
    public string? hbl_exp_ref2 { get; set; }
    public string? hbl_exp_ref3 { get; set; }
    public string? hbl_exp_ref4 { get; set; }
    public string? hbl_goods_nature { get; set; }
    public string? hbl_iata { get; set; }
    public string? hbl_ins_amt { get; set; }
    public string? hbl_is_arranged { get; set; }
    public string? hbl_is_cntrized { get; set; }
    public string? hbl_issued_by { get; set; }
    public DateTime? hbl_issued_date { get; set; }
    public string? hbl_lcno { get; set; }
    public string? hbl_oc_status { get; set; }
    public string? hbl_origin { get; set; }
    public int? hbl_originals { get; set; }
    public string? hbl_rout1 { get; set; }
    public string? hbl_rout2 { get; set; }
    public string? hbl_rout3 { get; set; }
    public string? hbl_rout4 { get; set; }
    public string? hbl_terminal { get; set; }
    public decimal? hbl_total { get; set; }
    public string? hbl_type_move { get; set; }
    public string? hbl_weight_unit { get; set; }
    public decimal? hbl_inc_total_wt { get; set; }
    public decimal? hbl_exp_total_wt { get; set; }
    public decimal? hbl_revenue_wt { get; set; }
    public decimal? hbl_inc_total_cbm { get; set; }
    public decimal? hbl_exp_total_cbm { get; set; }
    public decimal? hbl_revenue_cbm { get; set; }
    public DateTime? hbl_pickup_date { get; set; }
    public DateTime? hbl_empty_ret_date { get; set; }
    public string? hbl_obl_slno { get; set; }
    public string? hbl_obl_telex { get; set; }
    public int? hbl_careof_id { get; set; }
    public string? hbl_pono { get; set; }
    public string? hbl_boeno { get; set; }
    public int? hbl_format_id { get; set; }
    public string? hbl_paid_status { get; set; }
    public string? hbl_bl_status { get; set; }
    public string? hbl_cargo_release_status { get; set; }
    public int? hbl_shipment_stage_id { get; set; }
    public string? hbl_issued_place { get; set; }
    public int? hbl_draft_format_id { get; set; }
    public string? rec_files_attached { get; set; }
    public string? hbl_is_itshipment { get; set; }
    public string? hbl_book_slno { get; set; }
    public string? hbl_isf_attached { get; set; }
    public string? hbl_is_pl { get; set; }
    public string? hbl_is_ci { get; set; }
    public string? hbl_is_carr_an { get; set; }
    public string? hbl_custom_reles_status { get; set; }
    public string? hbl_is_delivery { get; set; }
    public string? hbl_paid_remarks { get; set; }
    public string? hbl_consigned_to6 { get; set; }
    public DateTime? hbl_delivery_date { get; set; }
    public DateTime? hbl_custom_clear_date { get; set; }
    public int? hbl_container_tot { get; set; }
    public string? hbl_incoterm { get; set; }
    public string? hbl_software_name { get; set; }
    public string? hbl_an_sent { get; set; }
    public string? hbl_an_sent_by { get; set; }
    public DateTime? hbl_an_sent_date { get; set; }
    public string? hbl_invoiceno { get; set; }


    [ForeignKey("hbl_mbl_id")]
    public cargo_masterm? master { get; set; }

    [ForeignKey("hbl_shipper_id")]
    public mast_customerm? shipper { get; set; }

    [ForeignKey("hbl_consignee_id")]
    public mast_customerm? consignee { get; set; }

    [ForeignKey("hbl_notify_id")]
    public mast_customerm? notify { get; set; }

    [ForeignKey("hbl_agent_id")]
    public mast_customerm? agent { get; set; }

    [ForeignKey("hbl_cha_id")]
    public mast_customerm? cha { get; set; }

    [ForeignKey("hbl_location_id")]
    public mast_customerm? location { get; set; }

    [ForeignKey("hbl_ship_term_id")]
    public mast_param? shipterm { get; set; }

    [ForeignKey("hbl_salesman_id")]
    public mast_param? salesman { get; set; }

    [ForeignKey("hbl_handled_id")]
    public mast_param? handledby { get; set; }

        
    [ForeignKey("hbl_shipment_stage_id")]
    public mast_param? shipstage { get; set; }

    [ForeignKey("hbl_pofd_id")] //
    public mast_param? pofd { get; set; }

    [ForeignKey("hbl_careof_id")]//
    public mast_param? careof { get; set; }

    [ForeignKey("hbl_format_id")]//
    public mast_param? format { get; set; }

    [ForeignKey("hbl_draft_format_id")]//
    public mast_param? draftformat { get; set; }

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
