using Database.Models.Accounts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
//Name : Sourav V
//Created Date : 03/01/2025
//Remark : this file initialise data variables and their data type used in mark_qtnd-lcl table

namespace Database.Models.Marketing
{
    public class mark_qtnd_lcl 
    {
        [Key]
        public int qtnd_id { get; set; } //pk
        public int qtnd_qtnm_id { get; set; } // fk
        public int qtnd_acc_id { get; set; }
        public string? qtnd_acc_name { get; set; }
        public decimal? qtnd_amt { get; set; }        
        public string? qtnd_per { get; set; }        
        public int qtnd_order { get; set; }

        [ForeignKey("qtnd_qtnm_id")]
        public mark_qtnm? qtnm { get; set; }

        [ForeignKey("qtnd_acc_id")]
        public acc_acctm? acctm { get; set; }

        
        [ConcurrencyCheck]
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


    }
}
