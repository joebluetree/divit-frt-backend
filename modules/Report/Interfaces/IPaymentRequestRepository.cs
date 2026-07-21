
using Common.DTO.CommonShipment;
using Common.DTO.Report;

namespace Report.Interfaces
{
    public interface IPaymentRequestRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<rep_payrequest_dto?> GetDefaultData(int id);
        Task<rep_payrequest_dto> SaveStatusAsync(int id, string mode, rep_payrequest_dto record);
        Task<Dictionary<string, object>> HideRecordAsync(int id);
    }
}
