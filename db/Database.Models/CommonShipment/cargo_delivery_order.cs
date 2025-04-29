using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Sourav V
//Created Date : 17/04/2025
//Remark : Version 1.0 , 17/04/2025

namespace Database.Models.Cargo
{
    public class cargo_delivery_order
    {
        [Key]
        public int do_id { get; set; }
        public int? do_cfno { get; set; }
        public int? do_parent_id { get; set; }
        public int? do_truck_id { get; set; }    
        public string? do_truck_name { get; set; }
        public string? do_truck_attn { get; set; }
        public string? do_truck_tel { get; set; }
        public string? do_truck_fax { get; set; }
        public string? do_truck_cc { get; set; }
        public string? do_pickup { get; set; }
        public string? do_addr1 { get; set; }
        public string? do_addr2 { get; set; }
        public string? do_addr3 { get; set; }
        public DateTime? do_date { get; set; }
        public string? do_time { get; set; }
        public string? do_attn { get; set; }
        public string? do_tel { get; set; }

        public int? do_from_id { get; set; }
        public string? do_from_name { get; set; }
        public string? do_from_addr1 { get; set; }
        public string? do_from_addr2 { get; set; }
        public string? do_from_addr3 { get; set; }
        public string? do_from_addr4 { get; set; }

        public int? do_to_id { get; set; }
        public string? do_to_name { get; set; }
        public string? do_to_addr1 { get; set; }
        public string? do_to_addr2 { get; set; }
        public string? do_to_addr3 { get; set; }
        public string? do_to_addr4 { get; set; }

        public int? do_uom1_id { get; set; }
        public string? do_desc1 { get; set; }
        public int? do_tot_piece1 { get; set; }
        public decimal? do_wt1 { get; set; }
        public decimal? do_cbm_cft1 { get; set; }
        public int? do_uom2_id { get; set; }
        public string? do_desc2 { get; set; }
        public int? do_tot_piece2 { get; set; }
        public decimal? do_wt2 { get; set; }
        public decimal? do_cbm_cft2 { get; set; }
        public int? do_uom3_id { get; set; }
        public string? do_desc3 { get; set; }
        public int? do_tot_piece3 { get; set; }
        public decimal? do_wt3 { get; set; }
        public decimal? do_cbm_cft3 { get; set; }
        public int? do_uom4_id { get; set; }
        public string? do_desc4 { get; set; }
        public int? do_tot_piece4 { get; set; }
        public decimal? do_wt4 { get; set; }
        public decimal? do_cbm_cft4 { get; set; }
        public string? do_remark_1 { get; set; }
        public string? do_remark_2 { get; set; }
        public string? do_remark_3 { get; set; }
        public string? do_remark_4 { get; set; }

        public string? do_danger_goods { get; set; }
        public string? do_terms_ship { get; set; }
        public string? do_vessel { get; set; }
        public string? do_voyage { get; set; }

        public string? do_freight { get; set; }
        public string? do_export_doc { get; set; }
        public string? do_order_no { get; set; }
        public DateTime? do_order_date { get; set; }
        public string? do_category { get; set; }
        public string? do_is_delivery_sent { get; set; }
        public DateTime? do_delivery_date { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; } 
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }

        
        // [ForeignKey("do_parent_id")]
        // public cargo_housem? parent { get; set; }

        [ForeignKey("do_truck_id")]
        public mast_customerm? truck { get; set; }
        
        [ForeignKey("do_from_id")]
        public mast_customerm? fromAdd { get; set; }
        
        [ForeignKey("do_to_id")]
        public mast_customerm? toAdd { get; set; }
        
        [ForeignKey("do_uom1_id")]
        public mast_param? uom1 { get; set; }

        [ForeignKey("do_uom2_id")]
        public mast_param? uom2 { get; set; }

        [ForeignKey("do_uom3_id")]
        public mast_param? uom3 { get; set; }

        [ForeignKey("do_uom4_id")]
        public mast_param? uom4 { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }
    }
}
