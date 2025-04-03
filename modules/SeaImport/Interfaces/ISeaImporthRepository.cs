
using Common.DTO.SeaImport;

namespace SeaImport.Interfaces
{
    public interface ISeaImporthRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_sea_importh_dto?> GetRecordAsync(int id);
        Task<cargo_sea_importh_dto?> GetDefaultData(int id);
        Task<cargo_sea_importh_dto> SaveAsync(int id, string mode, cargo_sea_importh_dto record); 
        Task<cargo_sea_importh_dto> SaveParentAsync(int id,string mode, cargo_sea_importh_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
