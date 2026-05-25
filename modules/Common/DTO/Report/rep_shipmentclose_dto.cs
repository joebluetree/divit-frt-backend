using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 19/05/2026
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Report
{
    public class rep_shipmentclose_dto : basetable_dto
    {
        public int mbl_id { get; set; } = 0;
        public int? mbl_hbl_id { get; set; } = 0;
        public string? mbl_refno { get; set; } = "";
        public string? mbl_mode { get; set; } = "";
        public string? mbl_ref_date { get; set; } = "";
        public string? mbl_bl_req { get; set; } = "";
        public string? mbl_cntr_type { get; set; } = "";
        public string? hbl_empty_ret_date { get; set; } = "";
        public string? hbl_pickup_date { get; set; } = "";
        public string? mbl_profit_req { get; set; } = "";
        public string? mbl_loss_approved { get; set; } = "";
        public string? mbl_loss_memo { get; set; } = "";
        public decimal? mbl_revenue { get; set; } = 0;
    }
}
