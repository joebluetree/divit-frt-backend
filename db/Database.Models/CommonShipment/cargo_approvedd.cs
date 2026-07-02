using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Accounts;
using Database.Models.Cargo;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Sourav V
//Created Date : 09/06/2026
//Remark : this file initialise data variables and their data type used in approvedd table

namespace Database.Models.CommonShipment
{
    public class cargo_approvedd
    {
        [Key]
        public int cad_id { get; set; }
        public int? cad_parent_id { get; set; }
        public int? cad_approvedby_id { get; set; }
        public string? cad_is_approved { get; set; }
        public DateTime? cad_approved_date { get; set; }
        public string? cad_is_hide { get; set; }

        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }
        
        [ForeignKey("cad_parent_id")]
        public cargo_approvedm? approvedm { get; set; }
        
        [ForeignKey("cad_approvedby_id")]
        public mast_userm? approvedby { get; set; }
    }
}

