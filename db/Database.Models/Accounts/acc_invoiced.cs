using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Masters;
using Database.Models.UserAdmin;

namespace Database.Models.Accounts
{
    public class acc_invoiced
    {
        [Key]
        public int invd_id { get; set; }
        public int invd_parent_id { get; set; }
        public int? invd_acc_id { get; set; }
        public string? invd_acc_name { get; set; }
        public string? invd_remarks { get; set; }
        public decimal? invd_qty { get; set; }
        public decimal? invd_frate { get; set; }
        public decimal? invd_ftotal { get; set; }
        public int? invd_cur_id { get; set; }
        public decimal? invd_exrate { get; set; }
        public decimal? invd_rate { get; set; }
        public decimal? invd_total { get; set; }
        public string? rec_deleted { get; set; }
        public int? invd_order { get; set; }

        [ForeignKey("invd_parent_id")]
        public acc_invoicem? invoice { get; set; }

        [ForeignKey("invd_acc_id")]
        public acc_acctm? account { get; set; }

        [ForeignKey("invd_cur_id")]
        public mast_param? currency { get; set; }

        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_branch_id { get; set; }
        public int rec_company_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }

        [ForeignKey("rec_branch_id")]
        public mast_branchm? branch { get; set; }
    }
}
