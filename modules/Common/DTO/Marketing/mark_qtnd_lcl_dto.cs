using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;


namespace Common.DTO.Marketing
{
    public class mark_qtnd_lcl_dto : basetable_dto
    {
        public int qtnd_id { get; set; } = 0;
        public int qtnd_qtnm_id { get; set; } = 0;
        public int qtnd_acc_id { get; set; } = 0;
        public string? qtnd_acc_code { get; set; } = "";
        public string? qtnd_acc_name { get; set; } = "";
        public decimal? qtnd_amt { get; set; } = 0;
        public string? qtnd_per { get; set; } = "";
        public int? qtnd_order { get; set; } = 0;
                        
    }
}
