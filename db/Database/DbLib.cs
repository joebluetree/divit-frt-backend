using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public static class DbLib
    {
        public static string DBMS = "PGS";
        public static DateTime GetDateTime()
        {
            if (DBMS == "SQL")
                return DateTime.Now;
            else if (DBMS == "PGS")
                return DateTime.UtcNow;
            else
                return DateTime.Now;
        }

    }
}
