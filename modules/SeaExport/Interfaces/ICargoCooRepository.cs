
using Common.DTO.SeaExport;

namespace Cargo.Interfaces
{
    public interface ICargoCooRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_coo_dto?> GetRecordAsync(int id, string parent_type);
        Task<cargo_coo_dto> SaveAsync(int id, string mode, cargo_coo_dto record);
        Task<cargo_coo_dto> GetDefaultData(int id, string parent_type);
        Task<cargo_coo_dto> GetCntrDetails(int id);
        Task<cargo_coo_dto> SaveParentAsync(int id,string mode, cargo_coo_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
