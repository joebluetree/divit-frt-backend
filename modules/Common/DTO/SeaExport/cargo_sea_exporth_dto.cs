using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 03/01/2025
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.SeaExport
{
    public class cargo_sea_exporth_dto : basetable_dto
    {
        public int hbl_id { get; set; } = 0;
        public int hbl_mbl_id { get; set; } = 0;//fk
        public string? hbl_mbl_refno { get; set; }= "";
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
        public int? hbl_notify_id { get; set; } = 0;
        public string? hbl_notify_code { get; set; } = "";
        public string? hbl_notify_name { get; set; } = "";
        public string? hbl_notify_add1 { get; set; } = "";
        public string? hbl_notify_add2 { get; set; } = "";
        public string? hbl_notify_add3 { get; set; } = "";
        public string? hbl_notify_add4 { get; set; } = "";
        public string? hbl_notify_add5 { get; set; } = "";
        public int? hbl_agent_id { get; set; } = 0;
        public string? hbl_agent_name { get; set; } = "";
        public string? hbl_consigned_to1 { get; set; } = "";
        public string? hbl_consigned_to2 { get; set; } = "";
        public string? hbl_consigned_to3 { get; set; } = "";
        public string? hbl_consigned_to4 { get; set; } = "";
        public string? hbl_consigned_to5 { get; set; } = "";
        public string? hbl_place_delivery { get; set; } = "";
        public string? hbl_frt_status_name { get; set;} = "";
        public int? hbl_uom_id { get; set; } = 0;
        public string? hbl_uom_name { get; set; } = "";
        public int? hbl_pcs { get; set; } = 0;
        public int? hbl_packages { get; set; } = 0;
        public decimal? hbl_cbm { get; set; } = 0;
        public decimal? hbl_weight { get; set; } = 0;
        public decimal? hbl_lbs { get; set; } = 0;
        public decimal? hbl_cft { get; set; } = 0;
        public string? hbl_commodity { get; set; } = "";
        public int? hbl_salesman_id { get; set; } = 0;
        public string? hbl_salesman_name { get; set; } = "";
        public int? hbl_handled_id { get; set; } = 0;
        public string? hbl_handled_name { get; set; } = "";
        public string? hbl_remark1 { get; set; } = "";
        public string? hbl_remark2 { get; set; } = "";
        public string? hbl_remark3 { get; set; } = "";

        public string? hbl_devan_instr1 { get; set; } = "";
        public string? hbl_devan_instr2 { get; set; } = "";
        public string? hbl_devan_instr3 { get; set; } = "";
        public string? hbl_lfd_date { get; set; } = "";
        public string? hbl_go_date { get; set; } = "";
        public string? hbl_place_receipt { get; set; } = "";
        public string? hbl_pod_name { get; set; } = "";
        public string? hbl_pofd_name { get; set; } = "";
        public string? hbl_pol_name { get; set; } = "";
        public string? hbl_pre_carriage { get; set; } = "";
        public string? hbl_print_kgs { get; set; } = "";
        public string? hbl_print_lbs { get; set; } = "";
        public string? hbl_asarranged_consignee { get; set; } = "";
        public string? hbl_asarranged_shipper { get; set; } = "";
        public string? hbl_by1 { get; set; } = "";
        public string? hbl_by1_carrier { get; set; } = "";
        public string? hbl_by2 { get; set; } = "";
        public string? hbl_by2_carrier { get; set; } = "";
        public string? hbl_clean { get; set; } = "";
        public string? hbl_comm { get; set; } = "";
        public string? hbl_customs_value { get; set; } = "";
        public string? hbl_exp_ref1 { get; set; } = "";
        public string? hbl_exp_ref2 { get; set; } = "";
        public string? hbl_exp_ref3 { get; set; } = "";
        public string? hbl_exp_ref4 { get; set; } = "";
        public string? hbl_goods_nature { get; set; } = "";
        public string? hbl_is_arranged { get; set; } = "";
        public string? hbl_is_cntrized { get; set; } = "";
        public string? hbl_issued_date { get; set; } = "";
        public string? hbl_origin { get; set; } = "";
        public int? hbl_originals { get; set; } = 0;
        public string? hbl_rout1 { get; set; } = "";
        public string? hbl_rout2 { get; set; } = "";
        public string? hbl_rout3 { get; set; } = "";
        public string? hbl_rout4 { get; set; } = "";
        public string? hbl_type_move { get; set; } = "";
        public string? hbl_obl_slno { get; set; } = "";
        public string? hbl_obl_telex { get; set; } = "";
        public int? hbl_format_id { get; set; } = 0;
        public string? hbl_format_name { get; set; } = "";
        public string? hbl_issued_place { get; set; } = "";
        public int? hbl_draft_format_id { get; set;} = 0;
        public string? hbl_draft_format_name { get; set; } = "";
        public string? hbl_delivery_date { get; set; } = "";

        
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
        public int desc_id10 {get; set; } = 0;
        public int desc_id11 { get; set; } = 0;
        public int desc_id12 { get; set; } = 0;
        public int desc_id13 { get; set; } = 0;
        public int desc_id14 { get; set; } = 0;
        public int desc_id15 { get; set; } = 0;
        public int desc_id16 { get; set; } = 0;
        public int desc_id17 { get; set; } = 0;

        public string? desc_mark1 { get; set; } = "";
        public string? desc_mark2 { get; set; } = "";
        public string? desc_mark3 { get; set; } = "";
        public string? desc_mark4 { get; set; } = "";
        public string? desc_mark5 { get; set; } = "";
        public string? desc_mark6 { get; set; } = "";
        public string? desc_mark7 { get; set; } = "";
        public string? desc_mark8 { get; set; } = "";
        public string? desc_mark9 { get; set; } = "";
        public string? desc_mark10 { get; set; } = "";
        public string? desc_mark11 { get; set; } = "";
        public string? desc_mark12 { get; set; } = "";
        public string? desc_mark13 { get; set; } = "";
        public string? desc_mark14 { get; set; } = "";
        public string? desc_mark15 { get; set; } = "";
        public string? desc_mark16 { get; set; } = "";
        public string? desc_mark17 { get; set; } = "";
        public string? desc_package1 { get; set; } = "";
        public string? desc_package2 { get; set; } = "";
        public string? desc_package3 { get; set; } = "";
        public string? desc_description1 { get; set; } = "";
        public string? desc_description2 { get; set; } = "";
        public string? desc_description3 { get; set; } = "";
        public string? desc_description4 { get; set; } = "";
        public string? desc_description5 { get; set; } = "";
        public string? desc_description6 { get; set; } = "";
        public string? desc_description7 { get; set; } = "";
        public string? desc_description8 { get; set; } = "";
        public string? desc_description9 { get; set; } = "";
        public string? desc_description10 { get; set; } = "";
        public string? desc_description11 { get; set; } = "";
        public string? desc_description12 { get; set; } = "";
        public string? desc_description13 { get; set; } = "";
        public string? desc_description14 { get; set; } = "";
        public string? desc_description15 { get; set; } = "";
        public string? desc_description16 { get; set; } = "";
        public string? desc_description17 { get; set; } = "";

        public List<cargo_container_dto>? house_cntr { get; set; }
        
        public cargo_desc_dto? cargodesc { get; set; }
        
    }
}

