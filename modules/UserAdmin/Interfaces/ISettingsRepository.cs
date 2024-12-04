
using Common.UserAdmin.DTO;
namespace UserAdmin.Interfaces
{
    public interface ISettingsRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_settings_dto?> GetRecordAsync(int id);

        Task<int> ReUpdateAsync(string category, int company_id, int branch_id, int param_id, string user_code);
        Task<mast_settings_dto> SaveAsync(int id,string mode, mast_settings_dto record);
        Task<mast_settings_dto> SaveParentAsync(int id, string mode, mast_settings_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
