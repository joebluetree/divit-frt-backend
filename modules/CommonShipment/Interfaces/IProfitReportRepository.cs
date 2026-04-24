using Common.DTO.Accounts;
using Database.Models.Cargo;

namespace CommonShipment.Interfaces
{
    public interface IProfitReportRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
