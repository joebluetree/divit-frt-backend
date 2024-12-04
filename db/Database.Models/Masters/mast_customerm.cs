using Database.Models.BaseTables;

namespace Database.Models.Masters
{
    public class mast_customerm : baseTable_company
    {
        public int cust_id { get; set; }
        public string? cust_type { get; set; }
        public string? cust_code { get; set; }
        public string? cust_short_name { get; set; }
        public string? cust_name { get; set; }
        public string? cust_display_name { get; set; }
        public string? cust_address1 { get; set; }
        public string? cust_address2 { get; set; }
        public string? cust_address3 { get; set; }
        public string? cust_row_type { get; set; }

        public string? cust_is_parent { get; set; }
        public Nullable<int> cust_parent_id { get; set; }
        public mast_customerm? customer { get; set; }

        public decimal cust_credit_limit { get; set; }
        public List<mast_contactm>? cust_contacts { get; set; }
        public DateTime? cust_est_dt { get; set; }

    }
}
