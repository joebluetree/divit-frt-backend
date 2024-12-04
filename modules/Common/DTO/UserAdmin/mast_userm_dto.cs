using Database.Models.BaseTables;

namespace Common.UserAdmin.DTO
{
    public class mast_userm_dto : basetable_dto
    {
        public int user_id { get; set; }
        public string? user_code { get; set; }
        public string? user_name { get; set; }
        public string? user_password { get; set; }
        public string? user_email { get; set; }
        public string? user_is_admin { get; set; }
        public string? user_token { get; set; }

        public List<mast_userbranches_dto>? userbranches { get; set; }

    }
}

