using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 29/01/2026
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Report
{
    public class rep_consigneeship_dto : basetable_dto
    {
        public int hbl_id { get; set; } = 0;
        public int? hbl_mbl_id { get; set; } = 0;
        public string? hbl_mbl_refno { get; set; } = "";
        public string? hbl_mode { get; set; } = "";
        public string? hbl_ref_date { get; set; } = "";
        public int? hbl_agent_id { get; set; } = 0;
        public string? hbl_agent_name { get; set; } = "";
        public int? hbl_liner_id { get; set; } = 0;
        public string? hbl_liner_name { get; set; } = "";
        public int? hbl_shipper_id { get; set; } = 0;
        public string? hbl_shipper_name { get; set; } = "";
        public int? hbl_consignee_id { get; set; } = 0;
        public string? hbl_consignee_name { get; set; } = "";
        public string? hbl_location_name { get; set; } = "";
        public string? hbl_vessel_name { get; set; } = "";
        public string? hbl_voyage { get; set; } = "";
        public string? hbl_pol_name { get; set; } = "";
        public string? hbl_pod_name { get; set; } = "";
        public string? hbl_pol_etd { get; set; } = "";
        public string? hbl_pod_eta { get; set; } = "";
        public string? hbl_cntr_type_name { get; set; } = "";
        public string? hbl_cntr_no { get; set; } = "";
        public string? hbl_cntr_sealno { get; set; } = "";
        public decimal? hbl_weight { get; set; } = 0;
        public string? hbl_remarks { get; set; } = "";
        public string? hbl_delivery_date { get; set; } = "";
        public string? hbl_mbl_no { get; set; } = "";
        public string? hbl_houseno { get; set; } = "";
        public string? hbl_cntr_list { get; set; } = "";
        public int? hbl_packages { get; set; } = 0;
        public string? hbl_pono { get; set; } = "";
        public string? cntr_discharge_date { get; set; } = "";
        public string? cntr_pick_date { get; set; } = "";
        public string? cntr_pick_status { get; set; } = "";
        public string? cntr_return_date { get; set; } = "";
        public string? cntr_lfd { get; set; } = "";
        public string? hbl_an_sent { get; set; } = "";
    }
}
