using Database.Models.BaseTables;

namespace Database.Models.Masters
{
    public class mast_param : baseTable
    {
        public int param_id { get; set; }
        public string? param_type { get; set; }
        public string? param_code { get; set; }
        public string? param_name { get; set; }
        public string? param_value1 { get; set; }
        public string? param_value2 { get; set; }
        public string? param_value3 { get; set; }
        public string? param_value4 { get; set; }
        public string? param_value5 { get; set; }
        public int param_order { get; set; }

        /*
        public int rec_company_id { get; set; }
        public company company { get; set; }
        public int? rec_branch_id { get; set; }
        public branch branch { get; set; }
        public string rec_locked { get; set; }
        public string rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }

        */
    }

}
