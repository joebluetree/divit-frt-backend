using Common.UserAdmin.DTO;

namespace UserAdmin.Interfaces
{
   public interface IRightsRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<rights_header_dto> GetRecordAsync(int id);
        Task<rights_header_dto> SaveAsync(int id,string mode, rights_header_dto Record_DTO);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }

}
