using Common.DTO.Masters;
using Common.DTO.Common;

namespace Masters.Interfaces
{
    public interface IParamRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_param_dto?> GetRecordAsync(int id);
        Task<mast_param_dto> SaveAsync(int id, string mode, mast_param_dto record);
        Task<mast_param_dto> SaveParentAsync(int id, string mode, mast_param_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);
        // Task<FileDownloadResult_Dto> GetDownloadPdfAsync(Dictionary<string, object> data);
        // Task<FileDownloadResult_Dto> GetDownloadExcelAsync(Dictionary<string, object> data);
    }
}
