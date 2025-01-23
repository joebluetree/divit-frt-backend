using System;
using Database.Models.BaseTables;

namespace Common.DTO.Masters;

public class mast_wiretransm_dto : basetable_dto
{
    public int wtim_id { get; set; } //pk
    public int wtim_slno { get; set; }
    public string? wtim_refno { get; set; }
    public string? wtim_to_name { get; set; }
    public int wtim_comp_id { get; set; } //fk
    public string? wtim_comp_code { get; set; } 
    public string? wtim_comp_name { get; set; }
    public string? wtim_comp_fax { get; set; }
    public string? wtim_comp_tel { get; set; }
    public string? wtim_acc_no { get; set; }
    public string? wtim_req_type { get; set; }
    public string? wtim_from_name { get; set; }
    public string? wtim_date { get; set; }
    public string? wtim_sender_ref { get; set; }
    public string? wtim_your_ref { get; set; }
    public string? wtim_is_urgent { get; set; }
    public string? wtim_is_review { get; set; }
    public string? wtim_is_comment { get; set; }
    public string? wtim_is_reply { get; set; }
    public string? wtim_is_recycle { get; set; }
    public string? wtim_remarks { get; set; }
    public List <mast_wiretransd_dto>? wtim_details { get; set; } 
}
