using Common.DTO.UserAdmin;
using Microsoft.AspNetCore.Http;

namespace UserAdmin.Interfaces
{
    public interface IFileUploadmRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<mast_fileupload_dto?> GetRecordAsync(int id);
        Task<List<mast_fileupload_dto>> GetDetailsAsync(int id, string parent_type);
        Task<mast_fileupload_dto?> GetDefaultDataAsync(int id);
        Task<mast_fileupload_dto> UploadFiles(int id, mast_fileupload_dto record_dto, List<IFormFile> files);
        Task<mast_fileupload_dto> SaveAsync(int id, string mode, mast_fileupload_dto record);
        // Task<mast_fileupload_dto> SaveAsync(int id, string mode, mast_fileupload_dto record, List<IFormFile> files);
        Task<mast_fileupload_dto> SaveParentAsync(int id,string mode, mast_fileupload_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
