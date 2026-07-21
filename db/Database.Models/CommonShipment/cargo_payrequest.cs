using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Accounts;
using Database.Models.Cargo;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Sourav V
//Created Date : 07/07/2026
//Remark : this file initialise data variables and their data type used in payment Request table

namespace Database.Models.CommonShipment
{
    public class cargo_payrequest
    {
        [Key]
        public int cp_id { get; set; }
        public int cp_slno { get; set; }
        public string? cp_mode { get; set; }
        public string? cp_source { get; set; }
        public int? cp_master_id { get; set; }
        public string? cp_paytype_needed { get; set; }
        public string? cp_spl_notes { get; set; }
        public DateOnly? cp_payment_date { get; set; }
        public string? cp_pay_status { get; set; }
        public int? cp_cust_id { get; set; }
        public int? cp_inv_id { get; set; }
        public string? cp_inv_no { get; set; }

        public string? rec_deleted { get; set; }
        public string? rec_deleted_by { get; set; }
        public DateOnly? rec_deleted_date { get; set; }
        [ConcurrencyCheck]
        public int rec_version { get; set; } 
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
        
        [ForeignKey("cp_master_id")]
        public cargo_masterm? master { get; set; }
        
        [ForeignKey("cp_cust_id")]
        public mast_customerm? customer { get; set; }
        
        [ForeignKey("cp_inv_id")]
        public acc_invoicem? invoice { get; set; }
    }
}

