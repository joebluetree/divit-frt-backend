using System;
using Database.Models.BaseTables;

namespace Database.Models.Masters;

public class mast_wiretransd : baseTable
{
    public int wtid_id { get; set; } //pk
    public int wtid_wtim_id { get; set; } //fk
    public int? wtid_benef_id { get; set; } //fk
    public string? wtid_benef_ref { get; set; }
    public int? wtid_bank_id { get; set; } //fk
    public decimal? wtid_trns_amt { get; set; } 
    public int? wtid_order { get; set; }
    public mast_wiretransm? wtim { get; set; }
    public mast_customerm? benef { get; set; }
    public mast_customerm? bank { get; set; }
}
