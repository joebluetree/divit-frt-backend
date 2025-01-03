using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;


namespace Common.DTO.Marketing
{
    public class mark_qtnd_lcl_dto : basetable_dto
    {
        public int qtnd_pkid { get; set; } = 0;
        public int qtnd_qtnm_pkid { get; set; } = 0;
        public int qtnd_acc_id { get; set; } = 0;
        public string? qtnd_acc_name { get; set; } = "";
        public decimal? qtnd_amt { get; set; } = 0;
        public string? qtnd_per { get; set; } = "";
                        
    }
}
