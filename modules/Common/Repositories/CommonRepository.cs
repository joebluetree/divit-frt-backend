using Microsoft.EntityFrameworkCore;
using Database;
using Common.Interfaces;
using System.Linq.Expressions;
using Common.DTO.Common;

namespace Common.Repositories
{
    public class CommonProcessRepository : ICommonProcessRepository
    {
        private readonly AppDbContext context;

        private List<string>  files = new List<string>();
        public CommonProcessRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        public async Task<FileDownloadResult_Dto> GetDownloadProcessFileAsync(Dictionary<string, object> data)
        {
            var filePath = "";

            if (data.ContainsKey("file_path"))
                filePath = data["file_path"].ToString();

            var record = await Lib.CommonLib.GetFileAsync(filePath!);
            return record;

        }
    }
}