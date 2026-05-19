// Name : Sourav V
// Created Date : 18/05/2026
// Remark : email_list dto

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database.Models.Email
{
    public class email_list
    {
        [Key]
        public int email_id { get; set; }
        public string? email_type { get; set; }
        public string? email_from_id { get; set; }
        public string? email_to_id { get; set; }
        public string? email_cc_id { get; set; }
        public string? email_bcc_id { get; set; }
        public string? email_subject { get; set; }
        public string? email_message { get; set; }

        public string? rec_created_by { get; set; }
        public DateTime? rec_created_date { get; set; }
        public int rec_company_id { get; set; }
        public int rec_branch_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }
    }
}
