﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database.Models.UserAdmin
{
    public class mast_settings
    {
        [Key]
        public int id { get; set; }
        public string? category { get; set; }
        public string? caption { get; set; }
        public string? remarks { get; set; }
        public string? type { get; set; }
        public string? table { get; set; }
        public string? value { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? json { get; set; }
        public int? param_id { get; set; }
        public int order { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        // public string? rec_locked { get; set; }
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

