using System;
using Database.Models.BaseTables;

namespace Common.DTO.Masters;

public class mast_remarkm_dto : basetable_dto
{
   public int rem_id { get; set; }
   public string? rem_name { get; set; }
   public List<mast_remarkd_dto>? rem_remarks { get; set; }

}
