using Database.Models.BaseTables;

namespace Common.UserAdmin.DTO
{
    public class mast_branchm_dto : basetable_dto
    {
        public int branch_id { get; set; } = 0;
        public string? branch_code { get; set; } = "";
        public string? branch_name { get; set; } = "";
        public string? branch_address1 { get; set; } = "";
        public string? branch_address2 { get; set; } = "";
        public string? branch_address3 { get; set; } = "";

    }
}

