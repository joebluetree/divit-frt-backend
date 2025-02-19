using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.BaseTables;
using Database.Models.UserAdmin;

namespace Database.Models.Masters;

public class mast_wiretransd //: baseTable
{
    [Key]
    public int wtid_id { get; set; } //pk
    public int wtid_wtim_id { get; set; } //fk
    public int? wtid_benef_id { get; set; } //fk
    public string? wtid_benef_ref { get; set; }
    public int? wtid_bank_id { get; set; } //fk
    public decimal? wtid_trns_amt { get; set; } 
    public int? wtid_order { get; set; }
    [ForeignKey("wtid_wtim_id")]
    public mast_wiretransm? wtim { get; set; }
    [ForeignKey("wtid_benef_id")]
    public mast_customerm? benef { get; set; }
    [ForeignKey("wtid_bank_id")]
    public mast_customerm? bank { get; set; }

    [ConcurrencyCheck]
    public int rec_version { get; set; }
    public string? rec_locked { get; set; }
    public string? rec_created_by { get; set; }
    public DateTime rec_created_date { get; set; }
    public string? rec_edited_by { get; set; }
    public DateTime? rec_edited_date { get; set; }
    public int rec_company_id { get; set; }
    public int? rec_branch_id { get; set; }

    [ForeignKey("rec_company_id")]
    public mast_companym? company { get; set; }
    [ForeignKey("rec_branch_id")]
    public mast_branchm? branch { get; set; }
}
