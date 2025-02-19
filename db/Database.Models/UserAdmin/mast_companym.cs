using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Database.Models.UserAdmin
{
    public class mast_companym 
    {
        [Key]
        public int comp_id { get; set; }
        public string? comp_code { get; set; }
        public string? comp_name { get; set; }
        public string? comp_address1 { get; set; }
        public string? comp_address2 { get; set; }
        public string? comp_address3 { get; set; }
        /*
        public string rec_locked { get; set; }
        public string rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }
        */
        public List<mast_branchm>? branches { get; set; }
                
        [ConcurrencyCheck]
        public int rec_version { get; set; }
        public string? rec_locked { get; set; }
        public string? rec_created_by { get; set; }
        public DateTime rec_created_date { get; set; }
        public string? rec_edited_by { get; set; }
        public DateTime? rec_edited_date { get; set; }

    }

}