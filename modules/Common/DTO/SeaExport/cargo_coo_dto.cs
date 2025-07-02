using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 18/06/2025
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.SeaExport
{
    public class cargo_coo_dto : basetable_dto
    {
        public int mbld_id { get; set; } = 0;
        public int mbld_parent_id { get; set; } = 0;
        public string? mbld_mode { get; set; } = "";
        public string? mbld_exp_ref { get; set; } = "";
        public int? mbld_shipper_id { get; set; } = 0;
        public string? mbld_shipper_code { get; set; } = "";
        public string? mbld_shipper_name { get; set; } = "";
        public string? mbld_shipper_add1 { get; set; } = "";
        public string? mbld_shipper_add2 { get; set; } = "";
        public string? mbld_shipper_add3 { get; set; } = "";
        public string? mbld_shipper_add4 { get; set; } = "";

        public int? mbld_consignee_id { get; set; } = 0;
        public string? mbld_consignee_code { get; set; } = "";
        public string? mbld_consignee_name { get; set; } = "";
        public string? mbld_consignee_add1 { get; set; } = "";
        public string? mbld_consignee_add2 { get; set; } = "";
        public string? mbld_consignee_add3 { get; set; } = "";
        public string? mbld_consignee_add4 { get; set; } = "";

        public int? mbld_notify_id { get; set; } = 0;
        public string? mbld_notify_code { get; set; } = "";
        public string? mbld_notify_name { get; set; } = "";
        public string? mbld_notify_add1 { get; set; } = "";
        public string? mbld_notify_add2 { get; set; } = "";
        public string? mbld_notify_add3 { get; set; } = "";
        public string? mbld_notify_add4 { get; set; } = "";

        public int? mbld_agent_id { get; set; } = 0;
        public string? mbld_agent_name { get; set; } = "";
        public string? mbld_place_receipt { get; set; } = "";
        public string? mbld_pol_name { get; set; } = "";
        public string? mbld_pod_name { get; set; } = "";
        public string? mbld_place_delivery { get; set; } = "";
        public string? mbld_move_type { get; set; } = "";
        public string? mbld_is_cntrized { get; set; } = "";
        public int? mbld_handled_id { get; set; } = 0;
        public string? mbld_handled_name { get; set; } = "";
        public string? mbld_print_vsl_voy { get; set; } = "";
        public string? mbld_clean { get; set; } = "";

        public decimal? mbld_cbm { get; set; } = 0;
        public decimal? mbld_weight { get; set; } = 0;
        public decimal? mbld_lbs { get; set; } = 0;
        public decimal? mbld_cft { get; set; } = 0;

        public string? mbld_remark1 { get; set; } = "";
        public string? mbld_remark2 { get; set; } = "";
        public string? mbld_remark3 { get; set; } = "";

        public string? mbld_print_kgs { get; set; } = "";
        public string? mbld_print_lbs { get; set; } = "";
        // public List<cargo_container_dto>? master_cntr { get; set; }
        // public List<cargo_sea_exporth_dto>? master_house { get; set; }
        public int desc_parent_id { get; set; } = 0;
        public cargo_desc_dto? marks1 { get; set; }
        public cargo_desc_dto? marks2 { get; set; }
        public cargo_desc_dto? marks3 { get; set; }
        public cargo_desc_dto? marks4 { get; set; }
        public cargo_desc_dto? marks5 { get; set; }
        public cargo_desc_dto? marks6 { get; set; }
        public cargo_desc_dto? marks7 { get; set; }
        public cargo_desc_dto? marks8 { get; set; }
        public cargo_desc_dto? marks9 { get; set; }
        public cargo_desc_dto? marks10 { get; set; }
        public cargo_desc_dto? marks11 { get; set; }
        public cargo_desc_dto? marks12 { get; set; }
        public cargo_desc_dto? marks13 { get; set; }
        public cargo_desc_dto? marks14 { get; set; }
        public cargo_desc_dto? marks15 { get; set; }
        public cargo_desc_dto? marks16 { get; set; }
        public cargo_desc_dto? marks17 { get; set; }

    }
}
