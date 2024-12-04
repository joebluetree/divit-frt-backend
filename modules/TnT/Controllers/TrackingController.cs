using Database.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Common.DTO.Tnt;
using TnT.Interfaces;
using Newtonsoft.Json;
using Database.Lib.Interfaces;
using Database.Lib.Repositories;


namespace Tnt.Controllers
{
    [Authorize]
    [Route("api/tnt")]
    public class TrackingController : Controller
    {
        private readonly ITrackingRepository mRepository;
        private readonly ICommonRepository commonRepository;

        public TrackingController(ITrackingRepository trackingRepository, ICommonRepository _commonRepository)
        {
            mRepository = trackingRepository;
            commonRepository = _commonRepository;
        }

        [HttpPost]
        [Route("GetListAsync")]
        public async Task<IActionResult> GetListAsync([FromBody] Dictionary<string, object> data)
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
                await mRepository.UpdateTrackingAsync(id);
                return Ok(RetData);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync(int id, string mode, [FromBody] tnt_trackm_dto rec)
        {
            try
            {
                var Record = await mRepository.SaveAsync(id, mode, rec);

                return Ok(Record);
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

        [HttpPost]
        [Route("GetTrackingDetails")]
        public async Task<IActionResult> GetTrackingDetails([FromBody] Dictionary<string, object> data)
        {
            try
            {
                int id = int.Parse(data["id"].ToString()!);
                string cntrno = data["cntr"].ToString()!;
                int comp_id = int.Parse(data["comp_id"].ToString()!);
                int carrier_id = int.Parse(data["carrier_id"].ToString()!);
                int trackd_id = 0;

                string track_api_type = data["track_api_type"].ToString()!;
                string track_request_id = data["track_request_id"]?.ToString()!;

                DataContainer dc = await commonRepository.GetParamSettings(carrier_id);

                //IEnumerable < TrackingEvent >  trackingEvents;
                //trackingEvents = getData(@"c:\test\20241316-17-13-59");
                //trackingEvents = await mRepository.TestGetLinerTrackingDetailsAsync(id, cntrno,carrier_id,  comp_id);
                if (track_api_type == "SHIPSGO")
                {
                    DataContainer dc_company = await commonRepository.GetCompanySettings(comp_id);
                    string authcode = dc_company.Get<string>("SHIPSGO-ID");
                    track_request_id = await mRepository.GenerateShipsGoRequestId(authcode, id, cntrno, carrier_id, comp_id);
                    var jsonResponse = await mRepository.GetShipsGoOnlineAsync(authcode, track_request_id, cntrno);
                    //var jsonResponse = getTextData(@"c:\\test\SEGU9471335.json");
                    if (jsonResponse != null)
                    {
                        trackd_id = await mRepository.SaveTrackingDetailsToDatabase(dc, jsonResponse, id, cntrno, carrier_id, comp_id);
                        await mRepository.UpdateTrackingAsync(id);
                    }
                }
                else
                {
                    var jsonResponse = await mRepository.GetLinerTrackingDetailsOnlineAsync(dc, id, cntrno, carrier_id, comp_id);
                    if (jsonResponse != null)
                    {
                        trackd_id = await mRepository.SaveTrackingDetailsToDatabase(dc, jsonResponse, id, cntrno, carrier_id, comp_id);
                        await mRepository.UpdateTrackingAsync(id);
                    }
                }
                var tracking_data = await mRepository.GetTrackingDetailsAsync(trackd_id);
                return Ok(tracking_data);
                //return Ok(trackingEvents);
            }
            catch (Exception Ex)
            {
                return BadRequest(Lib.getErrorMessage(Ex));
            }
        }

        // IEnumerable<TrackingEvent> getData_old(string fname)
        // {
        //     return JsonConvert.DeserializeObject<IEnumerable<TrackingEvent>>(System.IO.File.ReadAllText(fname));
        // }

        IEnumerable<TrackingEvent> GetData(string fname)
        {
            if (string.IsNullOrEmpty(fname))
            {
                throw new ArgumentNullException(nameof(fname), "File name cannot be null or empty.");
            }

            if (!System.IO.File.Exists(fname))
            {
                throw new FileNotFoundException($"The file '{fname}' does not exist.");
            }

            var fileContent = System.IO.File.ReadAllText(fname);
            if (string.IsNullOrWhiteSpace(fileContent))
            {
                throw new InvalidOperationException("The file is empty or contains only whitespace.");
            }

            try
            {
                var data = JsonConvert.DeserializeObject<IEnumerable<TrackingEvent>>(fileContent);
                if (data == null)
                {
                    throw new InvalidOperationException("Failed to deserialize file content into the expected structure.");
                }

                return data;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("An error occurred while deserializing the JSON content.", ex);
            }
        }


        string getTextData(string fname)
        {
            return System.IO.File.ReadAllText(fname);
        }

    }
}
