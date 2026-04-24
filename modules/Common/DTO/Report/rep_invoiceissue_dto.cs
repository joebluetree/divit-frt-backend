using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 14/03/2026
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Report
{
    public class rep_invoiceissue_dto : basetable_dto
    {
        public int inv_id { get; set; } = 0;
        public string? inv_no { get; set; } = "";
        public string? inv_date { get; set; } = "";
        public int? inv_mbl_id { get; set; } = 0;
        public string? inv_mbl_refno { get; set; } = "";
        public string? inv_mode { get; set; } = "";
        public string? inv_ref_date { get; set; } = "";
        public string? inv_cust_name { get; set; } = "";
        public string? inv_liner_name { get; set; } = "";
        public string? inv_pol_name { get; set; } = "";
        public string? inv_pol_country { get; set; } = "";
        public string? inv_pod_name { get; set; } = "";
        public string? inv_pod_country { get; set; } = "";
        public string? inv_pol_etd { get; set; } = "";
        public string? inv_pod_eta { get; set; } = "";
        public decimal? inv_amount { get; set; } = 0;
        public string? inv_mbl_no { get; set; } = "";
        public string? inv_cur_code { get; set; } = "";
        public string? inv_houseno { get; set; } = "";
        public string? inv_mbl_cntr_type { get; set; } = "";
    }
}
