
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IITShipmentRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
