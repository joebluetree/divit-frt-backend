
using Common.DTO.Masters;

namespace Masters.Interfaces
{
    public interface ICustomermRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_customerm_dto?> GetRecordAsync(int id);
        Task<mast_customerm_dto> SaveAsync(int id, string mode, mast_customerm_dto record);

        Task<mast_customerm_dto> SaveParentAsync(int id,string mode, mast_customerm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
