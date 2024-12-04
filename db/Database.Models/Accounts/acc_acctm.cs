
using Database.Models.BaseTables;

namespace Database.Models.Accounts
{
    public class acc_acctm : baseTable_company
    {
        public int acc_id { get; set; }
        public string? acc_code { get; set; }
        public string? acc_short_name { get; set; }
        public string? acc_name { get; set; }
        public string? acc_type { get; set; }
        public string? acc_row_type { get; set; }

        public Nullable<int> acc_maincode_id { get; set; }
        public acc_acctm? acctm { get; set; }
        public int acc_grp_id { get; set; }
        public acc_groupm? acc_groupm { get; set; }
    }
}
