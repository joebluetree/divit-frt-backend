using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Accounts.Interfaces;
using Common.DTO.Accounts;
using Database.Lib;

namespace Accounts.Controllers
{
    [Authorize]
    [Route("api/Accounts/Invoicem")]
    public class InvoicemController : Controller
    {
        private readonly IInvoicemRepository mRepository;
        public InvoicemController(IInvoicemRepository _Repository)
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

        [HttpGet]
        [Route("GetDefaultData")]
        public async Task<IActionResult> GetDefaultData(int id)
        {
            try
            {
                
                var RetData = await mRepository.GetDefaultData(id);
                return Ok(RetData);
            }
            catch (Exception Ex) {
                return BadRequest(Ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetQtnmlistData")]
        public async Task<IActionResult> GetQtnmlistData(string qtnm_no)
        {
            try
            {
                
                var RetData = await mRepository.GetQtnmlistData(qtnm_no);
                return Ok(RetData);
            }
            catch (Exception Ex) {
                return BadRequest(Ex.Message.ToString());
            }
        }
        
        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode , [FromBody] acc_invoicem_dto rec)
        {
            try
            {
                var record = await mRepository.SaveAsync(id, mode, rec);
                return Ok(record);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("SaveMemoAsync")]
        public async Task<IActionResult> SaveMemoAsync(int id, [FromBody] acc_invoicem_dto rec)
        {
            try
            {
                var record = await mRepository.SaveMemoAsync(id, rec);
                return Ok(record);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("DeleteDetailsAsync")]
        public async Task<IActionResult> DeleteDetailsAsync(int id)//, [FromBody] acc_invoicem_dto rec
        {
            try
            {
                var RetData = await mRepository.DeleteDetailsAsync(id);//, rec
                return Ok(RetData);
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
