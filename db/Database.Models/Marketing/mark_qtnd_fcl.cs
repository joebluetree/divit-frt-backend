using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Database.Models.Masters;

namespace Database.Models.Marketing
{

    //Name : Alen Cherian
    //Date : 03/01/2025
    //Command :  Database Table for the Quotation Fcl.

    public class mark_qtnd_fcl 
    {
        [Key]
        public int? qtnd_id { get; set; } //pk
        public int? qtnd_qtnm_id { get; set; } //fk
        public int? qtnd_pol_id { get; set; }
        public string? qtnd_pol_name { get; set; }
        public int? qtnd_pod_id { get; set; }
        public string? qtnd_pod_name { get; set; }
        public int? qtnd_carrier_id { get; set; }
        public string? qtnd_carrier_name { get; set; }
        public string? qtnd_trans_time { get; set; }
        public string? qtnd_routing { get; set; }
        public string? qtnd_cntr_type { get; set; }
        public string? qtnd_etd { get; set; }
        public string? qtnd_cutoff { get; set; }
        public decimal? qtnd_of { get; set; }
        public decimal? qtnd_pss { get; set; }
        public decimal? qtnd_baf { get; set; }
        public decimal? qtnd_isps { get; set; }
        public decimal? qtnd_haulage { get; set; }
        public decimal? qtnd_ifs { get; set; }
        public decimal? qtnd_tot_amt { get; set; }
        public int? qtnd_order { get; set; }
        
        [ForeignKey("qtnd_pol_id")]
        public mast_param? pol { get; set; }
        
        [ForeignKey("qtnd_pod_id")]
        public mast_param? pod { get; set; }
        
        [ForeignKey("qtnd_carrier_id")]
        public mast_param? carrier { get; set; }

        [ForeignKey("qtnd_qtnm_id")]
        public mark_qtnm? qtnm { get; set; }

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

