using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Cargo;
using Database.Models.Masters;

namespace Database.Models.UserAdmin
{

    public class mast_fileupload
    {
        [Key]
        public int files_id { get; set; }
        public int? files_parent_id { get; set; }
        public string? files_parent_type { get; set; }
        public int? files_slno { get; set; }
        public string? files_type { get; set; }
        public string? files_desc { get; set; }
        public string? files_ref_no { get; set; }
        public string? files_path { get; set; }
        public int? files_sub_id { get; set; }
        public string? files_size { get; set; }
        public string? files_processed { get; set; }
        public string? files_status { get; set; }
        public string? rec_deleted_by { get; set; }
        public DateTime? rec_deleted_date { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }

        [ForeignKey("files_parent_id")]
        public cargo_masterm? parent { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }
        
        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }

    }
}
