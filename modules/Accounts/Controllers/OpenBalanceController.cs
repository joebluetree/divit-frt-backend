using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Common.DTO.Accounts;
using Database.Lib;
using Accounts.Interfaces;

namespace Accounts.Controllers
{
    [Authorize]
    [Route("api/Accounts/openbalance")]
    public class OpenBalanceController : Controller
    {
        private readonly IOpenBalanceRepository mRepository;
        public OpenBalanceController(IOpenBalanceRepository _Repository)
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
        public async Task<IActionResult> GetDefaultData(int company_id, int branch_id)
        {
            try
            {
                
                var RetData = await mRepository.GetDefaultData(company_id, branch_id);
                return Ok(RetData);
            }
            catch (Exception Ex) {
                return BadRequest(Ex.Message.ToString());
            }
        }
        
        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode , [FromBody] acc_ledgerh_dto rec)
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