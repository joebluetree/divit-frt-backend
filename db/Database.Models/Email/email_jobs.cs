// Name : Sourav V
// Created Date : 12/05/2026
// Remark : email_jobs dto

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database.Models.Email
{
    public class email_jobs
    {
        [Key]
        public int email_id { get; set; }
        public string? email_from_id { get; set; }
        public string? email_to_id { get; set; }
        public string? email_cc_id { get; set; }
        public string? email_bcc_id { get; set; }
        public string? email_subject { get; set; }
        public string? email_message { get; set; }
        public string? email_file_folder { get; set; }
        public int? email_ctr { get; set; }
        
        public DateTime? email_scheduled_on { get; set; }
        public DateTime? email_send_date { get; set; }
        public string? email_status { get; set; }
        public string? email_error_msg { get; set; }
        public string? email_remarks { get; set; }

        public int rec_version { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }
    }
}
