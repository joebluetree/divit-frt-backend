
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IFollowUpRepRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
