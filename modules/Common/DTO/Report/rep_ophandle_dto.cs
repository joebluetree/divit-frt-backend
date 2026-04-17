using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 24/12/2025
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Report
{
    public class rep_ophandle_dto : basetable_dto
    {
        public int ophandle_id { get; set; } = 0;
        public int ophandle_hbl_id { get; set; } = 0;
        public string? ophandle_type { get; set; } = "";
        public string? ophandle_refno { get; set; } = "";
        public string? ophandle_ref_date { get; set; } = "";
        public string? ophandle_no { get; set; } = "";
        public int? ophandle_agent_id { get; set; } = 0;
        public string? ophandle_agent_name { get; set; } = "";
        public int? ophandle_handled_id { get; set; } = 0;
        public string? ophandle_handled_name { get; set; } = "";
        public int? ophandle_pol_id { get; set; } = 0;
        public string? ophandle_pol_name { get; set; } = "";
        public string? ophandle_pol_etd { get; set; } = "";
        public int? ophandle_pod_id { get; set; } = 0;
        public string? ophandle_pod_name { get; set; } = "";
        public string? ophandle_pod_eta { get; set; } = "";
        public string? ophandle_houseno { get; set; } = "";
        public int? ophandle_shipper_id { get; set; } = 0;
        public string? ophandle_shipper_name { get; set; } = "";
        public int? ophandle_consignee_id { get; set; } = 0;
        public string? ophandle_consignee_name { get; set; } = "";
        public int? ophandle_shipterm_id { get; set; } = 0;
        public string? ophandle_shipterm_name { get; set; } = "";
        public int? ophandle_house_count { get; set; } = 0;
        public int? ophandle_master_count { get; set; } = 0;

    }
}
