
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface ICustomerListRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
