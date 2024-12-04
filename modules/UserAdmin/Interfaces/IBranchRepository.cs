
using Common.UserAdmin.DTO;
namespace UserAdmin.Interfaces
{
    public interface IBranchRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_branchm_dto?> GetRecordAsync(int id);
        Task<mast_branchm_dto> SaveAsync(int id,string mode, mast_branchm_dto record);
        Task<mast_branchm_dto> SaveParentAsync(int id, string mode,  mast_branchm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
