using Database.Models.BaseTables;

namespace Common.DTO.Accounts
{
    public class acc_groupm_dto : basetable_dto
    {
        public int grp_id { get; set; } = 0;
        public string? grp_name { get; set; }
        public int grp_order { get; set; } = 0;
        public string? grp_main_group { get; set; }

    }
}

