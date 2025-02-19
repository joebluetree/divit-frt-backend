using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Database.Models.UserAdmin;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models.BaseTables;

namespace Database.Models.Accounts
{
    public class acc_groupm //: baseTable_company
    {
        [Key]
        public int grp_id { get; set; }
        public string? grp_name { get; set; }
        public int grp_order { get; set; }
        public string? grp_main_group { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        // public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }
        // public int rec_branch_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

    }

}
