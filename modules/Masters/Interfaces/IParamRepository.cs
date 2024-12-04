using Common.DTO.Masters;

namespace Masters.Interfaces
{
    public interface IParamRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_param_dto?> GetRecordAsync(int id);
        Task<mast_param_dto> SaveAsync(int id,string mode, mast_param_dto record);
        Task<mast_param_dto> SaveParentAsync(int id,string mode, mast_param_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);
    }
}
