using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Common.DTO.Masters;
using Database.Lib;
using Common.DTO.AirExport;
using CommonShipment.Interfaces;
using Common.DTO.CommonShipment;

namespace Marketing.Controllers
{

    //Name : Sourav V
    //Created Date : 17/04/2025
    //Remark : Control function path
    //version V1 - 17/04/2025

    [Authorize]
    [Route("api/CommonShipment/deliveryorder")]
    public class DeliveryOrderController : Controller
    {
        private readonly IDeliveryOrderRepository mRepository;
        public DeliveryOrderController(IDeliveryOrderRepository Repository)
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
        public async Task<IActionResult> GetDefaultDataAsync(int id,string parent_type)
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

        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] cargo_delivery_order_dto rec)
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
