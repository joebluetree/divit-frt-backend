
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Database.Lib;
using Report.Interfaces;
using Common.DTO.Report;

namespace Report.Controllers
{
    [Authorize]
    [Route("api/Report/dsr")]
    public class DSRController : Controller
    {
        private readonly IDSRRepository mRepository;
        public DSRController(IDSRRepository Repository)
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
