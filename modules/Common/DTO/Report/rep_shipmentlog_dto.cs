using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 18/03/2026
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Report
{
    public class rep_shipmentlog_dto : basetable_dto
    {
        public int mbl_id { get; set; } = 0;
        public int? mbl_hbl_id { get; set; } = 0;
        public string? mbl_refno { get; set; } = "";
        public string? mbl_no { get; set; } = "";
        public string? mbl_mode { get; set; } = "";
        public string? mbl_ref_date { get; set; } = "";
        public string? mbl_agent_name { get; set; } = "";
        public string? mbl_liner_name { get; set; } = "";
        public string? mbl_shipper_name { get; set; } = "";
        public string? mbl_consignee_name { get; set; } = "";
        public string? mbl_handled_name { get; set; } = "";
        public string? mbl_cntr_type { get; set; } = "";
        public string? mbl_incoterm { get; set; } = "";
        public string? mbl_firm_code { get; set; } = "";
        public string? mbl_ams_fileno { get; set; } = "";
        public string? mbl_isf_no { get; set; } = "";
        public string? mbl_is_pl { get; set; } = "";
        public string? mbl_is_ci { get; set; } = "";
        public string? mbl_is_carr_an { get; set; } = "";
        public string? mbl_custom_reles_status { get; set; } = "";
        public string? mbl_frt_status_name { get; set; } = "";
        public string? mbl_paid_status { get; set; } = "";
        public string? mbl_lfd { get; set; } = "";
        public string? hbl_plf_eta { get; set; } = "";
        public int? mbl_eta_rem { get; set; } = 0;
        public string? mbl_is_delivery { get; set; } = "";
        public int? mbl_packages { get; set; } = 0;
        public string? mbl_place_final { get; set; } = "";
        public string? mbl_it_tot { get; set; } = "";
        public string? mbl_bo_status { get; set; } = "";
        public string? mbl_bo_attended_code { get; set; } = "";
        public string? mbl_mstatus { get; set; } = "";
        public string? mbl_hstatus { get; set; } = "";
        public string? mbl_liner_bookingno { get; set; } = "";
        public string? mbl_pol_name { get; set; } = "";
        public string? mbl_pod_name { get; set; } = "";
        public string? mbl_pol_etd { get; set; } = "";
        public string? mbl_pod_eta { get; set; } = "";
        public decimal? mbl_weight { get; set; } = 0;
        public string? mbl_houseno { get; set; } = "";
        public string? mbl_shipstage { get; set; } = "";
        public string? mbl_carrier_an_recd_dt { get; set; } = "";
        public string? mbl_an_sent_dt { get; set; } = "";
    }
}
