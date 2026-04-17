
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IDSRRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
