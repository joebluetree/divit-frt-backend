
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IDataEntryStatRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
