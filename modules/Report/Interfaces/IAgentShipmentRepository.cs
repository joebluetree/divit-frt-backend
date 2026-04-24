
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IAgentShipmentRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
