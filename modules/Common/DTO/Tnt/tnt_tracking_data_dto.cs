﻿using Database.Models.BaseTables;

namespace Common.DTO.Tnt
{
    public class tnt_tracking_data_dto : basetable_dto
    {
        public int tnt_track_id { get; set; }
        public int tnt_trackm_id { get; set; }
        public int tnt_trackd_id { get; set; }
        public string? tnt_event_date { get; set; }
        public string? tnt_date { get; set; }
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

    }
}
