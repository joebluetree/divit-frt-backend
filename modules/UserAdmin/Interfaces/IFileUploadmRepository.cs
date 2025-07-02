using Common.DTO.UserAdmin;
using Common.DTO.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserAdmin.Interfaces
{
    public interface IFileUploadmRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_fileupload_dto?> GetRecordAsync(int id);
        Task<List<mast_fileupload_dto>> GetDetailsAsync(int id, string parent_type, string files_search);
        Task<mast_fileupload_dto?> GetDefaultDataAsync(int id, string parent_type);
        Task<Dictionary<string, object>> GetDataListAsync(string data);
        Task<List<mast_fileupload_dto>> UploadFilesAsync(List<IFormFile> files, mast_fileupload_dto record_dto);
        Task<FileDownloadResult_Dto> GetDownloadFileAsync(Dictionary<string, object> data);
        Task<mast_fileupload_dto> SaveAsync(int id, string mode, mast_fileupload_dto record);
        Task<mast_fileupload_dto> SaveParentAsync(int id, string mode, mast_fileupload_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);
        Task<Dictionary<string, object>> DeleteDetailsAsync(int id, mast_fileupload_dto record);

    }
}
