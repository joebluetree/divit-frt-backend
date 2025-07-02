using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Cargo;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Sourav V
//Created Date : 01/07/2025
//Remark : this file initialise data column and their data type used in custom hold table
//version : 1 : 01/07/2025

namespace Database.Models.CommonShipment
{
    public class cargo_custom_hold
    {
        [Key]
        public int custom_id { get; set; }
        public int custom_parent_id { get; set; }
        public string? custom_refno { get; set; }
        public string? custom_houseno { get; set; }
        public string? custom_title { get; set; }
        public string? custom_comm_inv_yn { get; set; }
        public string? custom_fumi_cert_yn { get; set; }
        public string? custom_insp_chrg_yn { get; set; }
        public string? custom_comm_inv { get; set; }
        public string? custom_fumi_cert { get; set; }
        public string? custom_insp_chrg { get; set; }
        public string? custom_remarks { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public string? rec_locked { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }

        // [ForeignKey("custom_parent_id")]
        // public cargo_housem? house { get; set; }
    }
}

