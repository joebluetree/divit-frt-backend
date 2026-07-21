using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Accounts;
using Database.Models.Cargo;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Sourav V
//Created Date : 09/06/2026
//Remark : this file initialise data variables and their data type used in approvedm table

namespace Database.Models.CommonShipment
{
    public class cargo_approvedm
    {
        [Key]
        public int ca_id { get; set; }
        public int ca_req_no { get; set; }
        public string? ca_type { get; set; }
        public string? ca_doc_type { get; set; }
        public int? ca_mbl_id { get; set; }
        public string? ca_ref_no { get; set; }
        public string? ca_remarks { get; set; }
        public int? ca_user_id { get; set; }
        public string? ca_is_approved { get; set; }
        public DateOnly? ca_date { get; set; }
        public int? ca_hbl_id { get; set; }
        public int? ca_inv_id { get; set; }
        public int? ca_consignee_id { get; set; }
        public decimal? ca_approved_tot { get; set; }
        public decimal? ca_notapproved_tot { get; set; }
        public DateTime? ca_obl_recvd_date { get; set; }
        public DateTime? ca_payment_recvd_date { get; set; }
        public string? ca_is_hide { get; set; }
        public string? ca_is_ar_issued { get; set; }
        public string? ca_is_hide2 { get; set; }
        public string? rec_files_attached { get; set; }
        // public string? rec_deleted { get; set; }
        // public string? rec_deleted_by { get; set; }
        // public DateTime rec_deleted_date { get; set; }

        public int? rec_record_id { get; set; }
        public int? rec_location_id { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_closed { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int? rec_created_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }
        
        [ForeignKey("ca_mbl_id")]
        public cargo_masterm? master { get; set; }

        [ForeignKey("ca_user_id")]
        public mast_userm? user { get; set; }

        [ForeignKey("ca_hbl_id")]
        public cargo_housem? house { get; set; }

        [ForeignKey("ca_inv_id")]
        public acc_invoicem? invoice { get; set; }

        [ForeignKey("ca_consignee_id")]
        public mast_customerm? consignee { get; set; }

        // [ForeignKey("rec_created_id")]
        // public mast_userm? created { get; set; }
    }
}

