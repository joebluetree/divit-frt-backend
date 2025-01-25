using Database.Models.BaseTables;

namespace Database.Models.Masters
{
    public class mast_contactm : baseTable_company
    {
        public int cont_id { get; set; }
        public int cont_parent_id { get; set; }
        public string? cont_title { get; set; }
        public string? cont_name { get; set; }
        public int? cont_group_id { get; set; }
        public string? cont_designation { get; set; }
        public string? cont_email { get; set; }
        public string? cont_tel { get; set; }
        public string? cont_mobile { get; set; }
        public string? cont_remarks { get; set; }
        public mast_param? contgroup { get; set; }
        public mast_customerm? customer { get; set; }
        public int cont_country_id { get; set; }
        public mast_param? country { get; set; }

    }
}

