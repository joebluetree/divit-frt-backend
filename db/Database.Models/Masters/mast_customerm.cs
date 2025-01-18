﻿using Database.Models.BaseTables;

namespace Database.Models.Masters
{
    public class mast_customerm : baseTable_company
    {
        public int cust_id { get; set; }
        public string? cust_type { get; set; }
        public string? cust_code { get; set; }
        public string? cust_short_name { get; set; }
        public string? cust_name { get; set; }
        public string? cust_official_name { get; set; }
        public string? cust_address1 { get; set; }
        public string? cust_address2 { get; set; }
        public string? cust_address3 { get; set; }
        public string? cust_city { get; set; }
        public int? cust_state_id { get; set; }
        public string? cust_state_name { get; set; }
        public int? cust_country_id { get; set; }
        public string? cust_country_name { get; set; }
        public string? cust_zip_code {get; set; }
        public string? cust_contact { get; set; }
        public string? cust_title { get; set; }
        public string? cust_tel { get; set; }
        public string? cust_fax { get; set; }
        public string? cust_mobile { get; set; }
        public string? cust_web { get; set; }
        public string? cust_email { get; set; }
        public string? cust_refer_by { get; set; }
        public int? cust_salesman_id { get; set; }
        public string? cust_salesman_name { get; set; }
        public int? cust_handled_id { get; set; }
        public string? cust_handled_name { get; set; }
        public string? cust_location { get; set; }
        public decimal cust_credit_limit { get; set; }
        public DateTime? cust_est_dt { get; set; }
        public string? cust_row_type { get; set; }
        public string? cust_is_parent { get; set; }

        public Nullable<int> cust_parent_id { get; set; }
        public mast_customerm? customer { get; set; }
        public mast_param? state { get; set; }
        public mast_param? country { get; set; }
        public mast_param? salesman { get; set; }
        public mast_param? handled { get; set; }
        public List<mast_contactm>? cust_contacts { get; set; }

    }
}
