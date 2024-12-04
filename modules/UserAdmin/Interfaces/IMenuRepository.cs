

using Common.UserAdmin.DTO;
namespace UserAdmin.Interfaces
{
    public interface IMenuRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_menum_dto?> GetRecordAsync(int id);
        Task<mast_menum_dto> SaveAsync(int id, string mode, mast_menum_dto record);

        Task<mast_menum_dto> SaveParentAsync(int id, string mode, mast_menum_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
