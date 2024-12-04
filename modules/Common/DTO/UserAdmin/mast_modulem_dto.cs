using Database.Models.BaseTables;

namespace Common.UserAdmin.DTO
{
    public class mast_modulem_dto : basetable_dto
    {
        public int module_id { get; set; }

        public string? module_name { get; set; } = "";
        public string? module_is_installed { get; set; } = "";

        public int? module_parent_id { get; set; }
        public string? module_parent_name { get; set; } = "";

        public int module_order { get; set; }



    }
}

