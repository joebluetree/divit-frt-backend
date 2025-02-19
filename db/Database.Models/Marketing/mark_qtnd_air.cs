using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Database.Models.Masters;


//Name : Sourav V
//Created Date : 10/01/2025
//Remark : this file initialise data variables and their data type used in mark_qtnd-air table

namespace Database.Models.Marketing
{
    public class mark_qtnd_air 
    {
        [Key]
        public int qtnd_id { get; set; } //pk
        public int qtnd_qtnm_id { get; set; } // parent id (fk)
        public int? qtnd_pol_id { get; set; }
        public string? qtnd_pol_name { get; set; }
        public int? qtnd_pod_id { get; set; }
        public string? qtnd_pod_name { get; set; }
        public int? qtnd_carrier_id { get; set; }
        public string? qtnd_carrier_name { get; set; }
        public string? qtnd_trans_time { get; set; }
        public string? qtnd_routing { get; set; }
        public string? qtnd_etd { get; set; }
        public string? qtnd_min { get; set; }
        public string? qtnd_45k { get; set; }
        public string? qtnd_100k { get; set; }
        public string? qtnd_300k { get; set; }
        public string? qtnd_500k { get; set; }
        public string? qtnd_1000k { get; set; }
        public string? qtnd_fsc { get; set; }
        public string? qtnd_war { get; set; }
        public string? qtnd_sfc { get; set; }
        public string? qtnd_hac { get; set; }
        public int qtnd_order { get; set; }
        
        [ForeignKey("qtnd_qtnm_id")]
        public mark_qtnm? qtnm { get; set; }
        
        [ForeignKey("qtnd_pol_id")]
        public mast_param? pol { get; set; }
        
        [ForeignKey("qtnd_pod_id")]
        public mast_param? pod { get; set; }
        
        [ForeignKey("qtnd_carrier_id")]
        public mast_param? carrier { get; set; }
        
            
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
