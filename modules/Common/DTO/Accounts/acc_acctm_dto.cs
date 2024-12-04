using Database.Models.Accounts;
using Database.Models.BaseTables;

namespace Common.DTO.Accounts
{
    public class acc_acctm_dto : basetable_dto
    {
        public int acc_id { get; set; }
        public string? acc_code { get; set; }
        public string? acc_short_name { get; set; }
        public string? acc_name { get; set; }
        public string? acc_type { get; set; }
        public string? acc_row_type { get; set; }
        public int? acc_maincode_id { get; set; }

        public string? acc_maincode { get; set; }
        public string? acc_maincode_name { get; set; }
        public int acc_grp_id { get; set; }
        public string? acc_grp_name { get; set; }

    }
}

