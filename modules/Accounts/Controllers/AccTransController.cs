
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Database.Lib;
using Accounts.Interfaces;
using Database.Models.Accounts;
using Common.DTO.Accounts;

//Name : Sourav V
//Created Date : 15/10/2025
//Remark : this file defines paths or route for accessing functions Repository

namespace Accounts.Controllers
{
    [Authorize]
    [Route("api/Accounts/acctrans")]
    public class AccTransController : Controller
    {
        private readonly IAccTransRepository mRepository;
        public AccTransController (IAccTransRepository Repository)
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
        [Route("GetDefaultData")]
        public async Task<IActionResult> GetDefaultData(int company_id, int branch_id)
        {
            try
            {
                
                var RetData = await mRepository.GetDefaultData(company_id , branch_id);
                return Ok(RetData);
            }
            catch (Exception Ex) {
                return BadRequest(Ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] acc_ledgerh_dto rec)
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
