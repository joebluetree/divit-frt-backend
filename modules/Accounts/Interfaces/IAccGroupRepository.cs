using Common.DTO.Accounts;

namespace Accounts.Interfaces
{
    public interface IAccGroupRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<acc_groupm_dto?> GetRecordAsync(int id);
        Task<acc_groupm_dto> SaveAsync(int id, string mode, acc_groupm_dto record);
        Task<acc_groupm_dto> SaveParentAsync(int id,string mode, acc_groupm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
