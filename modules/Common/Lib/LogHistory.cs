using Microsoft.EntityFrameworkCore;
using Database.Models.UserAdmin;


namespace Common.Lib
{
    public class LogHistory<T> where T : class
    {
        private readonly DbContext _context;
        private string _table_name = "";
        private string pkey = "";
        private int _version = 0;

        private DateTime _log_date;
        private readonly Dictionary<string, string> _columnsToTrack;
        private readonly List<T> _oldEntities;
        private readonly List<T> _newEntities;

        private int _id { get; set; } = 0;
        private int _company_id { get; set; } = 0;
        private int _branch_id { get; set; } = 0;
        private string _user_code { get; set; } = "";
        private int _order = 0;
        public LogHistory(DbContext context)
        {
            _context = context;
            pkey = "";
            _columnsToTrack = new Dictionary<string, string>();
            _oldEntities = new List<T>();
            _newEntities = new List<T>();
        }

        public LogHistory<T> PrimaryKey(string key, int value)
        {
            _id = value;
            pkey = key;
            return this;
        }
        public LogHistory<T> Table(string table_name, DateTime log_date)
        {
            _table_name = table_name;
            _log_date = log_date;
            return this;
        }


        public LogHistory<T> SetCompanyInfo(int version, int company_id, int branch_id, string user_code)
        {
            _version = version;
            _company_id = company_id;
            _branch_id = branch_id;
            _user_code = user_code;
            return this;
        }

        public LogHistory<T> TrackColumn(string column, string description)
        {
            _columnsToTrack[column] = description;
            return this;
        }

        public LogHistory<T> TrackColumns(Dictionary<string, string> columns)
        {
            foreach (var column in columns)
            {
                _columnsToTrack[column.Key] = column.Value;
            }
            return this;
        }

        public LogHistory<T> SetRecords(IEnumerable<T> oldEntities, IEnumerable<T> newEntities)
        {
            _oldEntities.AddRange(oldEntities);
            _newEntities.AddRange(newEntities);
            return this;
        }

        public LogHistory<T> SetRecord(T oldEntities, T newEntities)
        {
            _oldEntities.Add(oldEntities);
            _newEntities.Add(newEntities);
            return this;
        }

        public async Task<LogHistory<T>> LogChangesAsync()
        {


            try
            {

                var historyLogs = new List<mast_history>();
                var oldEntitiesDict = _oldEntities.ToDictionary(e => GetPrimaryKeyValue());
                var newEntitiesDict = _newEntities.ToDictionary(e => GetPrimaryKeyValue());

                // Check for modified and deleted records
                foreach (var oldEntity in _oldEntities)
                {
                    var key = GetPrimaryKeyValue();
                    if (newEntitiesDict.TryGetValue(key, out var newEntity))
                    {
                        foreach (var column in _columnsToTrack.Keys)
                        {
                            var oldValue = oldEntity.GetType().GetProperty(column)?.GetValue(oldEntity)?.ToString();
                            var newValue = newEntity.GetType().GetProperty(column)?.GetValue(newEntity)?.ToString();
                            if (oldValue != newValue)
                            {
                                historyLogs.Add(new mast_history
                                {
                                    log_table = _table_name,
                                    log_table_row_id = _id,
                                    rec_company_id = _company_id,
                                    rec_branch_id = _branch_id == 0 ? null : _branch_id,
                                    log_user_code = _user_code,

                                    log_refno = "",
                                    log_column = column,
                                    log_desc = _columnsToTrack[column],
                                    log_old_value = oldValue,
                                    log_new_value = newValue,
                                    log_status = "Edited",
                                    log_date = _log_date,
                                    rec_version = _version,
                                    rec_order = ++_order,
                                });
                            }
                        }
                    }
                    else
                    {
                        // Deleted record
                        foreach (var column in _columnsToTrack.Keys)
                        {
                            var oldValue = oldEntity.GetType().GetProperty(column)?.GetValue(oldEntity)?.ToString();
                            historyLogs.Add(new mast_history
                            {
                                log_table = _table_name,
                                log_table_row_id = _id,
                                rec_company_id = _company_id,
                                rec_branch_id = _branch_id == 0 ? null : _branch_id,
                                log_user_code = _user_code,
                                log_refno = "",
                                log_column = column,
                                log_desc = _columnsToTrack[column],
                                log_old_value = oldValue,
                                log_new_value = "",
                                log_status = "Deleted",
                                log_date = _log_date,
                                rec_version = _version,
                                rec_order = ++_order,
                            });
                        }
                    }
                }

                // Check for new records
                foreach (var newEntity in _newEntities)
                {
                    var key = GetPrimaryKeyValue();
                    if (!oldEntitiesDict.ContainsKey(key))
                    {
                        foreach (var column in _columnsToTrack.Keys)
                        {
                            var newValue = newEntity.GetType().GetProperty(column)?.GetValue(newEntity)?.ToString();
                            historyLogs.Add(new mast_history
                            {
                                log_table = _table_name,
                                log_table_row_id = _id,
                                rec_company_id = _company_id,
                                rec_branch_id = _branch_id == 0 ? null : _branch_id,
                                log_user_code = _user_code,
                                log_refno = "",
                                log_column = column,
                                log_desc = _columnsToTrack[column],
                                log_old_value = "",
                                log_new_value = newValue,
                                log_status = "New",
                                log_date = _log_date,
                                rec_version = _version,
                                rec_order = ++_order,
                            });
                        }
                    }
                }

                await _context.Set<mast_history>().AddRangeAsync(historyLogs);
                Console.WriteLine(historyLogs);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }

            return this;

        }



        private string GetPrimaryKeyValue()
        {
            return pkey;
        }

        /*
        private string _GetPrimaryKeyValue(T entity)
        {
            return string.Join("-", _keyColumns.Select(key => entity.GetType().GetProperty(key)?.GetValue(entity)?.ToString()));
        }
        */
    }

}