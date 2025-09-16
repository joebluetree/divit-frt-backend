
using Common.DTO.Marketing;


namespace Marketing.Interfaces
{

    //Name : Alen Cherian
    //Date : 03/01/2025
    //Command : Created the interface for Quotation Fcl.

    public interface IQtnmFclRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mark_qtnm_dto?> GetRecordAsync(int id);
        Task<mark_qtnm_dto> GetDefaultData(int id);
        Task<mark_qtnm_dto> SaveAsync(int id, string mode, mark_qtnm_dto record);
        Task<mark_qtnm_dto> SaveParentAsync(int id,string mode, mark_qtnm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
