using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

// Name : Sourav V
// Created Date : 01/07/2025
// Remark : This file defines data objects (variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.CommonShipment
{
    public class cargo_custom_hold_dto : basetable_dto
    {
        public int custom_id { get; set; } = 0;
        public int custom_parent_id { get; set; } = 0;
        public string? custom_refno { get; set; } = "";
        public string? custom_houseno { get; set; } = "";
        public string? custom_title { get; set; } = "";
        public string? custom_comm_inv_yn { get; set; } = "";
        public string? custom_fumi_cert_yn { get; set; } = "";
        public string? custom_insp_chrg_yn { get; set; } = "";
        public string? custom_comm_inv { get; set; } = "";
        public string? custom_fumi_cert { get; set; } = "";
        public string? custom_insp_chrg { get; set; } = "";
        public string? custom_remarks { get; set; }  = "";
    }
}