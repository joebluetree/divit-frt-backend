using System;
using Database.Models.BaseTables;

namespace Common.DTO.AirImport;

public class cargo_desc_dto : basetable_dto
{
    public int desc_id { get; set; }
    public int desc_parent_id { get; set; } = 0;
    public string? desc_parent_type { get; set; } = "";
    public int? desc_ctr { get; set; } = 0;
    public string? desc_mark { get; set; } = "";
    public string? desc_package { get; set; } = "";
    public string? desc_description { get; set; } = "";

}
