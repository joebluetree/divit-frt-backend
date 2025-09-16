
using Common.DTO.AirExport;
using Common.DTO.Common;

namespace AirExport.Interfaces
{

    //Name : Alen Cherian
    //Date : 24/02/2025
    //Remark : Version 1.0

    public interface IAirExportRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_air_exportm_dto?> GetRecordAsync(int id);
        Task<cargo_air_exportm_dto> GetDefaultData();
        Task<cargo_air_exportm_dto> SaveAsync(int id, string mode, cargo_air_exportm_dto record);
        Task<cargo_air_exportm_dto> SaveParentAsync(int id, string mode, cargo_air_exportm_dto record);
        Task<FileDownloadResult_Dto> GetShipmentLabelAsync(Dictionary<string, object> data);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
