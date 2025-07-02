using Microsoft.EntityFrameworkCore;
using Database;
using System.Xml.Serialization;
using Common.DTO.Common;

namespace Common.Interfaces
{
    public interface ICommonProcessRepository
    {
        Task<FileDownloadResult_Dto> GetDownloadProcessFileAsync(Dictionary<string, object> data);
    }
}

