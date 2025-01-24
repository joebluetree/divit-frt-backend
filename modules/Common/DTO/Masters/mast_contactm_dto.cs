using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using Database.Models.Masters;
using System.ComponentModel.DataAnnotations;


namespace Common.DTO.Masters
{
    public class mast_contactm_dto : basetable_dto
    {
        public int cont_id { get; set; }
        public int cont_parent_id { get; set; }
        public string? cont_title { get; set; }
        public string? cont_name { get; set; }
        public int? cont_group_id { get; set; }
        public string? cont_group_name { get; set; }
        public string? cont_designation { get; set; }
        public string? cont_email { get; set; }
        public string? cont_tel { get; set; }
        public string? cont_mobile { get; set; }
        public string? cont_remarks { get; set; }
        public int cont_country_id { get; set; }
        public string? cont_country_code { get; set; }
        public string? cont_country_name { get; set; }

    }
}
