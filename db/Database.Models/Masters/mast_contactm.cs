using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database.Models.Masters
{
    public class mast_contactm //: baseTable_company
    {
        [Key]
        public int cont_id { get; set; }
        public int cont_parent_id { get; set; }
        public string? cont_title { get; set; }
        public string? cont_name { get; set; }
        public int? cont_group_id { get; set; }
        public string? cont_designation { get; set; }
        public string? cont_email { get; set; }
        public string? cont_tel { get; set; }
        public string? cont_mobile { get; set; }
        public string? cont_remarks { get; set; }
        public int cont_country_id { get; set; }

        [ForeignKey("cont_group_id")]
        public mast_param? contgroup { get; set; }
        
        [ForeignKey("cont_parent_id")]
        public mast_customerm? customer { get; set; }
        
        [ForeignKey("cont_country_id")]
        public mast_param? country { get; set; }
        
        
        [ConcurrencyCheck]
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        public int rec_company_id { get; set; }

        [ForeignKey("rec_company_id")]
        public mast_companym? company { get; set; }


    }
}

