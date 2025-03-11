
using Common.DTO.SeaExport;

namespace SeaExport.Interfaces
{
    public interface ISeaExporthRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_sea_exporth_dto?> GetRecordAsync(int id);
        Task<cargo_sea_exporth_dto> SaveAsync(int id, string mode, cargo_sea_exporth_dto record); // string mark, string package, string desc, int ctr,

        Task<cargo_sea_exporth_dto> SaveParentAsync(int id,string mode, cargo_sea_exporth_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
