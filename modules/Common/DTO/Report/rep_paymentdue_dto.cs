using Common.DTO.SeaExport;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 20/05/2026
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Report
{
public class rep_paymentdue_dto : basetable_dto
    {
        public int inv_id { get; set; } = 0;
        public int? inv_mbl_id { get; set; } = 0;
        public int? inv_hbl_id { get; set; } = 0;
        public string? inv_no { get; set; } = "";
        public string? inv_refno { get; set; } = "";
        public string? inv_houseno { get; set; } = "";
        public string? inv_mode { get; set; } = "";
        public int? inv_cust_id { get; set; } = 0;
        public string? inv_cust_name { get; set; } = "";
        public string? inv_date { get; set; } = "";
        public string? inv_payment_date { get; set; } = "";
        public decimal? inv_amount { get; set; } = 0;
        public decimal? inv_balance { get; set; } = 0;
    }
}
