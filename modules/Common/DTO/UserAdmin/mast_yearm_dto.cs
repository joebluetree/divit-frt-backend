using Database.Models.BaseTables;

namespace Common.UserAdmin.DTO
{
    public class mast_yearm_dto : basetable_dto
    {
        public int year_id { get; set; }
        public int year_code { get; set; }
        public string? year_name { get; set; }
        public string? year_start_date { get; set; }
        public string? year_end_date { get; set; }
        public string? year_closed { get; set; }
        public string? year_default { get; set; }

    }
}

