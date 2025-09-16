
using Common.DTO.Marketing;

//Name : Sourav V
//Created Date : 10/01/2025
//Remark : this file defines interface for managing qtnm-air data with function to save,retrive and delete records
//version 2 added defaultData service

namespace Marketing.Interfaces
{
    public interface IQtnmAirRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mark_qtnm_dto?> GetRecordAsync(int id);
        Task<mark_qtnm_dto> GetDefaultData(int id);
        Task<mark_qtnm_dto> SaveAsync(int id, string mode, mark_qtnm_dto record);
        Task<mark_qtnm_dto> SaveParentAsync(int id, string mode, mark_qtnm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
