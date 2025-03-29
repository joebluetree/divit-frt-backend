
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// using Common.DTO.Masters;
// using Database.Lib;
// using Common.DTO.SeaExport;
// using SeaExport.Interfaces;

// namespace SeaExport.Controllers
// {
//     [Authorize]
//     [Route("api/SeaExport/seaexporth")]
//     public class SeaExporthController : Controller
//     {
//         private readonly ISeaExporthRepository mRepository;
//         public SeaExporthController(ISeaExporthRepository Repository)
//         {
//             this.mRepository = Repository;
//         }

//         [HttpPost]
//         [Route("GetListAsync")]
//         public async Task<IActionResult> GetListAsync([FromBody] Dictionary<string, object> data)
//         {
//             try
//             {
//                 var records = await this.mRepository.GetListAsync(data);
//                 return Ok(records);
//             }
//             catch (Exception Ex)
//             {
//                 return BadRequest(Lib.getErrorMessage(Ex));
//             }
//         }

//         [HttpGet]
//         [Route("GetRecordAsync")]
//         public async Task<IActionResult> GetRecordAsync(int id)
//         {
//             try
//             {
//                 var RetData = await mRepository.GetRecordAsync(id);
//                 return Ok(RetData);
//             }
//             catch (Exception Ex)
//             {
//                 return BadRequest(Lib.getErrorMessage(Ex));
//             }
//         }
        
//         [HttpGet]
//         [Route("GetDefaultData")]
//         public async Task<IActionResult> GetDefaultData(int id)
//         {
//             try
//             {
//                 var RetData = await mRepository.GetDefaultData(id);
//                 return Ok(RetData);
//             }
//             catch (Exception Ex)
//             {
//                 return BadRequest(Lib.getErrorMessage(Ex));         
//             }
//         }

//         [HttpPost]
//         [Route("SaveAsync")]
//         public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] cargo_sea_exporth_dto rec) // string mark,string package, string desc, int ctr,
//         {
//             try
//             {
//                 var record = await mRepository.SaveAsync(id, mode, rec); // mark, package, desc, ctr,
//                 return Ok(record);
//             }
//             catch (Exception Ex)
//             {
//                 return BadRequest(Lib.getErrorMessage(Ex));
//             }
//         }

//         [HttpGet]
//         [Route("DeleteAsync")]
//         public async Task<IActionResult> DeleteAsync(int id)
//         {
//             try
//             {
//                 var RetData = await mRepository.DeleteAsync(id);
//                 return Ok(RetData);
//             }
//             catch (Exception Ex)
//             {
//                 return BadRequest(Lib.getErrorMessage(Ex));
//             }
//         }

//     }
// }
