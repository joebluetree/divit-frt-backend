using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name    : Sourav V
//Created : 18/06/2025
//Remark  : Converted from PostgreSQL definition for Master B/L

namespace Database.Models.Cargo
{
    public class cargo_coo
    {
        [Key]
        public int mbld_id { get; set; }
        public int mbld_parent_id { get; set; }
        public string? mbld_mode { get; set; }
        public string? mbld_exp_ref { get; set; }
        public int? mbld_shipper_id { get; set; }
        public string? mbld_shipper_name { get; set; }
        public string? mbld_shipper_add1 { get; set; }
        public string? mbld_shipper_add2 { get; set; }
        public string? mbld_shipper_add3 { get; set; }
        public string? mbld_shipper_add4 { get; set; }
        public int? mbld_consignee_id { get; set; }
        public string? mbld_consignee_name { get; set; }
        public string? mbld_consignee_add1 { get; set; }
        public string? mbld_consignee_add2 { get; set; }
        public string? mbld_consignee_add3 { get; set; }
        public string? mbld_consignee_add4 { get; set; }
        public int? mbld_notify_id { get; set; }
        public string? mbld_notify_name { get; set; }
        public string? mbld_notify_add1 { get; set; }
        public string? mbld_notify_add2 { get; set; }
        public string? mbld_notify_add3 { get; set; }
        public string? mbld_notify_add4 { get; set; }
        public int? mbld_agent_id { get; set; }
        public string? mbld_place_receipt { get; set; }
        public string? mbld_pol_name { get; set; }
        public string? mbld_pod_name { get; set; }
        public string? mbld_place_delivery { get; set; }
        public string? mbld_move_type { get; set; }
        public string? mbld_is_cntrized { get; set; }
        public int? mbld_handled_id { get; set; }
        public string? mbld_print_vsl_voy { get; set; }
        public string? mbld_clean { get; set; }
        public decimal? mbld_cbm { get; set; }
        public decimal? mbld_weight { get; set; }
        public decimal? mbld_lbs { get; set; }
        public decimal? mbld_cft { get; set; }
        public string? mbld_remark1 { get; set; }
        public string? mbld_remark2 { get; set; }
        public string? mbld_remark3 { get; set; }
        public string? mbld_print_kgs { get; set; }
        public string? mbld_print_lbs { get; set; }

        public int? rec_year { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; } = 1;
        public string? rec_locked { get; set; }

        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }

        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }

        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }

        [ForeignKey("mbld_shipper_id")]
        public mast_customerm? shipper { get; set; }

        [ForeignKey("mbld_consignee_id")]
        public mast_customerm? consignee { get; set; }

        [ForeignKey("mbld_notify_id")]
        public mast_customerm? notify { get; set; }

        [ForeignKey("mbld_agent_id")]
        public mast_customerm? agent { get; set; }

        [ForeignKey("mbld_handled_id")]
        public mast_param? handledby { get; set; }
    }
}
