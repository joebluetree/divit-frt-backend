
using Common.DTO.AirExport;

namespace AirExport.Interfaces
{

    //Name : Alen Cherian
    //Date : 27/02/2025
    //Remark : Version 1.0

    public interface IAirExportHRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_air_exporth_dto?> GetRecordAsync(int id);
        Task<cargo_air_exporth_dto> SaveAsync(int id, string mode, cargo_air_exporth_dto record);
        Task<cargo_air_exporth_dto> SaveParentAsync(int id, string mode, cargo_air_exporth_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
