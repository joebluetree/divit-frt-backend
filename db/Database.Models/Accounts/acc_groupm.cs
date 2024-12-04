using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models.BaseTables;

namespace Database.Models.Accounts
{
    public class acc_groupm : baseTable_company
    {
        public int grp_id { get; set; }
        public string? grp_name { get; set; }
        public int grp_order { get; set; }
        public string? grp_main_group { get; set; }

    }

}
