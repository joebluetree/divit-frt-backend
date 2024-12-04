using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;


namespace Common.DTO.Masters
{
    public class mast_customerm_dto : basetable_dto
    {
        public int cust_id { get; set; } = 0;
        public string? cust_type { get; set; } = "";
        public string? cust_code { get; set; } = "";
        public string? cust_short_name { get; set; } = "";
        public string? cust_name { get; set; } = "";
        public string? cust_display_name { get; set; } = "";
        public string? cust_address1 { get; set; } = "";
        public string? cust_address2 { get; set; } = "";
        public string? cust_address3 { get; set; } = "";
        public string? cust_row_type { get; set; } = "";

        public decimal? cust_credit_limit { get; set; } = 0;
        public string? cust_is_parent { get; set; } = "";
        public Nullable<int> cust_parent_id { get; set; }
        public string? cust_parent_name { get; set; } = "";
        public List<mast_contactm_dto>? cust_contacts { get; set; }

        public string? cust_est_dt { get; set; } = "";

    }
}
