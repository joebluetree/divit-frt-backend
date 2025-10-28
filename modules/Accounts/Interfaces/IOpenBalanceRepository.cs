using Common.DTO.Accounts;
using Database.Models.Accounts;

namespace Accounts.Interfaces
{
    public interface IOpenBalanceRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<acc_ledgerh_dto?> GetRecordAsync(int id);
        Task<acc_ledgerh_dto> GetDefaultData(int company_id, int branch_id);
        Task<acc_ledgerh_dto> SaveAsync(int id ,string mode , acc_ledgerh_dto record);
        Task<acc_ledgerh_dto> SaveParentAsync(int id,string mode, acc_ledgerh_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
