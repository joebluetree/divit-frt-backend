using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

// Name : Sourav V
// Created Date : 17/04/2025
// Remark : This file defines data objects (variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.CommonShipment
{
    public class cargo_delivery_order_dto : basetable_dto
    {
        public int do_id { get; set; } = 0;
        public int? do_parent_id { get; set; } = 0;
        public int? do_cfno { get; set; } = 0;
        public string? do_order_no { get; set; } = "";

        public int? do_truck_id { get; set; } = 0;
        public string? do_truck_code { get; set; } = "";
        public string? do_truck_name { get; set; } = "";
        public string? do_truck_attn { get; set; } = "";
        public string? do_truck_tel { get; set; } = "";
        public string? do_truck_fax { get; set; } = "";
        public string? do_truck_cc { get; set; } = "";
        public string? do_pickup { get; set; } = "";
        public string? do_addr1 { get; set; } = "";
        public string? do_addr2 { get; set; } = "";
        public string? do_addr3 { get; set; } = "";
        public string? do_date { get; set; } = "";
        public string? do_time { get; set; } = "";
        public string? do_attn { get; set; } = "";
        public string? do_tel { get; set; } = "";
        public int? do_from_id { get; set; } = 0;
        public string? do_from_code { get; set; } = "";
        public string? do_from_name { get; set; } = "";
        public string? do_from_addr1 { get; set; } = "";
        public string? do_from_addr2 { get; set; } = "";
        public string? do_from_addr3 { get; set; } = "";
        public string? do_from_addr4 { get; set; } = "";
        public int? do_to_id { get; set; } = 0;
        public string? do_to_code { get; set; } = "";
        public string? do_to_name { get; set; } = "";
        public string? do_to_addr1 { get; set; } = "";
        public string? do_to_addr2 { get; set; } = "";
        public string? do_to_addr3 { get; set; } = "";
        public string? do_to_addr4 { get; set; } = "";

        public int? do_uom1_id { get; set; } = 0;
        public string? do_uom1_name { get; set; } = "";
        public string? do_desc1 { get; set; } = "";
        public int? do_tot_piece1 { get; set; } = 0;
        public decimal? do_wt1 { get; set; } = 0;
        public decimal? do_cbm_cft1 { get; set; } = 0;

        public int? do_uom2_id { get; set; } = 0;
        public string? do_uom2_name { get; set; } = "";
        public string? do_desc2 { get; set; } = "";
        public int? do_tot_piece2 { get; set; } = 0;
        public decimal? do_wt2 { get; set; } = 0;
        public decimal? do_cbm_cft2 { get; set; } = 0;

        public int? do_uom3_id { get; set; } = 0;
        public string? do_uom3_name { get; set; } = "";
        public string? do_desc3 { get; set; } = "";
        public int? do_tot_piece3 { get; set; } = 0;
        public decimal? do_wt3 { get; set; } = 0;
        public decimal? do_cbm_cft3 { get; set; } = 0;

        public int? do_uom4_id { get; set; } = 0;
        public string? do_uom4_name { get; set; } = "";
        public string? do_desc4 { get; set; } = "";
        public int? do_tot_piece4 { get; set; } = 0;
        public decimal? do_wt4 { get; set; } = 0;
        public decimal? do_cbm_cft4 { get; set; } = 0;

        public string? do_remark_1 { get; set; } = "";
        public string? do_remark_2 { get; set; } = "";
        public string? do_remark_3 { get; set; } = "";
        public string? do_remark_4 { get; set; } = "";

        public string? do_danger_goods { get; set; } = "";
        public string? do_terms_ship { get; set; } = "";
        public string? do_vessel { get; set; } = "";
        public string? do_voyage { get; set; } = "";

        public string? do_freight { get; set; } = "";
        public string? do_export_doc { get; set; } = "";
        public string? do_is_exw { get; set; } = "";
        public string? do_is_fob { get; set; } = "";
        public string? do_is_fca { get; set; } = "";
        public string? do_is_cpu { get; set; } = "";
        public string? do_is_ddu { get; set; } = "";
        public string? do_is_frt_others { get; set; } = "";
        public string? do_freight_remark { get; set; } = "";
        public string? do_is_comm_inv { get; set; } = "";
        public string? do_is_lc { get; set; } = "";
        public string? do_is_coo { get; set; } = "";
        public string? do_is_pl { get; set; } = "";
        public string? do_is_expdec { get; set; } = "";
        public string? do_is_exp_others { get; set; } = "";
        public string? do_export_doc_remark { get; set; } = "";        
        public string? do_order_date { get; set; } = "";
        public string? do_category { get; set; } = "";
        public string? do_is_delivery_sent { get; set; } = "";
        public string? do_delivery_date { get; set; } = "";
    }
}
