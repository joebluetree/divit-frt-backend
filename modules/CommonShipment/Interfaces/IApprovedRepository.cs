
using Common.DTO.CommonShipment;

namespace CommonShipment.Interfaces
{
    //Name : Sourav V
    //Date : 09/06/2026
    //Remark : Version 1.0
    public interface IApprovedRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_approvedm_dto?> GetRecordAsync(int id);
        // Task<List<cargo_approvedm_dto>> GetApprovedRemarksAsync(int id,string ParentType);
        Task<cargo_approvedm_dto> SaveAsync(int id, string mode, cargo_approvedm_dto record);
        Task<cargo_approvedd_dto> SaveApprovedDetAsync(int id, string mode, cargo_approvedd_dto record);
        Task<cargo_approvedm_dto> SaveParentAsync(int id,string mode, cargo_approvedm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);
        Task<Dictionary<string, object>> HideRecordAsync(int id);

    }
}
