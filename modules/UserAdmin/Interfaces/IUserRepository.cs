using Database.Models;
using Common.UserAdmin.DTO;

namespace UserAdmin.Interfaces
{
   public interface IUserRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_userm_dto?> GetRecordAsync(int comp_id, int id);
        Task<List<mast_userbranches_dto>> GetUserBranchesAsync(int comp_id, int id);
        Task<mast_userm_dto> SaveAsync(int id, string mode, mast_userm_dto record);
        Task<mast_userm_dto> SaveParentAsync(int id, string mode, mast_userm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }

}
