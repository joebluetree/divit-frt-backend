
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Common.DTO.Masters;
using Database.Lib;
using Common.DTO.SeaExport;
using SeaExport.Interfaces;
using Cargo.Interfaces;

namespace SeaExport.Controllers
{
    [Authorize]
    [Route("api/SeaExport/cargocoo")]
    public class CargoCooController : Controller
    {
        private readonly ICargoCooRepository mRepository;
        public CargoCooController(ICargoCooRepository Repository)
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
        public async Task<IActionResult> GetRecordAsync(int id, string parent_type)
        {
            try
            {
                var RetData = await mRepository.GetRecordAsync(id,parent_type);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }
        [HttpGet]
        [Route("GetDefaultData")]
        public async Task<IActionResult> GetDefaultData(int id, string parent_type)
        {
            try
            {
                var RetData = await mRepository.GetDefaultData(id,parent_type);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }
        [HttpGet]
        [Route("GetCntrDetails")]
        public async Task<IActionResult> GetCntrDetails(int id)
        {
            try
            {
                var RetData = await mRepository.GetCntrDetails(id);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }
        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] cargo_coo_dto rec)
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

    }
}
