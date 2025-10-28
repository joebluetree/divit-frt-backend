using Database.Models.Accounts;
using Database.Models.BaseTables;

namespace Common.DTO.Accounts
{
    public class acc_ledgerh_dto : basetable_dto
    {
        public int jvh_id { get; set; } = 0;
        public int jvh_year { get; set; } = 0;
        public int jvh_vrno { get; set; } = 0;
        public string? jvh_docno { get; set; } = "";
        public string? jvh_type { get; set; } = "";
        public string? jvh_date { get; set; } = "";
        public string? jvh_refno { get; set; } = "";
        public string? jvh_refdate { get; set; } = "";
        public string? jvh_status { get; set; } = "";
        public int? jvh_cur_id { get; set; } = 0;
        public string? jvh_cur_code { get; set; } = "";
        public decimal? jvh_exrate { get; set; } = 0;
        public string? jvh_remarks { get; set; } = "";
        public string? jvh_narration { get; set; } = "";
        public string? jvh_master_date { get; set; } = "";
        public string? jvh_is_payroll { get; set; } = "";
        public string? jvh_shipment_ref { get; set; } = "";
        public string? jvh_shipment_date { get; set; } = "";
        public decimal? jvh_debit { get; set; } = 0;
        public decimal? jvh_credit { get; set; } = 0;
        public decimal? jvh_balance { get; set; } = 0;
        public acc_ledgerd_dto? ledger_detail { get; set; }
        public List<acc_ledgerd_dto>? ledger_details { get; set; } 
    }
}