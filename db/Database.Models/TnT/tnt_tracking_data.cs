using Database.Models.BaseTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;


namespace Database.Models.TnT
{
    public class tnt_tracking_data //: baseTable_company
    {
        [Key]
        public int track_id { get; set; }

        public int tnt_trackm_id { get; set; }
        public int tnt_trackd_id { get; set; }
        public DateTime tnt_eventCreatedDateTime { get; set; }
        public DateTime tnt_eventCreatedDateTime_utc { get; set; }
        public DateTime tnt_eventDateTime { get; set; }
        public DateTime tnt_eventDateTime_utc { get; set; }

        public string? tnt_container { get; set; }
        public string? tnt_transport_mode { get; set; }
        public string? tnt_event_type { get; set; }
        public string? tnt_event_confirm_status { get; set; }
        public string? tnt_status_code { get; set; }
        public string? tnt_status_name { get; set; }
        public string? tnt_port_code { get; set; }
        public string? tnt_port_name { get; set; }
        public string? tnt_port_location { get; set; }
        public string? tnt_vessel { get; set; }
        public string? tnt_vessel_imon { get; set; }
        public string? tnt_voyage { get; set; }

        public string? tnt_row_type { get; set; }

        [ForeignKey("tnt_trackm_id")]
        public tnt_trackm? trackm { get; set; }
        
        [ForeignKey("tnt_trackd_id")]
        public tnt_trackd? trackd { get; set; }


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
