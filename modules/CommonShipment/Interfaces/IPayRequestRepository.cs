
using Common.DTO.CommonShipment;

namespace CommonShipment.Interfaces
{
    //Name : Sourav V
    //Date : 07/07/2026
    //Remark : Version 1.0
    public interface IPayRequestRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_payrequest_dto?> GetRecordAsync(int id);
        Task<List<cargo_payrequest_dto>> GetPayRequestDetAsync(int id,string ParentType);
        Task<cargo_payrequest_dto> SaveAsync(int id, string mode, cargo_payrequest_dto record);
        // Task<cargo_approvedd_dto> SaveApprovedDetAsync(int id, string mode, cargo_approvedd_dto record);
        Task<cargo_payrequest_dto> SaveParentAsync(int id,string mode, cargo_payrequest_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id, cargo_payrequest_dto record);
        // Task<Dictionary<string, object>> HideRecordAsync(int id);

    }
}
