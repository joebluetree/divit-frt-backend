using Microsoft.EntityFrameworkCore.ChangeTracking;
using Database.Lib.Interfaces;
using Database.Models.UserAdmin;

namespace Database.Lib.Repositories
{
    public class AuditLog : IAuditLog
    {
        private readonly AppDbContext context;
        private int comp_id = 0;
        private int branch_id = 0;
        private string user_code = "";
        private int id = 0;
        private string table = "";
        private string ref_no = "";
        private Dictionary<string, string> audit_columns = new Dictionary<string, string>();
        private Dictionary<string, string> data = new Dictionary<string, string>();
        public AuditLog(AppDbContext _context)
        {
            context = _context;
        }

        private void AddToLogTable(string _column, string _desc, string _value)
        {
            mast_auditm rec = new()
            {
                rec_company_id = comp_id,
                rec_branch_id = branch_id,
                log_table = table,
                log_user_code = user_code,
                log_table_id = id,
                log_column = _column,
                log_desc = _desc,
                log_value = _value,
                log_refno = ref_no
            };
            context.mast_auditm.Add(rec);
        }

        //LogTable<T>(string _table,int _id) where T : class
        public void LogTable<T>(string _table, Dictionary<string, string> _audit_columns, int _comp_id, int _branch_id, string _user_code, int _id, string _ref_no) where T : class
        {
            comp_id = _comp_id;
            branch_id = _branch_id;
            user_code = _user_code;
            id = _id;
            ref_no = _ref_no;
            table = _table;
            audit_columns = _audit_columns;
            ParseData(context.ChangeTracker.Entries<T>());
            ProcessData();
        }
        private void ParseData(IEnumerable<EntityEntry> _entries)
        {
            data = new Dictionary<string, string>();
            foreach (var entry in _entries)
            {
                foreach (var propertyEntry in entry.Properties)
                {
                    if (propertyEntry.IsModified)
                    {
                        if (audit_columns.ContainsKey(propertyEntry.Metadata.Name))
                        {
                            data.Add(propertyEntry.Metadata.Name, propertyEntry.OriginalValue?.ToString() ?? "");
                        }
                    }
                }
            }
        }
        private void ProcessData()
        {
            foreach (var rec in data)
            {
                AddToLogTable(rec.Key, audit_columns[rec.Key], rec.Value);
            }
        }

    }


}
