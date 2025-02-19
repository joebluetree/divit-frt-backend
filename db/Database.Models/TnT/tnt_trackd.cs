using System.ComponentModel.DataAnnotations;
using Database.Models.BaseTables;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;


namespace Database.Models.TnT
{
    public class tnt_trackd //: baseTable_company
    {
        [Key]
        public int trackd_id { get; set; }
        public int trackd_trackm_id { get; set; }
        public DateTime? trackd_last_updated_on { get; set; }
        
        [ForeignKey("trackd_trackm_id")]
        public tnt_trackm? trackm { get; set; }
        public List<tnt_tracking_data>? tracking_data { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

    }

}

