using Database.Models.BaseTables;
using System.ComponentModel.DataAnnotations;


namespace Common.DTO.Masters
{
    public class mast_param_dto : basetable_dto
    {
        public int param_id { get; set; } = 0;
        public string? param_type { get; set; } = "";
        public string? param_code { get; set; } = "";
        public string? param_name { get; set; } = "";
        public string? param_value1 { get; set; } = "";
        public string? param_value2 { get; set; } = "";
        public string? param_value3 { get; set; } = "";
        public string? param_value4 { get; set; } = "";
        public string? param_value5 { get; set; } = "";
        public int param_order { get; set; }
    }
}
