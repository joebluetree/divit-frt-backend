using System;
using Common.DTO.Masters;
using Database.Models.BaseTables;

namespace Common.DTO.Marketing;

public class mark_qtnd_fcl_dto : basetable_dto
{
    public int? qtnd_id { get; set; }
    public int? qtnd_qtnm_id { get; set; }
    public int? qtnd_pol_id { get; set; }
    public string? qtnd_pol_name { get; set; }
    public int? qtnd_pod_id { get; set; }
    public string? qtnd_pod_name { get; set; }
    public int? qtnd_carrier_id { get; set; }
    public string? qtnd_carrier_name { get; set; }
    public string? qtnd_trans_time { get; set; }
    public string? qtnd_routing { get; set; }
    public string? qtnd_cntr_type { get; set; }
    public string? qtnd_etd { get; set; }
    public string? qtnd_cutoff { get; set; }
    public decimal? qtnd_of { get; set; }
    public decimal? qtnd_pss { get; set; }
    public decimal? qtnd_baf { get; set; }
    public decimal? qtnd_isps { get; set; }
    public decimal? qtnd_haulage { get; set; }
    public decimal? qtnd_ifs { get; set; }
    public decimal? qtnd_tot_amt { get; set; }
    public int? qtnd_order {get; set; }

}
