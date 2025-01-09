using System;
using Database.Models.BaseTables;
using Database.Models.Masters;

namespace Database.Models.Marketing
{
    public class mark_qtnd_fcl : baseTable
    {
    public int? qtnd_id { get; set; } //pk
    public int? qtnd_qtnm_id { get; set; } //fk
    public int? qtnd_pol_id { get; set; }
    public string? qtnd_pol_name { get; set; }
    public int? qtnd_pod_id { get; set; }
    public string? qtnd_pod_name { get; set; }
    public int? qtnd_carrier_id { get; set; }
    public string? qtnd_carrier_name { get; set; }
    public string? qtnd_trans_time { get; set; }//
    public string? qtnd_routing { get; set; }//
    public string? qtnd_cntr_type { get; set; }
    public string? qtnd_etd { get; set; }
    public string? qtnd_cutoff { get; set; }
    public decimal? qtnd_of { get; set; }//
    public decimal? qtnd_pss { get; set; }//
    public decimal? qtnd_baf { get; set; }//
    public decimal? qtnd_isps { get; set; }//
    public decimal? qtnd_haulage { get; set; }//
    public decimal? qtnd_ifs { get; set; }//
    public decimal? qtnd_tot_amt { get; set; }
    public int? order { get; set; }//
    public mast_param? pol { get; set; }
    public mast_param? pod { get; set; }
    public mast_param? carrier { get; set; }
    public mark_qtnm? qtnm { get; set; }

    }

}

