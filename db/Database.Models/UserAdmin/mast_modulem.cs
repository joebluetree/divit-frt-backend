using System.ComponentModel.DataAnnotations;
using Database.Models.BaseTables;
using Database.Models.Masters;

namespace Database.Models.UserAdmin
{
    public class mast_modulem : baseTable_tracking
    {

        public int module_id { get; set; }
        public string? module_name { get; set; }
        public string? module_is_installed { get; set; }
        public int module_order { get; set; }
        public Nullable<int> module_parent_id { get; set; }
        public int rec_company_id { get; set; }
        public mast_companym? company { get; set; }
        public List<mast_menum>? menus { get; set; }
        public mast_modulem? module { get; set; }

    }

}

