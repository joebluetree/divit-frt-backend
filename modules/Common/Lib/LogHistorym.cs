using Microsoft.EntityFrameworkCore;
using Database.Models.UserAdmin;
using System.ComponentModel.DataAnnotations;

using Database.Lib;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;


namespace Common.Lib
{
    public class LogHistorym<T> where T : class
    {
        private readonly DbContext _context;
        private string _table_name = "";
        private string pkey = "";
        private int _version = 0;

        private DateTime _log_date;
        private readonly Dictionary<string, (string Description, string DataType)> _columnsToTrack;

        private readonly List<T> _oldEntities;
        private readonly List<T> _newEntities;

        private int _id { get; set; } = 0;
        private int _company_id { get; set; } = 0;
        private int _branch_id { get; set; } = 0;
        private string _user_code { get; set; } = "";
        private int _order = 0;
        public LogHistorym(DbContext context)
        {
            _context = context;
            pkey = "";
            _columnsToTrack = new Dictionary<string, (string Description, string DataType)>();

            _oldEntities = new List<T>();
            _newEntities = new List<T>();
        }

        public LogHistorym<T> PrimaryKey(string key, int value)
        {
            _id = value;
            pkey = key;
            return this;
        }
        public LogHistorym<T> Table(string table_name, DateTime log_date)
        {
            _table_name = table_name;
            _log_date = log_date;
            return this;
        }


        public LogHistorym<T> SetCompanyInfo(int version, int company_id, int branch_id, string user_code)
        {
            _version = version;
            _company_id = company_id;
            _branch_id = branch_id;
            _user_code = user_code;
            return this;
        }

        public LogHistorym<T> TrackColumn(string column, string description, string dataType = "string")
        {
            _columnsToTrack[column] = (description, dataType.ToLower()); // Default to string if not provided
            return this;
        }

        public LogHistorym<T> SetRecords(IEnumerable<T> oldEntities, IEnumerable<T> newEntities)
        {
            _oldEntities.AddRange(oldEntities);
            _newEntities.AddRange(newEntities);
            return this;
        }

        public LogHistorym<T> SetRecord(T oldEntities, T newEntities)
        {
            _oldEntities.Add(oldEntities);
            _newEntities.Add(newEntities);
            return this;
        }


        public async Task<LogHistorym<T>> LogChangesAsync()
        {
            try
            {
                var historyLogs = new List<mast_history>();
                var oldEntitiesDict = _oldEntities.ToLookup(e => pkey);
                var newEntitiesDict = _newEntities.ToLookup(e => pkey);
                // Check for modified and deleted records
                Boolean bFound = false;
                foreach (var oldEntity in _oldEntities)
                {
                    var oldpkValue = oldEntity.GetType().GetProperty(pkey)?.GetValue(oldEntity)?.ToString();
                    bFound = false;
                    foreach (var newEntity in _newEntities)
                    {
                        var newpkValue = newEntity.GetType().GetProperty(pkey)?.GetValue(newEntity)?.ToString();
                        if (oldpkValue != newpkValue)
                            continue;
                        bFound = true;
                        foreach (var column in _columnsToTrack.Keys)
                        {
                            var (description, dataType) = _columnsToTrack[column];

                            var oldValue = oldEntity.GetType().GetProperty(column)?.GetValue(oldEntity)?.ToString();
                            var newValue = newEntity.GetType().GetProperty(column)?.GetValue(newEntity)?.ToString();

                            if (compareValues(oldValue!, newValue!, dataType))
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
                                    log_desc = description,
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
                    if (!bFound)
                    {
                        // Deleted record
                        foreach (var column in _columnsToTrack.Keys)
                        {
                            var (description, dataType) = _columnsToTrack[column];
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
                                log_desc = description,
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
                    var key = pkey;

                    if (!oldEntitiesDict.Contains(key))
                    {
                        foreach (var column in _columnsToTrack.Keys)
                        {
                            var (description, dataType) = _columnsToTrack[column];
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
                                log_desc = description,
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

                // Save logs asynchronously
                await _context.Set<mast_history>().AddRangeAsync(historyLogs);
                await _context.SaveChangesAsync();

                // Debugging Output (Optional)
                // foreach (var log in historyLogs)
                // {
                //     Console.WriteLine($"{log.log_column}: {log.log_old_value} -> {log.log_new_value} ({log.log_status})");
                // }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging changes: {ex.Message}");
                throw;
            }

            return this;
        }


        Boolean compareValues(string oldValue, string newValue, string data_type)
        {
            Boolean bRet = false;
            if (data_type.ToLower() == "string")
            {
                if (oldValue == null)
                    oldValue = "";
                if (newValue == null)
                    newValue = "";

                if (oldValue != newValue)
                    bRet = true;
            }
            if (data_type.ToLower() == "int")
            {
                if (Database.Lib.Lib.StringToInteger(oldValue) != Database.Lib.Lib.StringToInteger(newValue))
                {
                    bRet = true;
                }
            }
            if (data_type.ToLower() == "decimal")
            {
                if (Database.Lib.Lib.StringToInteger(oldValue) != Database.Lib.Lib.StringToInteger(newValue))
                {
                    bRet = true;
                }
            }

            return bRet;
        }


    }

}