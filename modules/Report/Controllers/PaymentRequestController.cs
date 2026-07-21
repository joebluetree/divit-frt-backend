
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Database.Lib;
using Report.Interfaces;
using Common.DTO.Report;

namespace Report.Controllers
{
    [Authorize]
    [Route("api/Report/payrequest")]
    public class PaymentRequestController : Controller
    {
        private readonly IPaymentRequestRepository mRepository;
        public PaymentRequestController(IPaymentRequestRepository Repository)
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
        [Route("GetDefaultData")]
        public async Task<IActionResult> GetDefaultData(int id)
        {
            try
            {
                var RetData = await mRepository.GetDefaultData(id);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));         
            }
        }
        [HttpPost]
        [Route("SaveStatusAsync")]
        public async Task<IActionResult> SaveStatusAsync(int id, string mode, [FromBody] rep_payrequest_dto rec)
        {
            try
            {
                var record = await mRepository.SaveStatusAsync(id, mode, rec);
                return Ok(record);
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
