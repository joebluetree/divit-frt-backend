using Database.Lib;
using UserAdmin.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Common.DTO.UserAdmin;
using Microsoft.AspNetCore.Http;

namespace UserAdmin.Controllers
{
    //Name : Alen Cherian
    //Date : 06/05/2025
    //Command :  Api Controller for the File Upload.


    [Authorize]
    [Route("api/UserAdmin/FileUpload")]
    public class FileUploadmController : Controller
    {
        private readonly IFileUploadmRepository mRepository;
        public FileUploadmController(IFileUploadmRepository Repository)
        {
            this.mRepository = Repository;
        }

        [HttpPost]
        [Route("GetListAsync")]
        public async Task<IActionResult> GetListAsync([FromBody] Dictionary<string, object> data)
        {
            try
            {
                var records = await this.mRepository.GetListAsync(data);
                return Ok(records);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        [HttpGet]
        [Route("GetRecordAsync")]
        public async Task<IActionResult> GetRecordAsync(int id)
        {
            try
            {
                var RetData = await mRepository.GetRecordAsync(id);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        [HttpGet]
        [Route("GetDefaultDataAsync")]
        public async Task<IActionResult> GetDefaultDataAsync(int id, string parent_type)
        {
            try
            {
                var RetData = await mRepository.GetDefaultDataAsync(id,parent_type);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        [HttpGet]
        [Route("GetDetailsAsync")]
        public async Task<IActionResult> GetDetailsAsync(int id, string parent_type, string files_status)
        {
            try
            {
                var RetData = await mRepository.GetDetailsAsync(id, parent_type, files_status);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        [HttpPost]
        [Route("UploadFiles")]
        public async Task<IActionResult> UploadFilesAsync( mast_fileupload_dto record_dto, List<IFormFile> files)
        {
            try
            {
                var record = await mRepository.UploadFilesAsync(files , record_dto);
                return Ok(record);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        [HttpGet]
        [Route("DownloadFiles")]
        public async Task<IActionResult> GetDownloadFileAsync(int id)
        {
            try
            {
                var RetData = await mRepository.GetDownloadFileAsync(id);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] mast_fileupload_dto rec)
        {
            try
            {
                var record = await mRepository.SaveAsync(id, mode, rec);
                return Ok(record);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        [HttpGet]
        [Route("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var RetData = await mRepository.DeleteAsync(id);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        [HttpPost]
        [Route("DeleteDetailsAsync")]
        public async Task<IActionResult> DeleteDetailsAsync(int id, [FromBody] mast_fileupload_dto rec)
        {
            try
            {
                var RetData = await mRepository.DeleteDetailsAsync(id, rec);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }


    }
}
