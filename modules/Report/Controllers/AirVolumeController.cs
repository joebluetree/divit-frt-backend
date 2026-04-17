
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Database.Lib;
using Report.Interfaces;
using Common.DTO.Report;

namespace Report.Controllers
{
    [Authorize]
    [Route("api/Report/airvolume")]
    public class AirVolumeController : Controller
    {
        private readonly IAirVolumeRepository mRepository;
        public AirVolumeController(IAirVolumeRepository Repository)
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
    }
}
