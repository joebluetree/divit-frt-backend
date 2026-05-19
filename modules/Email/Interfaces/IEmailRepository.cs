
using Common.DTO.Email;

namespace Email.Interfaces
{
    public interface IEmailRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<email_jobs_dto?> GetRecordAsync(int id);
        Task<email_jobs_dto> SaveAsync(int id, string mode, email_jobs_dto record);
        // Task<email_jobs_dto> GetDefaultData();
        Task<email_jobs_dto> SaveParentAsync(int id,string mode, email_jobs_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
