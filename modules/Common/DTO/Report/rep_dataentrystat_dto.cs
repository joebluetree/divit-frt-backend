
using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 01/06/2026
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Report
{
    public class rep_dataentrystat_dto : basetable_dto
    {
        public int mbl_id { get; set; } = 0;
        public string? mbl_refno { get; set; } = "";
        public string? mbl_mode { get; set; } = "";
        public string? mbl_ref_date { get; set; } = "";
        public string? mbl_date { get; set; } = "";
        public string? mbl_no { get; set; } = "";
        public string? mbl_house_nos { get; set; } = "";
        public int? mbl_hbl_id { get; set; } = 0;
        public string? mbl_category { get; set; } = "";
        public string? mbl_bltype { get; set; } = "";
        public int? mbl_house_count { get; set; } = 0;
        public string? mbl_agent_name { get; set; } = "";
        public string? mbl_shipper_name { get; set; } = "";
        public string? mbl_consignee_name { get; set; } = "";
        public int? mbl_handled_id { get; set; } = 0;
        public string? mbl_handled_name { get; set; } = "";
        public int? mbl_count { get; set; } = 0;
        public int? mbl_hbl_count { get; set; } = 0;

    }
}
