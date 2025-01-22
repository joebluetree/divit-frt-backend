using System;
using Database.Models.BaseTables;

namespace Database.Models.Masters;

public class mast_remarkm : baseTable_company
{
    public int rem_id { get; set; }
    public string? rem_name { get; set; }

}
