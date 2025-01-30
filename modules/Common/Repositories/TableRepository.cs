using Microsoft.EntityFrameworkCore;
using Database;
using Common.Interfaces;

namespace Common.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly AppDbContext context;

        private List<string>  files = new List<string>();
        public TableRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        public async Task CreateTablesAsync()
        {
            try
            {
                string rootPath = AppContext.BaseDirectory;
                AddFiles();
                await ExecuteScriptAsync(rootPath);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        private async Task ExecuteScriptAsync( string rootPath )
        {
            string fname = "";
            foreach (var fileName in files)
            {
                fname = System.IO.Path.Combine(rootPath, "scripts", fileName);
                if (!File.Exists(fname))
                    continue;
                string sqlScript = await File.ReadAllTextAsync(fname);
                await context.Database.ExecuteSqlRawAsync(sqlScript);
            }
        }
        private void AddFiles()
        {
            files = new List<string>();
            files.Add("test\\user_table.txt");
        }
    }
}

