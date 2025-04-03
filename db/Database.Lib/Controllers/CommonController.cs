using Database.Lib.Interfaces;
using Database.Lib.Repositories;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Database.Lib.Controllers
{

    [Route("api/search")]
    public class CommonController : Controller
    {
        private readonly ICommonRepository mRepository;
        public CommonController(ICommonRepository _Repository )
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
        [Route("GetSequenceAsync")]
        public async  Task<IActionResult> GetSequenceAsync(string name)
        {
            try
            {
                long nextValue = await mRepository.GetSequenceAsync(name);
                return Ok(nextValue);  
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetCustomerAsync")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            try
            {
                var RetData = await mRepository.GetCustomerAsync(id);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }


    }
}
