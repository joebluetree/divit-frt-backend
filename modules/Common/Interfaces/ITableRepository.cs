using Microsoft.EntityFrameworkCore;
using Database;
using System.Xml.Serialization;

namespace Common.Interfaces
{
    public interface ITableRepository
    {
        Task CreateTablesAsync();
    }
}

