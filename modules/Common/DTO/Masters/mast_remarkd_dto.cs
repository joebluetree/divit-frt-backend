using System;
using Database.Models.BaseTables;

namespace Common.DTO.Masters;

public class mast_remarkd_dto : basetable_dto
{
    public int? remd_id { get; set; }
    public int? remd_remarkm_id { get; set; }
    public string? remd_desc1 { get; set; }
    public int? remd_order { get; set; }
}