using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

// Name : Sourav V
// Created Date : 27/02/2025
// Remark : This file defines data objects (variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.SeaExport
{
    public class cargo_container_dto : basetable_dto
    {
        public int cntr_id { get; set; } = 0;
        public int cntr_mbl_id { get; set; } = 0;
        public int cntr_hbl_id { get; set; } = 0;
        public string? cntr_catg { get; set; } = ""; // Type (master/house)
        public string? cntr_no { get; set; } = "";
        public int? cntr_type_id { get; set; } = 0;
        public string? cntr_type_name { get; set; } = "";
        public string? cntr_sealno { get; set; } = "";
        public string? cntr_movement { get; set; } = "";
        public int? cntr_pieces { get; set; } = 0;
        public int? cntr_packages_unit_id { get; set; } = 0;
        public string? cntr_packages_unit_name { get; set; } = "";
        public int? cntr_packages { get; set; } = 0;
        public decimal? cntr_teu { get; set; } = 0;
        public decimal? cntr_cbm { get; set; } = 0;
        public string? cntr_weight_uom { get; set; } = "";
        public decimal? cntr_weight { get; set; } = 0;
        public string? cntr_rider { get; set; } = "";
        public decimal? cntr_tare_weight { get; set; } = 0;
        public string? cntr_pick_date { get; set; }
        public string? cntr_return_date { get; set; }
        public string? cntr_lfd { get; set; }
        public string? cntr_discharge_date { get; set; }
        public int cntr_order { get; set; } = 0;
    
    }
}
