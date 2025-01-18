﻿using Common.UserAdmin.DTO;
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
        public string? cust_official_name { get; set; } = "";
        public string? cust_address1 { get; set; } = "";
        public string? cust_address2 { get; set; } = "";
        public string? cust_address3 { get; set; } = "";
        public string? cust_city { get; set; } = "";
        public int? cust_state_id { get; set; }= 0;
        public string? cust_state_code { get; set; } = "";
        public string? cust_state_name { get; set; } = "";
        public int? cust_country_id { get; set; } = 0;
        public string? cust_country_code { get; set; } = "";
        public string? cust_country_name { get; set; } = "";
        public string? cust_zip_code {get; set; } = "";
        public string? cust_contact { get; set; } = "";
        public string? cust_title { get; set; } = "";
        public string? cust_tel { get; set; } = "";
        public string? cust_fax { get; set; } = "";
        public string? cust_mobile { get; set; } = "";
        public string? cust_web { get; set; } = "";
        public string? cust_email { get; set; } = "";
        public string? cust_refer_by { get; set; } = ""; 
        public int? cust_salesman_id { get; set; } = 0;
        public string? cust_salesman_code { get; set; } = ""; 
        public string? cust_salesman_name { get; set; } = ""; 
        public int? cust_handled_id { get; set; } = 0;
        public string? cust_handled_code { get; set; } = ""; 
        public string? cust_handled_name { get; set; } = ""; 
        public string? cust_location { get; set; } = "";

        public string? cust_row_type { get; set; } = "";

        public decimal? cust_credit_limit { get; set; } = 0;
        public string? cust_is_parent { get; set; } = "";
        public Nullable<int> cust_parent_id { get; set; }
        public string? cust_parent_name { get; set; } = "";
        public List<mast_contactm_dto>? cust_contacts { get; set; }

        public string? cust_est_dt { get; set; } = "";

    }
}
