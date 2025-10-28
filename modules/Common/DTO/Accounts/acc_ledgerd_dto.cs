using Database.Models.Accounts;
using Database.Models.BaseTables;

namespace Common.DTO.Accounts
{
    public class acc_ledgerd_dto : basetable_dto
    {
        public int jv_id { get; set; } = 0;
        public int jv_header_id { get; set; } = 0;
        public int jv_year { get; set; } = 0;
        public int jv_vrno { get; set; } = 0;
        public string? jv_docno { get; set; } = "";
        public string? jv_type { get; set; } = "";
        public string? jv_date { get; set; } = "";
        public string? jv_refno { get; set; } = "";
        public string? jv_refdate { get; set; } = "";
        public int? jv_acc_id { get; set; } = 0;
        public string? jv_acc_code { get; set; } = "";
        public string? jv_acc_name { get; set; } = "";
        public string? jv_shipment_ref { get; set; } = "";
        public string? jv_shipment_date { get; set; } = "";
        public string? jv_status { get; set; } = "";
        public decimal? jv_famt { get; set; } = 0;
        public int? jv_cur_id { get; set; } = 0;
        public string? jv_cur_code { get; set; } = "";
        public decimal? jv_exrate { get; set; } = 0;
        public string? jv_drcr { get; set; } = "";
        public decimal? jv_dcamt { get; set; } = 0;
        public decimal? jv_debit { get; set; } = 0;
        public decimal? jv_credit { get; set; } = 0;
        public int? jv_inv_id { get; set; } = 0;
        public string? jv_inv_code { get; set; } = "";
        public string? jv_remarks { get; set; } = "";
        public string? jv_narration { get; set; } = "";
        public string? jv_doc_type { get; set; } = "";
        public string? jv_bank { get; set; } = "";
        public string? jv_chqno { get; set; } = "";
        public string? jv_chq_date { get; set; } = "";
        public string? jv_master_date { get; set; } = "";
        public string? jv_is_payroll { get; set; } = "";
        public decimal? jv_tax_amt { get; set; } = 0;
        public decimal? jv_tax_per { get; set; } = 0;
        public int? jv_ctr { get; set; } = 0;
        public decimal? jv_debit_total { get; set; } = 0;
        public decimal? jv_credit_total { get; set; } = 0;
        public decimal? jv_balance { get; set; } = 0;
    }
}