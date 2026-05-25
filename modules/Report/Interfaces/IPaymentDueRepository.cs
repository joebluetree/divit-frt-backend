
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IPaymentDueRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
