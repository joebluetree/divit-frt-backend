using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Cargo;
using Database.Models.Masters;
using Database.Models.UserAdmin;

namespace Database.Models.Cargo
{
    public class cargo_desc
    {
        [Key]
        public int desc_id { get; set; }
        public int desc_parent_id { get; set; }
        public string? desc_parent_type { get; set; }
        public int? desc_ctr { get; set; }
        public string? desc_mark { get; set; }
        public string? desc_package { get; set; }
        public string? desc_description { get; set; }
        
        [ForeignKey("desc_parent_id")]
        public cargo_housem? parentHouse { get; set; }

        [ConcurrencyCheck]
        public int rec_version {get;set;}
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
    }
}