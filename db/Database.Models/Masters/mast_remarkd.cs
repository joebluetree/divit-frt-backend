using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.BaseTables;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database.Models.Masters;

public class mast_remarkd //: baseTable_company
{
    [Key]
    public int? remd_id { get; set; }
    public int? remd_remarkm_id { get; set; }
    public string? remd_desc1 { get; set; }
    public int? remd_order { get; set; }
    
    [ForeignKey("remd_remarkm_id")]
    public mast_remarkm? remarkm { get; set; }

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
