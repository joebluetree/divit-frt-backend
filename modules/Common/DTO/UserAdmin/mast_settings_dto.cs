using Database.Models.BaseTables;

namespace Common.UserAdmin.DTO
{
    public class mast_settings_dto : basetable_dto
    {
        public int id { get; set; }
        public string? category { get; set; } = "";
        public string? caption { get; set; } = "";
        public string? remarks { get; set; } = "";
        public string? type { get; set; } = "";
        public string? table { get; set; } = "";
        public string? value { get; set; } = "";
        public string? code { get; set; } = "";
        public string? name { get; set; } = "";

        public int? param_id { get; set; }
        public int order { get; set; }

    }


}

