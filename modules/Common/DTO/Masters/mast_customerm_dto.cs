using Database.Models.BaseTables;



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
        public int? cust_state_id { get; set; } = 0;
        public string? cust_state_name { get; set; } = "";
        public int? cust_country_id { get; set; } = 0;
        public string? cust_country_name { get; set; } = "";
        public string? cust_zip_code { get; set; } = "";
        public string? cust_title { get; set; } = "";
        public string? cust_contact { get; set; } = "";
        public string? cust_designation { get; set; } = "";
        public string? cust_tel { get; set; } = "";
        public string? cust_fax { get; set; } = "";
        public string? cust_mobile { get; set; } = "";
        public string? cust_web { get; set; } = "";
        public string? cust_email { get; set; } = "";
        public string? cust_refer_by { get; set; } = "";
        public int? cust_salesman_id { get; set; } = 0;
        public string? cust_salesman_name { get; set; } = "";
        public int? cust_handled_id { get; set; } = 0;
        public string? cust_handled_name { get; set; } = "";
        public int? cust_location_id { get; set; } = 0;
        public string? cust_location_name { get; set; } = "";

        public string? cust_row_type { get; set; } = "";

        public decimal? cust_credit_limit { get; set; } = 0;
        public string? cust_is_parent { get; set; } = "";

        public string? cust_is_shipper { get; set; } = "";
        public string? cust_is_consignee { get; set; } = "";
        public string? cust_is_importer { get; set; } = "";
        public string? cust_is_exporter { get; set; } = "";
        public string? cust_is_cha { get; set; } = "";
        public string? cust_is_forwarder { get; set; } = "";
        public string? cust_is_oagent { get; set; } = "";
        public string? cust_is_acarrier { get; set; } = "";
        public string? cust_is_scarrier { get; set; } = "";
        public string? cust_is_trucker { get; set; } = "";
        public string? cust_is_warehouse { get; set; } = "";
        public string? cust_is_sterminal { get; set; } = "";
        public string? cust_is_aterminal { get; set; } = "";
        public string? cust_is_shipvendor { get; set; } = "";
        public string? cust_is_gvendor { get; set; } = "";
        public string? cust_is_employee { get; set; } = "";
        public string? cust_is_contract { get; set; } = "";
        public string? cust_is_miscell { get; set; } = "";
        public string? cust_is_tbd { get; set; } = "";
        public string? cust_is_bank { get; set; } = "";

        public string? cust_nomination { get; set; } = "";
        public string? cust_priority { get; set; } = "";
        public string? cust_criteria { get; set; } = "";
        public decimal? cust_min_profit { get; set; } = 0;
        public string? cust_firm_code { get; set; } = "";
        public string? cust_einirsno { get; set; } = "";
        public int? cust_days { get; set; } = 0;
        public string? cust_is_splacc { get; set; } = "";
        public string? cust_is_actual_vendor { get; set; } = "";
        public string? cust_is_blackacc { get; set; } = "";
        public string? cust_splacc_memo { get; set; } = "";
        public string? cust_is_ctpat { get; set; } = "";
        public string? cust_ctpat_no { get; set; } = "";
        public string? cust_marketing_mail { get; set; } = "";

        public int? cust_chb_id { get; set; } = 0;
        public string? cust_chb_code { get; set; } = "";
        public string? cust_chb_name { get; set; } = "";
        public string? cust_chb_address1 { get; set; } = "";
        public string? cust_chb_address2 { get; set; } = "";
        public string? cust_chb_address3 { get; set; } = "";
        public string? cust_chb_group { get; set; } = "";
        public string? cust_chb_contact { get; set; } = "";
        public string? cust_chb_tel { get; set; } = "";
        public string? cust_chb_fax { get; set; } = "";
        public string? cust_chb_email { get; set; } = "";

        public string? cust_poa_customs_yn { get; set; } = "";
        public string? cust_brokers { get; set; } = "";
        public string? cust_poa_isf_yn { get; set; } = "";
        public string? cust_bond_yn { get; set; } = "";
        public string? cust_punch_from { get; set; } = "";
        public string? cust_bond_no { get; set; } = "";
        public string? cust_bond_expdt { get; set; } = "";

        public int? cust_branch_id { get; set; } = 0;
        public string? cust_branch_name { get; set; } = "";
        public string? cust_protected { get; set; } = "";
        public int? cust_cur_id { get; set; } = 0;
        public string? cust_cur_name { get; set; } = "";


        public Nullable<int> cust_parent_id { get; set; }
        public string? cust_parent_name { get; set; } = "";
        public List<mast_contactm_dto>? cust_contacts { get; set; }

        public string? cust_est_dt { get; set; } = "";
        
        public int? rec_files_count { get; set; }
        public string? rec_files_attached { get; set; }

    }
}
