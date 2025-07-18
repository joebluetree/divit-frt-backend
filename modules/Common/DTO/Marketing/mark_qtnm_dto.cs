using Common.DTO.UserAdmin;
using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using Database.Models.Marketing;
using System.ComponentModel.DataAnnotations;


//Name : Sourav V
//Created Date : 03/01/2025
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Marketing
{

    public class mark_qtnm_dto : basetable_dto
    {
        public int qtnm_id { get; set; } = 0;
        public int qtnm_cfno { get; set; } = 0;
        public string? qtnm_type { get; set; } = "";
        public string? qtnm_no { get; set; } = "";
        public int qtnm_to_id { get; set; } = 0;

        public string? qtnm_to_name { get; set; } = "";
        public string? qtnm_to_code { get; set;}= "";

        public string? qtnm_to_addr1 { get; set;} = "";
        public string? qtnm_to_addr2 { get; set; } = "";
        public string? qtnm_to_addr3 { get; set; } = "";
        public string? qtnm_to_addr4 { get; set; } = "";
        public string? qtnm_date { get; set; } = "";

        public string? qtnm_from_date { get; set; } = "";
        public string? qtnm_to_date { get; set; } = "";

        public string? qtnm_quot_by { get; set; } = "";
        public string? qtnm_valid_date { get; set; } = "";
        public int? qtnm_salesman_id { get; set; } = 0;
        public string? qtnm_salesman_name { get; set; } = ""; 
        public string? qtnm_move_type { get; set; } = "";
        public string? qtnm_commodity { get; set; } = "";

        public string? qtnm_package { get; set; } = "";
        public decimal? qtnm_kgs { get; set; } = 0;
        public decimal? qtnm_lbs { get; set; } = 0;
        public decimal? qtnm_cbm { get; set; } = 0;
        public decimal? qtnm_cft { get; set; } = 0;
        public int? qtnm_por_id { get; set; } = 0;
        public string? qtnm_por_code { get; set;}= "";
        public string? qtnm_por_name { get; set; } = "";
        public int? qtnm_pol_id { get; set; } = 0;
        public string? qtnm_pol_code { get; set;}= "";
        public string? qtnm_pol_name { get; set; } = "";
        public int? qtnm_pod_id { get; set; } = 0;
        public string? qtnm_pod_code { get; set;}= "";
        public string? qtnm_pod_name { get; set; } = "";
        public string? qtnm_pld_name { get; set; } = "";
        public string? qtnm_plfd_name { get; set; } = "";
        public string? qtnm_trans_time { get; set; } = "";
        public string? qtnm_routing { get; set; } = "";
        public decimal? qtnm_amt { get; set; } = 0;   

        public int? rec_files_count { get; set; }
        public string? rec_files_attached { get; set; }
        public List<mark_qtnd_fcl_dto>? qtnd_fcl {get; set;}             
        public List<gen_remarkm_dto>? remk_remarks {get; set;}

        public List<mark_qtnd_lcl_dto>? qtnd_lcl {get; set;} 
        public List<mark_qtnd_air_dto>? qtnd_air {get; set;} 
                        

    }
}

