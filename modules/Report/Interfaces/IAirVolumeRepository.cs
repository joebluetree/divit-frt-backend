
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IAirVolumeRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
