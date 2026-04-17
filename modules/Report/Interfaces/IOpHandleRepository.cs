
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IOpHandleRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
