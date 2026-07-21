using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

// Name : Sourav V
// Created Date : 07/07/2026
// Remark : This file defines data objects (variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.CommonShipment
{
    public class cargo_payrequest_dto : basetable_dto
    {
        public int cp_id { get; set; } = 0;
        public int? cp_slno { get; set; } = 0;
        public string? cp_mode { get; set; } = "";
        public string? cp_source { get; set; } = "";
        public int? cp_master_id { get; set; } = 0;
        public string? cp_master_no { get; set; } = "";
        public string? cp_paytype_needed { get; set; } = "";
        public string? cp_spl_notes { get; set; } = "";
        public string? cp_payment_date { get; set; } = "";
        public string? cp_pay_status { get; set; } = "";
        public int? cp_cust_id { get; set; } = 0;
        public string? cp_cust_name { get; set; } = "";
        public int? cp_inv_id { get; set; } = 0;
        public string? cp_inv_no { get; set; } = "";
        
        public string? rec_deleted { get; set; } = "";
        public string? rec_deleted_by { get; set; } = "";
        public string? rec_deleted_date { get; set; } = "";
        public int? rec_record_id { get; set; } = 0;
        public int? rec_location_id { get; set; } = 0;
        public int? rec_created_id { get; set; } = 0;
        public List<cargo_payrequest_dto>? cp_details { get; set; } 
    }
}
