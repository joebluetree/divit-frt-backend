using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.BaseTables
{
    public class basetable_dto
    {

        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public int rec_company_id { get; set; } = 0;
        public string? rec_company_name { get; set; }
        public int? rec_branch_id { get; set; } = 0;
        public string? rec_branch_name { get; set; }
        public string? rec_created_by { get; set; }
        public string? rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public string? rec_edited_date { get; set; }

    }
}
