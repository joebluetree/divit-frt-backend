
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IPendingARRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<Dictionary<string, object>> HideRecordAsync (int id);
    }
}
