using Database.Models.BaseTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Tnt
{
    public class tnt_trackd_dto : basetable_dto
    {
        public int trackd_id { get; set; }
        public int trackd_track_id { get; set; }
        public DateTime? trackd_last_updated_on { get; set; }


    }
}
