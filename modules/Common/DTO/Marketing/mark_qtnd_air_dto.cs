using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;


namespace Common.DTO.Marketing
{
    public class mark_qtnd_air_dto : basetable_dto
    {
        public int qtnd_id { get; set; } = 0;
        public int qtnd_qtnm_id { get; set; } = 0;
        public int? qtnd_pol_id { get; set; } = 0;
        public string? qtnd_pol_code { get; set;}= "";
        public string? qtnd_pol_name { get; set; } = "";
        public int? qtnd_pod_id { get; set; } = 0;
        public string? qtnd_pod_code { get; set;}= "";
        public string? qtnd_pod_name { get; set; } = "";
        public int? qtnd_carrier_id { get; set; } = 0;
        public string? qtnd_carrier_code { get; set;}= "";
        public string? qtnd_carrier_name { get; set; } = "";
        public string? qtnd_trans_time { get; set; } = "";
        public string? qtnd_routing { get; set; } = "";
        public string? qtnd_etd { get; set; } = "";
        public string? qtnd_min { get; set; } = "";
        public string? qtnd_45k { get; set; } = "";
        public string? qtnd_100k { get; set; } = "";
        public string? qtnd_300k { get; set; } = "";
        public string? qtnd_500k { get; set; } = "";
        public string? qtnd_1000k { get; set; } = "";
        public string? qtnd_fsc { get; set; } = "";
        public string? qtnd_war { get; set; } = "";
        public string? qtnd_sfc { get; set; } = "";
        public string? qtnd_hac { get; set; } = "";
        public int qtnd_order { get; set; } = 0;
                        
    }
}
