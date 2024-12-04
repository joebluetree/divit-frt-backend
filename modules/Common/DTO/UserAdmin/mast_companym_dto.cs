using Database.Models.BaseTables;

namespace Common.UserAdmin.DTO
{
    public class mast_companym_dto : basetable_dto
    {
        public int comp_id { get; set; } = 0;
        public string? comp_code { get; set; } = "";
        public string? comp_name { get; set; } = "";
        public string? comp_address1 { get; set; } = "";
        public string? comp_address2 { get; set; } = "";
        public string? comp_address3 { get; set; } = "";

    }
}

