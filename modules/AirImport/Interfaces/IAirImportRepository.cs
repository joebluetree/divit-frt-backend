using Common.DTO.AirImport;

namespace AirImport.Interfaces
{

    //Name : Alen Cherian
    //Date : 28/03/2025
    //Remark : Version 1.0

    public interface IAirImportRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_air_importm_dto?> GetRecordAsync(int id);
        Task<cargo_air_importm_dto> GetDefaultData();
        Task<cargo_air_importm_dto> SaveAsync(int id, string mode, cargo_air_importm_dto record);
        Task<cargo_air_importm_dto> SaveParentAsync(int id, string mode, cargo_air_importm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
