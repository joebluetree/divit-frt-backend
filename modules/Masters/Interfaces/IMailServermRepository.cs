
using Common.DTO.Masters;

namespace Masters.Interfaces
{
    public interface IMailServermRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_mail_serverm_dto?> GetRecordAsync(int id);
        Task<mast_mail_serverm_dto> SaveAsync(int id, string mode, mast_mail_serverm_dto record);

        Task<mast_mail_serverm_dto> SaveParentAsync(int id,string mode, mast_mail_serverm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
