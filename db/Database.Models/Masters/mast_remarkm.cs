using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.BaseTables;
using Database.Models.UserAdmin;

namespace Database.Models.Masters;

public class mast_remarkm //: baseTable_company
{
    [Key]
    public int rem_id { get; set; }
    public string? rem_name { get; set; }
    public List<mast_remarkd>? rem_remarks { get; set; }

    [ConcurrencyCheck]
    public int rec_version { get; set; }

    public string? rec_locked { get; set; }
    public string? rec_created_by { get; set; }
    public DateTime rec_created_date { get; set; }
    public string? rec_edited_by { get; set; }
    public DateTime? rec_edited_date { get; set; }
    public int rec_company_id { get; set; }

    [ForeignKey("rec_company_id")]
    public mast_companym? company { get; set; }


}
