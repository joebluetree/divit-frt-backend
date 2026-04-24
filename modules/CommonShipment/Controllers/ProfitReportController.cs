using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Database.Lib;
using CommonShipment.Interfaces;

namespace CommonShipment.Controllers
{
    [Authorize]
    [Route("api/Commonshipment/profitreport")]
    public class ProfitReportController : Controller
    {
        private readonly IProfitReportRepository mRepository;
        public ProfitReportController(IProfitReportRepository _Repository)
        {
            this.mRepository = _Repository;
        }

        [HttpPost]
        [Route("GetListAsync")]
        public async Task<IActionResult> GetListAsync([FromBody] Dictionary<string, object> data)
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
    }
}
