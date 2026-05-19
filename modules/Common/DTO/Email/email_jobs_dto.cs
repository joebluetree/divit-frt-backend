using Common.UserAdmin.DTO;
using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

//Name : Sourav V
//Created Date : 12/05/2026
//Remark : this file defines data objects(variables) which transfer data from frontend to backend and vice-versa

namespace Common.DTO.Email
{
    public class email_jobs_dto : basetable_dto
    {
        public int email_id { get; set; } = 0;
        public string? email_from_id { get; set; } = "";
        public string? email_to_id { get; set; } = "";
        public string? email_cc_id { get; set; } = "";
        public string? email_bcc_id { get; set; } = "";
        public string? email_subject { get; set; } = "";
        public string? email_message { get; set; } = "";
        public string? email_file_folder { get; set; } = "";
        public int? email_ctr { get; set; } = 0;

        public string? email_scheduled_on { get; set; } = "";
        public string? email_send_date { get; set; } = "";
        public string? email_status { get; set; } = "";
        public string? email_error_msg { get; set; } = "";
        public string? email_remarks { get; set; } = "";
    }
}
/*
A-B-C-D-E-F-G-H-I-J-K-L-M-N-O-P-Q-R-S-T-U-V-W-X-Y-Z-
*/