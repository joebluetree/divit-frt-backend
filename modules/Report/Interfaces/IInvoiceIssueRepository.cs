
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IInvoiceIssueRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    }
}
