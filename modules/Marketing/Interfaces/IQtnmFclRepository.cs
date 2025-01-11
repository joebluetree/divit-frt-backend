
using Common.DTO.Marketing;


namespace Marketing.Interfaces
{
    public interface IQtnmFclRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mark_qtnm_dto?> GetRecordAsync(int id);
        Task<mark_qtnm_dto> SaveAsync(int id, string mode, mark_qtnm_dto record);
        Task<mark_qtnm_dto> SaveParentAsync(int id,string mode, mark_qtnm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
