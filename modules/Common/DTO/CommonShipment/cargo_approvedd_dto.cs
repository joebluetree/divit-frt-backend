using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

// Name : Sourav V
// Created Date : 09/06/2026
// Remark : This file defines data objects (variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.CommonShipment
{
    public class cargo_approvedd_dto : basetable_dto
    {
        public int ca_id { get; set; } = 0;
        public int? ca_req_no { get; set; } = 0;
        public string? ca_type { get; set; } = "";
        public string? ca_doc_type { get; set; } = "";
        public int? ca_mbl_id { get; set; } = 0;
        public string? ca_ref_no { get; set; } = "";
        public string? ca_remarks { get; set; } = "";
        public int? ca_user_id { get; set; } = 0;
        public string? ca_user_name { get; set; } = "";
        public string? ca_is_approved { get; set; } = "";
        public string? ca_date { get; set; } = "";
        public int? ca_hbl_id { get; set; } = 0;
        public string? ca_hbl_no { get; set; } = "";
        public int? ca_inv_id { get; set; } = 0;
        public string? ca_inv_no { get; set; } = "";
        public string? ca_inv_cust { get; set; } = "";
        public decimal? ca_inv_amt { get; set; } = 0;
        public int? ca_consignee_id { get; set; } = 0;
        public string? ca_consignee_name { get; set; } = "";
        public decimal? ca_approved_tot { get; set; } = 0;
        public decimal? ca_notapproved_tot { get; set; } = 0;
        public string? ca_obl_recvd_date { get; set; } = "";
        public string? ca_payment_recvd_date { get; set; } = "";
        public string? ca_is_hide { get; set; } = "";
        public string? ca_is_ar_issued { get; set; } = "";
        public string? ca_is_hide2 { get; set; } = "";
        public string? rec_files_attached { get; set; } = "";

        public int? rec_record_id { get; set; } = 0;
        public int? rec_location_id { get; set; } = 0;
        public int? rec_created_id { get; set; } = 0;
        public int cad_id { get; set; } = 0;
        public int? cad_parent_id { get; set; } = 0;
        public int? cad_approvedby_id { get; set; } = 0;
        public string? cad_approvedby_name { get; set; } = "";
        public string? cad_is_approved { get; set; } = "";
        public string? cad_approved_date { get; set; } = "";
        public string? cad_is_hide { get; set; } = "";
        public string? cad_status { get; set; } = "";
        public List<cargo_approvedd_dto>? approved { get; set; }
    }
}
