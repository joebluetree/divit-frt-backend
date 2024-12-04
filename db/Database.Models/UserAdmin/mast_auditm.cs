using System.ComponentModel.DataAnnotations;

namespace Database.Models.UserAdmin
{
    public class mast_auditm
    {
        public int log_id { get; set; }
        public DateTime? log_date { get; set; }
        public string? log_user_code { get; set; }
        public string? log_table { get; set; }
        public int log_table_id { get; set; }
        public string? log_column { get; set; }
        public string? log_desc { get; set; }

        public string? log_refno { get; set; }
        public string? log_value { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }
    }

}

