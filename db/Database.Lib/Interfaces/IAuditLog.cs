using Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Reflection;

namespace Database.Lib.Interfaces
{
    public interface IAuditLog
    {
        public void LogTable<T>(string _table, Dictionary<string, string> _audit_columns, int _comp_id, int _branch_id, string _user_code, int _id, string _ref_no) where T : class;

    }


}
