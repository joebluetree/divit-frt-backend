using Database.Models.BaseTables;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models.UserAdmin
{
    public class mast_menum : baseTable_tracking
    {
        public int menu_id { get; set; }
        public string? menu_code { get; set; }
        public string? menu_name { get; set; }
        public string? menu_route { get; set; }
        public string? menu_param { get; set; }
        public string? menu_visible { get; set; }
        public int menu_order { get; set; }
        public int menu_module_id { get; set; }
        public mast_modulem? module { get; set; }
        public int rec_company_id { get; set; }
        public mast_companym? company { get; set; }
        public Nullable<int> menu_submenu_id { get; set; }
        public mast_modulem? submenu { get; set; }

        /*
        public int rec_company_id { get; set; }
        public company company { get; set; }
        public string rec_locked { get; set; }
        public string rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        */

    }

}
