using System;
using Database.Models.BaseTables;

namespace Common.DTO.CommonShipment
{
    public class cargo_slip_dto : basetable_dto
    {
        public int cs_id { get; set; }
        public int? cs_mbl_id { get; set; }
        public int? cs_slno { get; set; }
        public string? cs_refno { get; set; }
        public string? cs_mode { get; set; }
        public string? cs_mbl_no { get; set; }
        public string? cs_date { get; set; }
        public string? cs_time { get; set; }
        public string? cs_ampm { get; set; }
        public int? cs_to_id { get; set; }
        public string? cs_to_code { get; set;}
        public string? cs_to_name { get; set; }
        public string? cs_to_tel { get; set; }
        public string? cs_to_fax { get; set; }
        public int? cs_from_id { get; set; }
        public string? cs_from_name { get; set; }
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
        public string? cs_deliver_to_code { get; set; }
        public string? cs_deliver_to_name { get; set; }
        public string? cs_deliver_to_add1 { get; set; }
        public string? cs_deliver_to_add2 { get; set; }
        public string? cs_deliver_to_add3 { get; set; }
        public string? cs_deliver_to_tel { get; set; }
        public string? cs_deliver_to_attn { get; set; }
        public string? cs_remark { get; set; }
    }
}
