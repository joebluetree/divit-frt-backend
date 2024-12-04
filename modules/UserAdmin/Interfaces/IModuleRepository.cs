

using Common.UserAdmin.DTO;
namespace UserAdmin.Interfaces
{
    public interface IModuleRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_modulem_dto?> GetRecordAsync(int id);
        Task<mast_modulem_dto> SaveAsync(int id,string mode, mast_modulem_dto record);
        Task<mast_modulem_dto> SaveParentAsync(int id, string mode, mast_modulem_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
