
using Common.DTO.SeaExport;

namespace SeaExport.Interfaces
{
    public interface ISeaExportmRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_sea_exportm_dto?> GetRecordAsync(int id);
        Task<cargo_sea_exportm_dto> SaveAsync(int id, string mode, cargo_sea_exportm_dto record);

        Task<cargo_sea_exportm_dto> SaveParentAsync(int id,string mode, cargo_sea_exportm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
