using System;
using Database.Models.BaseTables;

namespace Database.Models.Masters;

public class mast_remarkd : baseTable_company
{
    public int remd_id { get; set; }
    public int remd_remarkm_id { get; set; }
    public string? remd_desc1 { get; set; }
    public int remd_order { get; set; }
    public mast_remarkm? remarkm { get; set; }

}
