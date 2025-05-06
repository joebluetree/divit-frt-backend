using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Cargo;
using Database.Models.UserAdmin;

//Name : Alen Cherian
//Date : 09/04/2025
//Command :  Create Model for the Follow Up.
//version 1.0

namespace Database.Models.CommonShipment
{
    public class cargo_followup
    {
        [Key]
        public int cf_id { get; set; }
        public int cf_mbl_id { get; set; }
        public int? cf_user_id { get; set; }
        public string? cf_mode { get; set; }
        public string? cf_remarks { get; set; }
        public DateTime? cf_followup_date { get; set; }
        public int? cf_assigned_id { get; set; }


        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }


        [ForeignKey("cf_mbl_id")]
        public cargo_masterm? master { get; set; }

        [ForeignKey("cf_user_id")]
        public mast_userm? user { get; set; }
        
        [ForeignKey("cf_assigned_id")]
        public mast_userm? assigned { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }
    }

}