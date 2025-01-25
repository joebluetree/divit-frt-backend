using System;
using Database.Models.BaseTables;

namespace Common.DTO.Masters;

public class mast_wiretransd_dto : basetable_dto
{
    public int wtid_id { get; set; } //pk
    public int wtid_wtim_id { get; set; } //fk
    public int? wtid_benef_id { get; set; } //fk
    public string? wtid_benef_name { get; set; }
    public string? wtid_benef_ref { get; set; }
    public int? wtid_bank_id { get; set; } //fk
    public string? wtid_bank_name { get; set; }
    public decimal? wtid_trns_amt { get; set; } 
    public int? wtid_order { get; set; }
}
