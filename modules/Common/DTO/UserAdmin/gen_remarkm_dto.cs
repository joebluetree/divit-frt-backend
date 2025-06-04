using System;
using Database.Models.BaseTables;

namespace Common.DTO.UserAdmin;

public class gen_remarkm_dto : basetable_dto
{
    public int remk_id { get; set; }

    public int? remk_parent_id { get; set; }

    public string? remk_parent_type { get; set; }

    public string? remk_desc { get; set; }

    public int? remk_order { get; set; }
    public List<gen_remarkm_dto>? remk_remarks { get; set; }
}
