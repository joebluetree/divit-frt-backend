
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Database.Lib;
using Report.Interfaces;
using Common.DTO.Report;

namespace Report.Controllers
{
    [Authorize]
    [Route("api/Report/approval")]
    public class ApprovalRequestController : Controller
    {
        private readonly IApprovalRequestRepository mRepository;
        public ApprovalRequestController(IApprovalRequestRepository Repository)
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
