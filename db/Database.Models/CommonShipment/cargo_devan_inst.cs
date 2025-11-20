using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Cargo;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Sourav V
//Created Date : 24/06/2025
//Remark : this file initialise data variables and their data type used in memo table

namespace Database.Models.CommonShipment
{
    public class cargo_devan_inst
    {
        [Key]
        public int di_id { get; set; }
        public int di_parent_id { get; set; }
        public string? di_parent_type { get; set; }
        public string? di_refno { get; set; }
        public int? di_request_to_id { get; set; }
        public string? di_request_to_name { get; set; }
        public string? di_request_to_add1 { get; set; }
        public string? di_request_to_add2 { get; set; }
        public string? di_request_to_add3 { get; set; }
        public string? di_request_to_add4 { get; set; }

        public int? di_cargo_loc_id { get; set; }
        public string? di_cargo_loc_name { get; set; }
        public string? di_cargo_loc_add1 { get; set; }
        public string? di_cargo_loc_add2 { get; set; }
        public string? di_cargo_loc_add3 { get; set; }
        public string? di_cargo_loc_add4 { get; set; }

        public string? di_remark1 { get; set; }
        public string? di_remark2 { get; set; }
        public string? di_remark3 { get; set; }
        public string? di_is_devan_sent { get; set; }
        public DateOnly? di_devan_date { get; set; }

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

        [ForeignKey("di_request_to_id")]
        public mast_customerm? request { get; set; }

        [ForeignKey("di_cargo_loc_id")]
        public mast_customerm? cargoloc { get; set; }
        
    }
}

