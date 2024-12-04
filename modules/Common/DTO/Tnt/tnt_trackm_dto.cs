using Database.Models.BaseTables;
using Database.Models.TnT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Tnt
{
    public class tnt_trackm_dto : basetable_dto
    {
        public int track_id { get; set; }
        public string? track_book_no { get; set; }
        public string? track_cntr_no { get; set; }
        public int track_trackd_id { get; set; }
        public int track_carrier_id { get; set; }
        public string? track_carrier_code { get; set; }
        public string? track_carrier_name { get; set; }
        public string? track_carrier_scac { get; set; }

        public string? track_api_type { get; set; }
        public string? track_request_id { get; set; }

        public DateTime? track_last_updated_on { get; set; }
        public DateTime? track_sent_on { get; set; }


        public string? track_pol_code { get; set; }
        public string? track_pol_name { get; set; }
        public string? track_pol_etd { get; set; }


        public string? track_pod_code { get; set; }
        public string? track_pod_name { get; set; }
        public string? track_pod_eta { get; set; }

        public string? track_vessel_code { get; set; }
        public string? track_vessel_name { get; set; }
        public string? track_voyage { get; set; }

        public IEnumerable<tnt_tracking_data_dto>? tracking_data { get; set; }

    }
}
