﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Masters.Interfaces;
using Common.DTO.Masters;
using Database.Lib;
using Microsoft.VisualBasic;

namespace Masters.Controllers
{
    [Authorize]
    [Route("api/param")]
    public class ParamController : Controller
    {
        private readonly IParamRepository mRepository;
        public ParamController(IParamRepository Repository)
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
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] mast_param_dto rec)
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

        // [HttpPost]
        // [Route("GetDownloadPdfAsync")]
        // public async Task<IActionResult> GetDownloadPdfAsync([FromBody] Dictionary<string, object> data)
        // {
        //     try
        //     {
        //         var records = await this.mRepository.GetDownloadPdfAsync(data);
        //         var RetData = File(records.FileStream!, records.ContentType!, records.FileName);
        //         return RetData;
        //     }
        //     catch (Exception Ex)
        //     {
        //         return BadRequest(Lib.getErrorMessage(Ex));
        //     }
        // }
        
        // [HttpPost]
        // [Route("GetDownloadExcelAsync")]
        // public async Task<IActionResult> GetDownloadExcelAsync([FromBody] Dictionary<string, object> data)
        // {
        //     try
        //     {
        //         var records = await this.mRepository.GetDownloadExcelAsync(data);
        //         var RetData = File(records.FileStream!, records.ContentType!, records.FileName);
        //         return RetData;
        //     }
        //     catch (Exception Ex)
        //     {
        //         return BadRequest(Lib.getErrorMessage(Ex));
        //     }
        // }
    }
}
