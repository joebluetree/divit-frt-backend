using Common.DTO.Accounts;

namespace Accounts.Interfaces
{
    public interface IInvoicemRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<acc_invoicem_dto?> GetRecordAsync(int id);
        Task<acc_invoicem_dto> GetDefaultData(int id);
        Task<acc_invoicem_dto> GetQtnmlistData(string qtnm_no);
        Task<acc_invoicem_dto> SaveAsync(int id ,string mode , acc_invoicem_dto record);
        Task<acc_invoicem_dto> SaveParentAsync(int id,string mode, acc_invoicem_dto record);
        Task<acc_invoicem_dto> SaveMemoAsync(int id, acc_invoicem_dto record);
        Task<Dictionary<string, object>> DeleteDetailsAsync(int id);//, acc_invoicem_dto record
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
