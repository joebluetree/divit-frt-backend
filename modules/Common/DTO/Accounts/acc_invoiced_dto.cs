using Database.Models.BaseTables;

namespace Common.DTO.Accounts
{
    public class acc_invoiced_dto : basetable_dto
    {
        public int invd_id { get; set; }
        public int invd_parent_id { get; set; }

        public int? invd_acc_id { get; set; }
        public string? invd_acc_code { get; set; }
        public string? invd_acc_name { get; set; }
        public string? invd_remarks { get; set; }

        public decimal? invd_qty { get; set; }
        public decimal? invd_frate { get; set; }
        public decimal? invd_ftotal { get; set; }
        public int? invd_cur_id { get; set; }
        public string? invd_cur_code { get; set; }
        public decimal? invd_exrate { get; set; }
        public decimal? invd_rate { get; set; }
        public decimal? invd_total { get; set; }
        public int? invd_order { get; set; }
    }
}
