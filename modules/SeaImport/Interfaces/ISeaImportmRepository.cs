
using Common.DTO.SeaImport;

namespace SeaImport.Interfaces
{
    public interface ISeaImportmRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_sea_importm_dto?> GetRecordAsync(int id);
        Task<cargo_sea_importm_dto> SaveAsync(int id, string mode, cargo_sea_importm_dto record);
        Task<cargo_sea_importm_dto> GetDefaultData();
        Task<cargo_sea_importm_dto> SaveParentAsync(int id,string mode, cargo_sea_importm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
