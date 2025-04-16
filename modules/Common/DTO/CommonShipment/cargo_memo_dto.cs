using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

// Name : Sourav V
// Created Date : 09/04/2025
// Remark : This file defines data objects (variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.CommonShipment
{
    public class cargo_memo_dto : basetable_dto
    {
        public int memo_id { get; set; } = 0;
        public int memo_parent_id { get; set; } = 0;
        public string? memo_parent_type { get; set; } = "";
        public int? memo_remarks_id { get; set; } = 0;
        public string? memo_remarks_code { get; set; } = "";
        public string? memo_remarks_name { get; set; } = "";
        public string? memo_date { get; set; } = "";
        public string? memo_memo { get; set; } = "";
        public string? rec_files_attached { get; set; } = "";
        public List<cargo_memo_dto>? memo_details {get; set;} 
    }
}
