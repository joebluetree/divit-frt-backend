using Database.Models.BaseTables;

namespace Common.UserAdmin.DTO
{
    public class mast_userbranches_dto : basetable_dto
    {
        public int? ub_id { get; set; }
        public int? ub_user_id { get; set; }
        public string? ub_user_name { get; set; }
        public string? ub_selected { get; set; }

    }
}

