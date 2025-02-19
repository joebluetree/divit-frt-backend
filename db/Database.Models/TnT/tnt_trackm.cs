using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.BaseTables;
using Database.Models.Masters;
using Database.Models.UserAdmin;

namespace Database.Models.TnT
{
    public class tnt_trackm //: baseTable_company
    {
        [Key]
        public int track_id { get; set; }
        public string? track_book_no { get; set; }
        public string? track_cntr_no { get; set; }
        public int track_trackd_id { get; set; }

        public int track_carrier_id { get; set; }

        public DateTime? track_last_updated_on { get; set; }

        public string? track_api_type { get; set; }

        public string? track_request_id { get; set; }
        public string? track_pol_code { get; set; }
        public string? track_pol_name { get; set; }
        public DateTime? track_pol_etd { get; set; }

        public string? track_pod_code { get; set; }
        public string? track_pod_name { get; set; }
        public DateTime? track_pod_eta { get; set; }

        public string? track_vessel_code { get; set; }
        public string? track_vessel_name { get; set; }
        public string? track_voyage { get; set; }


        public DateTime? track_sent_on { get; set; }
        public List<tnt_trackd>? trackd { get; set; }
        public List<tnt_tracking_data>? tracking_data { get; set; }

        [ForeignKey("track_carrier_id")]
        public mast_param? param_carrier { get; set; }
                
                
        [ConcurrencyCheck]
        public int rec_version { get; set; }
        // public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }


    }

}

