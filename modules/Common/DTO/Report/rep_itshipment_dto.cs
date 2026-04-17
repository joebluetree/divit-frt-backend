using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 09/02/2026
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Report
{
    public class rep_itshipment_dto : basetable_dto
    {
        public int hbl_id { get; set; } = 0;
        public int? hbl_mbl_id { get; set; } = 0;
        public string? hbl_mbl_refno { get; set; } = "";
        public string? hbl_mode { get; set; } = "";
        public string? hbl_ref_date { get; set; } = "";
        public string? hbl_agent_name { get; set; } = "";
        public string? hbl_liner_name { get; set; } = "";
        public string? hbl_shipper_name { get; set; } = "";
        public string? hbl_consignee_name { get; set; } = "";
        public string? hbl_location_name { get; set; } = "";
        public string? hbl_vessel_name { get; set; } = "";
        public string? hbl_voyage { get; set; } = "";
        public string? hbl_book_slno { get; set; } = "";
        public string? hbl_pol_name { get; set; } = "";
        public string? hbl_pod_name { get; set; } = "";
        public string? hbl_pol_etd { get; set; } = "";
        public string? hbl_pod_eta { get; set; } = "";
        public string? hbl_cntr_no { get; set; } = "";
        public decimal? hbl_weight { get; set; } = 0;
        public string? hbl_mbl_no { get; set; } = "";
        public string? hbl_place_final { get; set; } = "";
        public string? hbl_houseno { get; set; } = "";
        public string? hbl_mbl_cntr_type { get; set; } = "";
    }
}
