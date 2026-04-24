
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IHouseProfitRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
