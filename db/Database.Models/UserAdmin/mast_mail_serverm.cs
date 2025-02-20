using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.BaseTables;

namespace Database.Models.UserAdmin;

public class mast_mail_serverm //: baseTable_company
{
    [Key]
    public int mail_id { get; set; }
    public string? mail_name { get; set; }
    public string? mail_smtp_name { get; set; }
    public string? mail_smtp_port { get; set; }
    public string? mail_is_ssl { get; set; }
    public string? mail_is_auth { get; set; }
    public string? mail_is_spa { get; set; }
    public int? mail_bulk_tot { get; set; }
    public int? mail_bulk_sub { get; set; }
    public string? mail_smtp_username { get; set; }
    public string? mail_smtp_pwd { get; set; }

    [ConcurrencyCheck]
    public int rec_version { get; set; }

    public string? rec_locked { get; set; }
    public string? rec_created_by { get; set; }
    public DateTime rec_created_date { get; set; }
    public string? rec_edited_by { get; set; }
    public DateTime? rec_edited_date { get; set; }
    public int rec_company_id { get; set; }

    [ForeignKey("rec_company_id")]
    public mast_companym? company { get; set; }
    
}
