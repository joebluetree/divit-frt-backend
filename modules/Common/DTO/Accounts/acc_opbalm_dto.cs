using Database.Models.Accounts;
using Database.Models.BaseTables;

namespace Common.DTO.Accounts
{
    public class acc_opbalm_dto : basetable_dto
    {
        public int jv_id { get; set; } = 0;
        public int jv_header_id { get; set; } = 0;
        public int jv_vrno { get; set; } = 0;
        public string? jv_docno { get; set; } = "";
        public string? jv_type { get; set; } = "";
        public string? jv_date { get; set; } = "";
        public int? jv_year { get; set; } = 0;
        public string? jv_refno { get; set; } = "";
        public string? jv_refdate { get; set; } = "";
        public string? jv_acc_code { get; set; } = "";
        public string? jv_acc_name { get; set; } = "";
        public string? jv_shipment_ref { get; set; } = "";
        public string? jv_shipment_date { get; set; } = "";
        public string? jv_cur_code { get; set; } = "";
        public decimal? jv_exrate { get; set; } = 0;
        public decimal? jv_dcamt { get; set; } = 0;
        public decimal? jv_debit { get; set; } = 0;
        public decimal? jv_credit { get; set; } = 0;
        public string? jv_narration { get; set; } = "";
    }
}