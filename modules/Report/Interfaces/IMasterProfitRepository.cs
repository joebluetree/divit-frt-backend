
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IMasterProfitRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
