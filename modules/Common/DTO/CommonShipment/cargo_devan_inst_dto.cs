using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

// Name : Sourav V
// Created Date : 09/04/2025
// Remark : This file defines data objects (variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.CommonShipment
{
    public class cargo_devan_inst_dto : basetable_dto
    {
        public int di_id { get; set; } = 0;
        public int di_parent_id { get; set; } = 0;
        public string? di_parent_type { get; set; } = "";
        public string? di_refno { get; set; } = "";
        public int? di_request_to_id { get; set; } = 0;
        public string? di_request_to_code { get; set; } = "";
        public string? di_request_to_name { get; set; } = "";
        public string? di_request_to_add1 { get; set; } = "";
        public string? di_request_to_add2 { get; set; } = "";
        public string? di_request_to_add3 { get; set; } = "";
        public string? di_request_to_add4 { get; set; } = "";

        public int? di_cargo_loc_id { get; set; } = 0;
        public string? di_cargo_loc_code { get; set; } = "";    
        public string? di_cargo_loc_name { get; set; } = "";
        public string? di_cargo_loc_add1 { get; set; } = "";
        public string? di_cargo_loc_add2 { get; set; } = "";
        public string? di_cargo_loc_add3 { get; set; } = "";
        public string? di_cargo_loc_add4 { get; set; } = "";

        public string? di_remark1 { get; set; } = "";
        public string? di_remark2 { get; set; } = "";
        public string? di_remark3 { get; set; } = "";

        public string? di_is_devan_sent { get; set; } = "";
        public string? di_devan_date { get; set; } = "";
 
    }
}
