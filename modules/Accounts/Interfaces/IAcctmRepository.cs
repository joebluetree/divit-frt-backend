using Common.DTO.Accounts;

namespace Accounts.Interfaces
{
    public interface IAcctmRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<acc_acctm_dto?> GetRecordAsync(int id);
        Task<acc_acctm_dto> SaveAsync(int id ,string mode , acc_acctm_dto record);
       Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
