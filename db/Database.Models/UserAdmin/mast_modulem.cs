using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Masters;

namespace Database.Models.UserAdmin
{
    public class mast_modulem //: baseTable_tracking
    {
        [Key]
        public int module_id { get; set; }
        public string? module_name { get; set; }
        public string? module_is_installed { get; set; }
        public int module_order { get; set; }
        public Nullable<int> module_parent_id { get; set; }
        public int rec_company_id { get; set; }
        
        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }
        //public List<mast_menum>? menus { get; set; }
        
        [ForeignKey("module_parent_id")]
        public mast_modulem? module { get; set; }

        
        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }

    }

}

