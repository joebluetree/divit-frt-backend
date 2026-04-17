
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IConsigneeShipmentRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
