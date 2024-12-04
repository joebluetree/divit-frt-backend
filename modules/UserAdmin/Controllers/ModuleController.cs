using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Common.UserAdmin.DTO;
using UserAdmin.Interfaces;

namespace UserAdmin.Controllers
{
    [Authorize]
    [Route("api/module")]
    public class ModuleController : Controller
    {
        private readonly IModuleRepository mRepository;
        public ModuleController(IModuleRepository _Repository)
        {
            this.mRepository = _Repository;
        }
        
        [HttpPost]
        [Route("GetListAsync")]
        public async Task<IActionResult> GetListAsync( [FromBody] Dictionary<string, object> data )
        {
            try
            {
                var Records = await this.mRepository.GetListAsync(data);
                return Ok(Records);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message.ToString());
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
            catch (Exception Ex) {
                return BadRequest(Ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] mast_modulem_dto rec)
        {
            try
            {
                var Record = await mRepository.SaveAsync(id,mode, rec);
                return Ok(Record);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message.ToString());
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
                return BadRequest(Ex.Message.ToString());
            }
        }

    }
}
