
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Common.DTO.Masters;
using Database.Lib;
using CommonShipment.Interfaces;
using Common.DTO.CommonShipment;

namespace CommonShipment.Controllers
{
    [Authorize]
    [Route("api/CommonShipment/approvedm")]
    public class ApprovedController : Controller
    {
        private readonly IApprovedRepository mRepository;
        public ApprovedController(IApprovedRepository Repository)
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

        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] cargo_approvedm_dto rec)
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
        [HttpPost]
        [Route("SaveApprovedDetAsync")]
        public async Task<IActionResult> SaveApprovedDetAsync(int id, string mode, [FromBody] cargo_approvedd_dto rec)
        {
            try
            {
                var record = await mRepository.SaveApprovedDetAsync(id, mode, rec);
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
        [HttpGet]
        [Route("HideRecordAsync")]
        public async Task<IActionResult> HideRecordAsync(int id)
        {
            try
            {
                var RetData = await mRepository.HideRecordAsync(id);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

    }
}
