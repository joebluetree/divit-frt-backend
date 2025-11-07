using Database.Models;
using Common.UserAdmin.DTO;

namespace UserAdmin.Interfaces
{
   public interface IYearRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_yearm_dto?> GetRecordAsync(int comp_id, int id);
        Task<mast_yearm_dto> SaveAsync(int id, string mode, mast_yearm_dto record);
        Task<mast_yearm_dto> SaveParentAsync(int id, string mode, mast_yearm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }

}
