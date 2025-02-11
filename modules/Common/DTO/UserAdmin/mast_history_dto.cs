using System;

namespace Common.DTO.UserAdmin;

public class mast_history_dto
{
        public int? log_id { get; set; }
        public string? log_date { get; set; }
        public string? log_user_code { get; set; }
        public string? log_table { get; set; }
        public int log_table_row_id { get; set; }
        public string? log_column { get; set; }
        public string? log_desc { get; set; }
        public string? log_refno { get; set; }
        public string? log_old_value { get; set; }
        public string? log_new_value { get; set; }
        public string? log_status { get; set; }
        public string? log_from_date { get; set; }
        public string? log_to_date { get; set; }
        public int rec_company_id { get; set; }
        public int? rec_branch_id { get; set; }
        public int? rec_version { get; set; }
        public int? rec_order { get; set; }
}
