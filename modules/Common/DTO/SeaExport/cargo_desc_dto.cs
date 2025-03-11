using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

// Name : Sourav V
// Created Date : 05/03/2025
// Remark : This file defines data objects (variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.SeaExport
{
    public class cargo_desc_dto : basetable_dto
    {
        public int desc_id { get; set; } = 0;
        public int desc_parent_id { get; set; } = 0;
        public string? desc_parent_type { get; set; } = "";
        public int? desc_ctr { get; set; } = 0;
        public string? desc_mark { get; set; } = "";
        public string? desc_package { get; set; } = "";
        public string? desc_description { get; set; } = "";
    }
}
