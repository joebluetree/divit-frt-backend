using System;
using Database.Models.BaseTables;

namespace Common.DTO.UserAdmin;

public class mast_fileupload_dto: basetable_dto
{
        public int files_id { get; set; }
        public int? files_parent_id { get; set; }
        public string? files_parent_type { get; set; }
        public int? files_slno { get; set; }
        public string? files_type { get; set; }
        public string? files_desc { get; set; }
        public string? files_ref_no { get; set; }
        public string? files_path { get; set; }
        public int? files_sub_id { get; set; }
        public string? files_size { get; set; }
        public string? files_processed { get; set; }
        public List<mast_fileupload_dto>? fileupload { get; set; }

}
