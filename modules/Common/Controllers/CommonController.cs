using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Common.Interfaces;

namespace Common.Controllers
{
    [Authorize]
    [Route("api/common")]
    public class CommonProcessController : Controller
    {
        private readonly ICommonProcessRepository mRepository;
        public CommonProcessController(ICommonProcessRepository _Repository)
        {
            this.mRepository = _Repository;
        }

        [HttpPost]
        [Route("GetDownloadFileAsync")]
        public async Task<IActionResult> GetDownloadProcessFileAsync([FromBody] Dictionary<string, object> data)
        {
            try
            {
                var records = await this.mRepository.GetDownloadProcessFileAsync(data);
                var RetData = File(records.FileStream!, records.ContentType!, records.FileName);
                return RetData;
            }
            catch (Exception Ex)
            {
                return BadRequest(Database.Lib.Lib.getErrorMessage(Ex));
            }
        }
    }
}
