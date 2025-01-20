using System;
using Database.Models.BaseTables;

namespace Common.DTO.Masters;

public class mast_mail_serverm_dto: basetable_dto
{
    public int mail_id { get; set; } = 0;
    public string? mail_name { get; set; } = "";
    public string? mail_smtp_name { get; set; } = "";
    public string? mail_smtp_port { get; set; } = "";
    public string? mail_is_ssl { get; set; } = "";
    public string? mail_is_auth { get; set; } = "";
    public string? mail_is_spa { get; set; } = "";
    public int? mail_bulk_tot { get; set; } = 0;
    public int? mail_bulk_sub { get; set; } = 0;
    public string? mail_smtp_username { get; set; } = "";
    public string? mail_smtp_pwd { get; set; } = "";


}
