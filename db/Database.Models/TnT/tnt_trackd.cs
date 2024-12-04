using System.ComponentModel.DataAnnotations;
using Database.Models.BaseTables;

namespace Database.Models.TnT
{
    public class tnt_trackd : baseTable_company
    {
        public int trackd_id { get; set; }
        public int trackd_trackm_id { get; set; }
        public DateTime? trackd_last_updated_on { get; set; }
        public tnt_trackm? trackm { get; set; }
        public List<tnt_tracking_data>? tracking_data { get; set; }

    }

}

