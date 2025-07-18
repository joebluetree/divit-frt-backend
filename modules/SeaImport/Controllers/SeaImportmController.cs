﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Common.DTO.Masters;
using Database.Lib;
using SeaImport.Interfaces;
using Common.DTO.SeaImport;

namespace SeaImport.Controllers
{
    [Authorize]
    [Route("api/SeaImport/seaimportm")]
    public class SeaImportmController : Controller
    {
        private readonly ISeaImportmRepository mRepository;
        public SeaImportmController(ISeaImportmRepository Repository)
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
        public async Task<IActionResult> GetDefaultData()
        {
            try
            {
                var RetData = await mRepository.GetDefaultData();
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }
        
        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] cargo_sea_importm_dto rec)
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
