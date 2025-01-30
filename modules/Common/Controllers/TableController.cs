using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Common.Interfaces;

namespace UserAdmin.Controllers
{
    [Authorize]
    [Route("")]
    public class TableController : Controller
    {
        private readonly ITableRepository mRepository;
        public TableController(ITableRepository _Repository)
        {
            this.mRepository = _Repository;
        }
        
        [HttpGet]
        [AllowAnonymous]
        [Route("CreateTables")]
        public async Task<IActionResult> CreateTables(int id)
        {
            try
            {
                await mRepository.CreateTablesAsync();
                return Ok();
            }
            catch (Exception Ex) {
                return BadRequest(Ex.Message.ToString());
            }
        }
    }
}
