using System.ComponentModel.DataAnnotations;
using Database.Models.UserAdmin;

namespace Database.Models.BaseTables
{
    public class baseTable_tracking
    {
        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }


    }
    public class baseTable : baseTable_tracking
    {

        public int rec_company_id { get; set; }
        public mast_companym? company { get; set; }
        public int? rec_branch_id { get; set; }
        public mast_branchm? branch { get; set; }

    }

    public class baseTable_company : baseTable_tracking
    {
        public int rec_company_id { get; set; }
        public mast_companym? company { get; set; }

    }
    public class baseTable_branch : baseTable_company
    {
        public int? rec_branch_id { get; set; }
        public mast_branchm? branch { get; set; }

    }


}

