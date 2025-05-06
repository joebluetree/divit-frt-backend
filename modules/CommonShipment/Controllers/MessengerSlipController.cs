
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Database.Lib;
using CommonShipment.Interfaces;
using Common.DTO.CommonShipment;

namespace CommonShipment.Controllers
{
    //Name : Alen Cherian
    //Date : 22/04/2025
    //Command :  Api Controller for the MessengerSlip.


    [Authorize]
    [Route("api/CommonShipment/MessengerSlip")]
    public class MessengerSlipController : Controller
    {
        private readonly IMessengerSlipRepository mRepository;
        public MessengerSlipController(IMessengerSlipRepository Repository)
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
                var RetData = await mRepository.GetRecordAsync(id, parent_type);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        [HttpGet]
        [Route("GetDefaultDataAsync")]
        public async Task<IActionResult> GetDefaultDataAsync(int id)
        {
            try
            {
                var RetData = await mRepository.GetDefaultDataAsync(id);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        [HttpGet]
        [Route("GetDetailsAsync")]
        public async Task<IActionResult> GetDetailsAsync(int id, string parent_type)
        {
            try
            {
                var RetData = await mRepository.GetDetailsAsync(id, parent_type);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }


        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] cargo_slip_dto rec)
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
