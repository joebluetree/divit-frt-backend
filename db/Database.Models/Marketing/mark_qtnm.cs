using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Database.Models.BaseTables;
using Database.Models.Masters;

//Name : Sourav V
//Created Date : 03/01/2025
//Remark : this file initialise data variables and their data type used in parent table(mark_qtnm)

namespace Database.Models.Marketing
{
    public class mark_qtnm
    {
        [Key]
        public int qtnm_id { get; set; }
        public int qtnm_cfno { get; set; }
        public string? qtnm_type { get; set; }
        public string? qtnm_no { get; set; }
        public int qtnm_to_id { get; set; }
        public string? qtnm_to_name { get; set; }
        public string? qtnm_to_addr1 { get; set;}
        public string? qtnm_to_addr2 { get; set; }
        public string? qtnm_to_addr3 { get; set; }
        public string? qtnm_to_addr4 { get; set; }
        public DateOnly? qtnm_date { get; set; }
        public string? qtnm_quot_by { get; set; }
        public DateOnly? qtnm_valid_date { get; set; }
        public int? qtnm_salesman_id { get; set; }
        public string? qtnm_move_type { get; set; }
        public string? qtnm_commodity { get; set; }

        public string? qtnm_package { get; set; }
        public decimal? qtnm_kgs { get; set; }
        public decimal? qtnm_lbs { get; set; }
        public decimal? qtnm_cbm { get; set; }
        public decimal? qtnm_cft { get; set; }
        public int? qtnm_por_id { get; set; }
        public string? qtnm_por_name { get; set; }
        public int? qtnm_pol_id { get; set; }
        public string? qtnm_pol_name { get; set; }
        public int? qtnm_pod_id { get; set; }
        public string? qtnm_pod_name { get; set; }
        public string? qtnm_pld_name { get; set; }
        public string? qtnm_plfd_name { get; set; }
        public string? qtnm_trans_time { get; set; }
        public string? qtnm_routing { get; set; }
        public decimal? qtnm_amt { get; set; }
        public int? qtnm_cur_id { get; set; }
        public decimal? qtnm_exrate { get; set; }
        public string? rec_files_attached { get; set; }
        public int? rec_files_count { get; set; }        


        [ForeignKey("qtnm_to_id")]
        public mast_customerm? customer { get; set; } 
        
        [ForeignKey("qtnm_salesman_id")]
        public mast_param? salesman { get; set; }

        [ForeignKey("qtnm_por_id")]
        public mast_param? por { get; set; }
        
        [ForeignKey("qtnm_pol_id")]
        public mast_param? pol { get; set; }

        [ForeignKey("qtnm_pod_id")]
        public mast_param? pod { get; set; }

        [ForeignKey("qtnm_cur_id")]
        public mast_param? currency { get; set; }

        
        public List<mark_qtnd_lcl>? qtnd_lcl { get; set; } 

        public List <mark_qtnd_fcl>? qtnd_fcl { get; set; } 

        public List <mark_qtnd_air>? qtnd_air { get; set; } 
        
        [ConcurrencyCheck]
        public int rec_version { get; set; }
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

        
    }
}
