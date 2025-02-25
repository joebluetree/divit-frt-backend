// Name : Sourav V
// Created Date : 25/02/2025
// Remark : this file initializes data variables and their data type used in cntr_details table
//version : v1 - 25-02-2025

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Cargo;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database.Models.Cargo
{
    public class cargo_container
    {
        [Key]
        public int cntr_id { get; set; }
        public int cntr_hbl_id { get; set; }
        public string? cntr_catg { get; set; } // type (master/house)
        public string? cntr_no { get; set; }
        public string? cntr_type { get; set; }
        public string? cntr_sealno { get; set; }
        public string? cntr_movement { get; set; }
        public int? cntr_pieces { get; set; }
        public string? cntr_packages_uom { get; set; }
        public int? cntr_packages { get; set; }
        public decimal? cntr_teu { get; set; }
        public decimal? cntr_cbm { get; set; }
        public string? cntr_weight_uom { get; set; }
        public decimal? cntr_weight { get; set; }
        public string? cntr_rider { get; set; }
        public decimal? cntr_tare_weight { get; set; }
        public DateTime? cntr_pick_date { get; set; }
        public DateTime? cntr_return_date { get; set; }
        public DateTime? cntr_lfd { get; set; }
        public DateTime? cntr_discharge_date { get; set; }
        public int cntr_order { get; set; }
        
        [ForeignKey("cntr_hbl_id")]
        public cargo_masterm? cargom { get; set; }
      
        [ConcurrencyCheck]
        public int rec_year { get; set; }  
        public int? rec_version { get; set; }  
        public string? rec_locked { get; set; }  
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_code { get; set; }
        public int rec_branch_code { get; set; }

        [ForeignKey("rec_company_code")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_code")]
        public mast_branchm? branch { get; set; }
    }
}
