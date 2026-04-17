
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface ISeaVolumeRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
