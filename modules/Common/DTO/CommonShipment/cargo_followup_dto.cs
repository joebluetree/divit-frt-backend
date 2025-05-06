using System;
using Database.Models.BaseTables;

namespace Common.DTO.CommonShipment
{
    public class cargo_followup_dto : basetable_dto
    {

        public int cf_id { get; set; }
        public int cf_mbl_id { get; set; }
        public string? cf_mbl_refno  { get; set; }
        public string? cf_mbl_ref_date { get; set; }
        public string? cf_mode { get; set; }
        public int? cf_user_id { get; set; }
        public string? cf_user_name  { get; set; }
        public string? cf_remarks { get; set; }
        public string? cf_followup_date { get; set; }
        public int? cf_assigned_id { get; set; }
        public string? cf_assigned_name { get; set; }
        public int? cf_handled_id  { get; set; }
        public string? cf_handled_name  { get; set; }

    }
}