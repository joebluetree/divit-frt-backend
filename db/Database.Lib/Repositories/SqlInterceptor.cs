using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

using System.Data.Common;

namespace Database.Lib.Repositories
{
    public class SqlInterceptor : DbCommandInterceptor
    {
        private readonly ILogger<SqlInterceptor> _logger;

        public SqlInterceptor(ILogger<SqlInterceptor> logger)
        {
            _logger = logger;
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            LogCommand(command);
            return base.ReaderExecuting(command, eventData, result);
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            LogCommand(command);
            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }

        private void LogCommand(DbCommand command)
        {
            _logger.LogInformation("Executing command: {CommandText}", command.CommandText);
            foreach (DbParameter parameter in command.Parameters)
            {
                _logger.LogInformation("Parameter: {ParameterName} = {ParameterValue}", parameter.ParameterName, parameter.Value);
            }
        }
    }

}
