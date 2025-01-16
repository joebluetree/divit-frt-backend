using Database.Models.Accounts;
using Database.Models.BaseTables;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Sourav V
//Created Date : 10/01/2025
//Remark : this file initialise data variables and their data type used in mark_qtnd-air table

namespace Database.Models.Marketing
{
    public class mark_qtnd_air : baseTable
    {
        public int qtnd_id { get; set; } //pk
        public int qtnd_qtnm_id { get; set; } // parent id (fk)
        public int? qtnd_pol_id { get; set; }
        public string? qtnd_pol_name { get; set; }
        public int? qtnd_pod_id { get; set; }
        public string? qtnd_pod_name { get; set; }
        public int? qtnd_carrier_id { get; set; }
        public string? qtnd_carrier_name { get; set; }
        public string? qtnd_trans_time { get; set; }
        public string? qtnd_routing { get; set; }
        public string? qtnd_etd { get; set; }
        public string? qtnd_min { get; set; }
        public string? qtnd_45k { get; set; }
        public string? qtnd_100k { get; set; }
        public string? qtnd_300k { get; set; }
        public string? qtnd_500k { get; set; }
        public string? qtnd_1000k { get; set; }
        public string? qtnd_fsc { get; set; }
        public string? qtnd_war { get; set; }
        public string? qtnd_sfc { get; set; }
        public string? qtnd_hac { get; set; }
        public int qtnd_order { get; set; }
        public mark_qtnm? qtnm { get; set; }
        public mast_param? pol { get; set; }
        public mast_param? pod { get; set; }
        public mast_param? carrier { get; set; }
    }
}
