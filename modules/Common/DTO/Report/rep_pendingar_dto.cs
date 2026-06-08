
using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 26/05/2026
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Report
{
    public class rep_pendingar_dto : basetable_dto
    {
        public int mbl_id { get; set; } = 0;
        public string? mbl_refno { get; set; } = "";
        public string? mbl_mode { get; set; } = "";
        public string? mbl_ref_date { get; set; } = "";
        public string? mbl_no { get; set; } = "";
        public string? mbl_houseno { get; set; } = "";
        public int? mbl_hbl_id { get; set; } = 0;
        public string? mbl_pod_eta { get; set; } = "";
        public string? mbl_handled_name { get; set; } = "";
        public string? mbl_bltype { get; set; } = "";
        public string? mbl_remarks { get; set; } = "";
        public string? mbl_pending_status { get; set; } = "";
    }
}
