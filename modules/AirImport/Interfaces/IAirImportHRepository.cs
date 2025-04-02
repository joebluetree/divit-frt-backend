
using Common.DTO.AirImport;

namespace AirImport.Interfaces
{

    //Name : Alen Cherian
    //Date : 29/03/2025
    //Remark : Version 1.0

    public interface IAirImportHRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_air_importh_dto?> GetRecordAsync(int id);
       Task<cargo_air_importh_dto?> GetDefaultDataAsync(int id);
        Task<cargo_air_importh_dto> SaveAsync(int id, string mode, cargo_air_importh_dto record);
        Task<cargo_air_importh_dto> SaveParentAsync(int id, string mode, cargo_air_importh_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
