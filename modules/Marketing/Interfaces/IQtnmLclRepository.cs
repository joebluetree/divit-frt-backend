
using Common.DTO.Marketing;

//Name : Sourav V
//Created Date : 03/01/2025
//Remark : this file defines interface for managing qtnm-lcl data with function to save,retrive and delete records

namespace Marketing.Interfaces
{
    public interface IQtnmLclRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mark_qtnm_dto?> GetRecordAsync(int id);
        Task<mark_qtnm_dto> GetDefaultData(int company_id, int branch_id);
        Task<mark_qtnm_dto> SaveAsync(int id, string mode, mark_qtnm_dto record);
        Task<mark_qtnm_dto> SaveParentAsync(int id,string mode, mark_qtnm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
