using Common.UserAdmin.DTO;
namespace UserAdmin.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_companym_dto?> GetRecordAsync(int id);
        Task<mast_companym_dto> SaveAsync(int id,string mode, mast_companym_dto record);
        Task<mast_companym_dto> SaveParentAsync(int id, string mode, mast_companym_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
