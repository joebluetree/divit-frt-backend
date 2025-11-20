using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database.Models.UserAdmin
{
    public class mast_yearm
    {
        [Key]
        public int year_id { get; set; }
        public int year_code { get; set; }
        public string? year_name { get; set; }
        public DateOnly? year_start_date { get; set; }
        public DateOnly? year_end_date { get; set; }
        public string? year_closed { get; set; }
        public string? year_default { get; set; }

        [ConcurrencyCheck]
        // public int rec_version { get; set; }
        // public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }
                
    }

}
