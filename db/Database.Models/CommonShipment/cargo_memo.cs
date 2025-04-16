using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Cargo;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Sourav V
//Created Date : 09/04/2025
//Remark : this file initialise data variables and their data type used in memo table

namespace Database.Models.CommonShipment
{
    public class cargo_memo
    {
        [Key]
        public int memo_id { get; set; }
        public int memo_parent_id { get; set; }
        public string? memo_parent_type { get; set; }
        public int? memo_remarks_id { get; set; }
        public string? memo_remarks_name { get; set; }
        public DateTime? memo_date { get; set; }
        public string? memo_memo { get; set; }
        public string? rec_files_attached { get; set; }

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
        
        [ForeignKey("memo_remarks_id")]
        public mast_param? remarks { get; set; }
        
        // [ForeignKey("memo_parent_id")]
        // public cargo_housem? parentHouse { get; set; }
        // public cargo_masterm? parentMaster { get; set; }
    }
}

