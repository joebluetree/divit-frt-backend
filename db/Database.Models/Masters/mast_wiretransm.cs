using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.BaseTables;
using Database.Models.UserAdmin;

namespace Database.Models.Masters;

public class mast_wiretransm //: baseTable
{
    [Key]
    public int wtim_id { get; set; } //pk
    public int wtim_slno { get; set; }
    public string? wtim_refno { get; set; }
    public string? wtim_to_name { get; set; }
    public int wtim_cust_id { get; set; } //fk
    public string? wtim_cust_name { get; set; }
    public string? wtim_cust_fax { get; set; }
    public string? wtim_cust_tel { get; set; }
    public string? wtim_acc_no { get; set; }
    public string? wtim_req_type { get; set; }
    public string? wtim_from_name { get; set; }
    public DateTime? wtim_date { get; set; }
    public string? wtim_sender_ref { get; set; }
    public string? wtim_your_ref { get; set; }
    public string? wtim_is_urgent { get; set; }
    public string? wtim_is_review { get; set; }
    public string? wtim_is_comment { get; set; }
    public string? wtim_is_reply { get; set; }
    public string? wtim_is_recycle { get; set; }
    public string? wtim_remarks { get; set; }
    
    [ForeignKey("wtim_cust_id")]
    public mast_customerm? customer { get; set; } 
    public List <mast_wiretransd>? wtim_details { get; set; } 


    [ConcurrencyCheck]
    public int rec_version { get; set; }
    public string? rec_locked { get; set; }
    public string? rec_created_by { get; set; }
    public DateTime rec_created_date { get; set; }
    public string? rec_edited_by { get; set; }
    public DateTime? rec_edited_date { get; set; }
    public int rec_company_id { get; set; }
    public int? rec_branch_id { get; set; }

    [ForeignKey("rec_company_id")]
    public mast_companym? company { get; set; }
    [ForeignKey("rec_branch_id")]
    public mast_branchm? branch { get; set; }

}
