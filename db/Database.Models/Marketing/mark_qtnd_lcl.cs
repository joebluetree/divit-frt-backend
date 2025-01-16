using Database.Models.Accounts;
using Database.Models.BaseTables;
using Database.Models.Masters;
using Database.Models.UserAdmin;

//Name : Sourav V
//Created Date : 03/01/2025
//Remark : this file initialise data variables and their data type used in mark_qtnd-lcl table

namespace Database.Models.Marketing
{
    public class mark_qtnd_lcl : baseTable
    {
        public int qtnd_id { get; set; } //pk
        public int qtnd_qtnm_id { get; set; } // fk
        public int qtnd_acc_id { get; set; }
        public string? qtnd_acc_name { get; set; }
        public decimal? qtnd_amt { get; set; }        
        public string? qtnd_per { get; set; }        
        public int qtnd_order { get; set; }
        public mark_qtnm? qtnm { get; set; }
        public acc_acctm? acctm { get; set; }
    }
}
