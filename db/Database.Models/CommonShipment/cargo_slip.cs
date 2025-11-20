using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Cargo;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Alen Cherian
//Date : 22/04/2025
//Command :  Create Repository for the Messenger Slip.
//version 1.0

namespace Database.Models.CommonShipment
{

    public class cargo_slip
    {
        [Key]
        public int cs_id { get; set; }
        public int? cs_slno { get; set; }
        public string? cs_refno { get; set; }
        public int? cs_mbl_id { get; set; }
        public string? cs_mode { get; set; }
        public DateOnly? cs_date { get; set; }
        public string? cs_time { get; set; }
        public string? cs_ampm { get; set; }
        public int? cs_to_id { get; set; }
        public int? cs_from_id { get; set; }
        public string? cs_is_drop { get; set; }
        public string? cs_is_pick { get; set; }
        public string? cs_is_receipt { get; set; }
        public string? cs_is_check { get; set; }
        public string? cs_check_det { get; set; }
        public string? cs_is_bl { get; set; }
        public string? cs_bl_det { get; set; }
        public string? cs_is_oth { get; set; }
        public string? cs_oth_det { get; set; }
        public int? cs_deliver_to_id { get; set; }
        public string? cs_deliver_to_name { get; set; }
        public string? cs_deliver_to_add1 { get; set; }
        public string? cs_deliver_to_add2 { get; set; }
        public string? cs_deliver_to_add3 { get; set; }
        public string? cs_deliver_to_tel { get; set; }
        public string? cs_deliver_to_attn { get; set; }
        public string? cs_remark { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public string? rec_locked { get; set; }

        [ForeignKey("cs_mbl_id")]
        public cargo_masterm? master { get; set; }

        [ForeignKey("cs_to_id")]
        public mast_customerm? to { get; set; }

        [ForeignKey("cs_from_id")]
        public mast_param? from { get; set; }

        [ForeignKey("cs_deliver_to_id")]
        public mast_customerm? deliver { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }



    }
}