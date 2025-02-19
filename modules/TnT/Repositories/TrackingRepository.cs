using Database.Lib;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Common.DTO.Tnt;
using TnT.Interfaces;
using Database.Models.BaseTables;
using Database;
using Database.Models.TnT;
using System.Data;
using Database.Lib.Interfaces;
using Common.Lib;

namespace TnT.Repositories
{
    public class TrackingRepository : ITrackingRepository
    {
        private readonly AppDbContext context;
        private readonly HttpClient httpClient;
        private readonly ICommonRepository CommonRepository;
        private DateTime log_date;

        public TrackingRepository(AppDbContext _context, HttpClient _httpClient, ICommonRepository _commonRepository)
        {
            context = _context;
            httpClient = _httpClient;
            CommonRepository = _commonRepository;
        }
        public async Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();

                Page _page = new Page();

                var action = data["action"].ToString();
                if (action == null)
                    action = "search";
                var cntr_no = data["track_cntr_no"].ToString();
                var book_no = data["track_book_no"].ToString();

                var company_id = int.Parse(data["rec_company_id"].ToString()!);

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<tnt_trackm> query = context.tnt_trackm;

                query = query.Where(w => w.rec_company_id == company_id);

                if (cntr_no != "" && cntr_no != null)
                    query = query.Where(w => w.track_cntr_no!.Contains(cntr_no));
                if (book_no != "" && book_no != null)
                    query = query.Where(w => w.track_book_no!.Contains(book_no));

                if (action == "SEARCH")
                {
                    _page.rows = query.Count();
                    _page.pages = Lib.getTotalPages(_page.rows, _page.pageSize);
                    _page.currentPageNo = 1;
                }
                else
                {
                    _page.currentPageNo = Lib.FindPage(action, _page.currentPageNo, _page.pages);
                }

                int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                query = query
                    .OrderBy(c => c.rec_created_date)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new tnt_trackm_dto
                {
                    track_id = e.track_id,
                    track_cntr_no = e.track_cntr_no,
                    track_book_no = e.track_book_no,

                    track_carrier_id = e.track_carrier_id,
                    track_carrier_code = e.param_carrier!.param_code,
                    track_carrier_name = e.param_carrier.param_name,
                    track_carrier_scac = e.param_carrier.param_value1,

                    track_api_type = e.track_api_type,
                    track_request_id = e.track_request_id,

                    track_pol_code = e.track_pol_code,
                    track_pol_name = e.track_pol_name,
                    track_pol_etd = e.track_pol_etd.HasValue ? e.track_pol_etd.Value.ToString(Lib.outputDateFormat) : "",

                    track_pod_code = e.track_pod_code,
                    track_pod_name = e.track_pod_name,

                    track_pod_eta = e.track_pod_eta.HasValue ? e.track_pod_eta.Value.ToString(Lib.outputDateFormat) : "",

                    track_vessel_code = e.track_vessel_code,
                    track_vessel_name = e.track_vessel_name,
                    track_voyage = e.track_voyage,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),


                }).ToListAsync();



                RetData.Add("records", Records);
                RetData.Add("page", _page);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<tnt_trackm_dto> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<tnt_trackm> query = context.tnt_trackm;

                query = query.Where(f => f.track_id == id);

                var Record = await query.Select(e => new tnt_trackm_dto
                {
                    track_id = e.track_id,
                    track_cntr_no = e.track_cntr_no,
                    track_book_no = e.track_book_no,
                    track_trackd_id = e.track_trackd_id,
                    track_carrier_id = e.track_carrier_id,

                    track_api_type = e.track_api_type,
                    track_request_id = e.track_request_id,

                    track_carrier_code = e.param_carrier!.param_code,
                    track_carrier_name = e.param_carrier!.param_name,
                    track_carrier_scac = e.param_carrier!.param_value1,

                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),

                }).FirstOrDefaultAsync() ?? throw new Exception("No Data Found");
                Record.tracking_data = await GetTrackingDetailsAsync(Record.track_trackd_id);

                return Record;

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<tnt_trackm_dto> SaveAsync(int id, string mode, tnt_trackm_dto record_dto)
        {
            try
            {
                log_date = DateTime.UtcNow;

                context.Database.BeginTransaction();
                record_dto = await SaveParentAsync(id, mode, record_dto);
                context.Database.CommitTransaction();
                return record_dto;
            }
            catch (DbUpdateConcurrencyException)
            {
                context.Database.RollbackTransaction();
                throw new Exception("Kindly reload the record, Another User May have modified the same record");
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }
        public async Task<tnt_trackm_dto> SaveParentAsync(int id, string mode, tnt_trackm_dto Record_DTO)
        {
            tnt_trackm? Record;
            try
            {
                if (Record_DTO == null)
                    throw new Exception("No Data Found To Save");
                if (mode == "add")
                {
                    Record = new tnt_trackm();
                    Record.rec_company_id = Record_DTO.rec_company_id;
                    Record.rec_created_by = Record_DTO.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.track_request_id = "";
                }
                else
                {
                    Record = await context.tnt_trackm
                        .Where(f => f.track_id == id)
                        .FirstOrDefaultAsync();
                    if (Record == null)
                        throw new Exception("No Record Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = Record_DTO.rec_version;
                    Record.rec_version++;

                    Record.rec_edited_by = Record_DTO.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                if (mode == "edit")
                    await logHistory(Record, Record_DTO);

                Record.track_cntr_no = Record_DTO.track_cntr_no;
                Record.track_book_no = Record_DTO.track_book_no;
                Record.track_carrier_id = Record_DTO.track_carrier_id;

                DataContainer dc = await this.CommonRepository.GetParamSettings(Record_DTO.track_carrier_id);
                Record.track_api_type = dc.Get<string>("CNTR-TRACKING-TYPE");

                if (Record.track_api_type == "")
                    throw new Exception("Cntr-Tracking-Type Is Not Set");

                if (mode == "add")
                    await context.tnt_trackm.AddAsync(Record);
                context.SaveChanges();
                Record_DTO.track_id = Record.track_id;
                Record_DTO.track_api_type = Record.track_api_type;
                Record_DTO.track_request_id = Record.track_request_id;
                Record_DTO.rec_version = Record.rec_version;
                // Lib.AssignDates2DTO(id, mode, Record, Record_DTO);
                Record_DTO.rec_created_by = Record.rec_created_by;
                Record_DTO.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (Record_DTO.track_id != 0)
                {
                    Record_DTO.rec_edited_by = Record.rec_edited_by;
                    Record_DTO.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }
                return Record_DTO;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "module_name", "Module Name Duplication");
                throw;
            }
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.tnt_trackm
                    .Where(f => f.track_id == id)
                    .FirstOrDefaultAsync();
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    context.Remove(_Record);
                    context.SaveChanges();
                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<IEnumerable<TrackingEvent>> TestGetLinerTrackingDetailsAsync(int id, string cntrno, int carrier_id, int comp_id)
        {
            try
            {
                var baseUrl = "https://api.hlag.com/hlag/external/v2/events/";
                //baseUrl = "https://mock.api-portal.hlag.com/v2/events";

                //var eventType = "SHIPMENT,TRANSPORT,EQUIPMENT";
                var eventType = "TRANSPORT,EQUIPMENT";
                var shipmentEventTypeCodes = "ISSU,CONF";
                var documentTypeCodes = "BKG,TRD";
                var carrierBookingReference = "10816401";
                var equipmentReference = "HLXU8787996";
                var transportEventTypeCodes = "ARRI,DEPA";
                var equipmentEventTypeCodes = "GTIN,GTOT";
                var eventCreatedDateTime = "gte=2021-07-01";
                var limit = 100;
                var sort = "carrierBookingReference:DESC";

                var clientId = "2f89b67a-003c-4f91-9130-80a1a4c8212a";
                var clientSecret = "Hcm8Q~L5QDCa3Y14HaerCR.1jLOs4xBT.~gsOb32";

                equipmentReference = cntrno;

                //sort = "eventDateTime:asc";
                // Build the full URL with query parameters
                var apiUrl = "";
                apiUrl = $"{baseUrl}" +
                         $"?shipmentEventTypeCode={Uri.EscapeDataString(shipmentEventTypeCodes)}" +
                         $"&documentTypeCode={Uri.EscapeDataString(documentTypeCodes)}" +
                         $"&carrierBookingReference={Uri.EscapeDataString(carrierBookingReference)}" +
                         $"&transportEventTypeCode={Uri.EscapeDataString(transportEventTypeCodes)}" +
                         $"&equipmentEventTypeCode={Uri.EscapeDataString(equipmentEventTypeCodes)}" +
                         $"&eventCreatedDateTime={Uri.EscapeDataString(eventCreatedDateTime)}" +
                         $"&limit={limit}" +
                         $"&sort={Uri.EscapeDataString(sort)}";

                apiUrl = $"{baseUrl}" +
                         $"?eventType={Uri.EscapeDataString(eventType)}" +
                         $"&equipmentReference={Uri.EscapeDataString(equipmentReference)}" +
                         $"&limit={limit}" +
                         $"&sort={Uri.EscapeDataString(sort)}";

                apiUrl = $"{baseUrl}" +
                         $"?limit={limit}" +
                         $"&equipmentReference={Uri.EscapeDataString(equipmentReference)}" +
                         $"&sort={Uri.EscapeDataString(sort)}";

                string provider = "";

                if (provider == "CMA")
                {
                    baseUrl = "https://apis.cma-cgm.net/operation/trackandtrace/v1/events";
                }


                apiUrl = $"{baseUrl}" +
                         $"?eventType={Uri.EscapeDataString(eventType)}" +
                         $"&equipmentReference={Uri.EscapeDataString(equipmentReference)}";


                /*
                    eventType=EQUIPMENT&
                    shipmentEventTypeCode=&
                    documentTypeCode=&
                    transportEventTypeCode=&
                    equipmentEventTypeCode=&
                    equipmentReference=HLXU8787996&
                    eventCreatedDateTime=2021-04-01T13%3A12%3A56.000Z&
                    limit=100&
                    sort=carrierBookingReference%3ADESC' `
                */

                apiUrl = $"{baseUrl}" +
                         $"?eventType={Uri.EscapeDataString(eventType)}" +
                         $"&equipmentReference={Uri.EscapeDataString(equipmentReference)}";



                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("accept", "application/json");
                if (provider == "CMA")
                {
                    httpClient.DefaultRequestHeaders.Add("KeyId", "YbElDwUjsHSfirYN7ZEgkw5nqwhgHERW");
                }
                else
                {
                    httpClient.DefaultRequestHeaders.Add("API-Version", "1");
                    httpClient.DefaultRequestHeaders.Add("X-IBM-Client-Id", clientId);
                    httpClient.DefaultRequestHeaders.Add("X-IBM-Client-Secret", clientSecret);
                }
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    string fname = DateTime.Now.ToString("yyyymmdd-HH-mm-ss");
                    System.IO.File.WriteAllText(@"c:\test\" + fname, jsonResponse);

                    //return JsonConvert.DeserializeObject<IEnumerable<TrackingEvent>>(jsonResponse);

                    if (string.IsNullOrWhiteSpace(jsonResponse))
                    {
                        return Enumerable.Empty<TrackingEvent>();
                    }
                    return JsonConvert.DeserializeObject<IEnumerable<TrackingEvent>>(jsonResponse) ?? Enumerable.Empty<TrackingEvent>();
                }
                else
                {
                    throw new HttpRequestException($"Error fetching data: {response.ReasonPhrase}");

                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<string> GenerateToken(DataContainer dc, string cntrno, int carrier_id)
        {
            try
            {
                // Retrieve required settings from the data container
                string apiUrl = dc.Get<string>("CNTR-TRACKING-ACCESS-TOKEN-URL");
                string header = dc.Get<string>("CNTR-TRACKING-ACCESS-TOKEN-HEADER1");
                string accessToken = dc.Get<string>("CNTR-TRACKING-ACCESS-TOKEN");
                string accessTokenExpiry = dc.Get<string>("CNTR-TRACKING-ACCESS-TOKEN-EXPIRY");

                // Validate the header
                if (string.IsNullOrWhiteSpace(header))
                    throw new HttpRequestException($"CNTR-TRACKING-ACCESS-TOKEN-HEADER1 Settings Not Set: {cntrno}");

                // Check if the token is still valid
                if (!string.IsNullOrWhiteSpace(accessTokenExpiry) && !string.IsNullOrWhiteSpace(accessToken))
                {
                    DateTime expiryDate = DateTime.Parse(accessTokenExpiry);
                    if (expiryDate > DbLib.GetDateTime())
                    {
                        return accessToken; // Return the existing token if it hasn't expired
                    }
                }

                // Prepare the request headers and body
                var keyValuePairs = header.Split(',')
                                          .Select(h => h.Split('='))
                                          .Where(data => data.Length == 2)
                                          .Select(data => new KeyValuePair<string, string>(data[0], data[1]))
                                          .ToList();

                var content = new FormUrlEncodedContent(keyValuePairs);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

                HttpResponseMessage response;
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("accept", "application/json");
                    response = await client.PostAsync(apiUrl, content);
                }
                // Send the request

                // Process the response
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<access_token_event>(jsonResponse);

                    accessToken = token?.access_token!;
                    DateTime expiryDate = DbLib.GetDateTime().AddSeconds(token!.expires_in);

                    // Update the token and expiry in the database
                    var tokenRecord = await context.mast_settings
                                                   .Where(w => w.caption == "CNTR-TRACKING-ACCESS-TOKEN" && w.param_id == carrier_id)
                                                   .FirstOrDefaultAsync();

                    if (tokenRecord != null)
                    {
                        tokenRecord.value = accessToken;
                        await context.SaveChangesAsync();
                    }

                    var expiryRecord = await context.mast_settings
                                                    .Where(w => w.caption == "CNTR-TRACKING-ACCESS-TOKEN-EXPIRY" && w.param_id == carrier_id)
                                                    .FirstOrDefaultAsync();

                    if (expiryRecord != null)
                    {
                        expiryRecord.value = expiryDate.ToString("o");
                        await context.SaveChangesAsync();
                    }

                    return accessToken;
                }
                else
                {
                    throw new HttpRequestException($"Error fetching data: {response.ReasonPhrase} - {cntrno}");
                }
            }
            catch (Exception)
            {
                // Optionally, log the exception or rethrow it
                throw;
            }
        }

        void LogResonse(string prefix, string jsonResponse)
        {
            string fname = prefix + "-" + DateTime.Now.ToString("yyyymmdd-HH-mm-ss");
            System.IO.File.WriteAllText(@"c:\test\" + fname, jsonResponse);
        }
        public async Task<string> GetLinerTrackingDetailsOnlineAsync(DataContainer dc, int id, string cntrno, int carrier_id, int comp_id)
        {
            try
            {
                HttpResponseMessage response;
                var jsonResponse = "";

                string key = "";
                string value = "";
                string[] data;
                string baseUrl = dc.Get<string>("CNTR-TRACKING-API-URL");

                var eventType = "TRANSPORT,EQUIPMENT";
                string apiUrl = $"{baseUrl}" +
                                $"?eventType={Uri.EscapeDataString(eventType)}" +
                                $"&equipmentReference={Uri.EscapeDataString(cntrno)}";

                string header = dc.Get<string>("CNTR-TRACKING-API-HEADER1");
                if (header == "")
                    throw new HttpRequestException($"CNTR-TRACKING-API-HEADER1 Settings Not Set : {cntrno}");

                string token_type = dc.Get<string>("CNTR-TRACKING-ACCESS-TOKEN-TYPE");
                string access_token = "";
                if (token_type != "")
                    access_token = await GenerateToken(dc, cntrno, carrier_id);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("accept", "application/json");
                foreach (string str in header.Split(","))
                {
                    data = str.Split(":");
                    if (data.Length == 2)
                    {
                        key = data[0]; value = data[1].Replace("{access_token}", access_token);
                        httpClient.DefaultRequestHeaders.Add(key, value);
                    }
                }
                response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    jsonResponse = await response.Content.ReadAsStringAsync();
                    if (jsonResponse.StartsWith("{\"events\":"))
                    {
                        jsonResponse = jsonResponse.Replace("{\"events\":", "");
                        jsonResponse = jsonResponse.Remove(jsonResponse.Length - 1);
                    }
                    LogResonse(cntrno, jsonResponse);
                    return jsonResponse;
                }
                else
                {
                    throw new HttpRequestException($"Error fetching data: {response.ReasonPhrase} - {cntrno}");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<int> SaveTrackingDetailsToDatabase(DataContainer dc, string jsonResponse, int id, string cntrno, int carrier_id, int comp_id)
        {
            int trackd_id = 0;

            string api_version = dc.Get<string>("CNTR-TRACKING-TYPE");
            if (api_version == "SHIPSGO")
                trackd_id = await SaveTrackingDetailsToDatabaseApi_ShipsGo(jsonResponse, id, cntrno, carrier_id, comp_id);
            else if (api_version == "API-1")
                trackd_id = await SaveTrackingDetailsToDatabaseApi_Version_1(jsonResponse, id, cntrno, carrier_id, comp_id);
            else
                trackd_id = await SaveTrackingDetailsToDatabaseApi(jsonResponse, id, cntrno, carrier_id, comp_id);
            return trackd_id;
        }
        public async Task<int> SaveTrackingDetailsToDatabaseApi_Version_1(string jsonResponse, int id, string cntrno, int carrier_id, int comp_id)
        {
            tnt_tracking_data Record;
            tnt_trackm? mTrackm;
            tnt_trackd mTrackd;


            //IEnumerable<TrackingEvent_Ver_1> trackingEvents = JsonConvert.DeserializeObject<IEnumerable<TrackingEvent_Ver_1>>(jsonResponse);

            IEnumerable<TrackingEvent_Ver_1> trackingEvents;
            if (string.IsNullOrWhiteSpace(jsonResponse))
            {
                trackingEvents = Enumerable.Empty<TrackingEvent_Ver_1>();
            }
            else
            {
                trackingEvents = JsonConvert.DeserializeObject<IEnumerable<TrackingEvent_Ver_1>>(jsonResponse) ?? Enumerable.Empty<TrackingEvent_Ver_1>();
            }


            int trackd_id = 0;
            try
            {
                var latestEventCreatedDateTime = trackingEvents!.Max(e => e.eventDateTime);

                context.Database.BeginTransaction();

                mTrackd = new tnt_trackd();
                mTrackd.trackd_trackm_id = id;
                mTrackd.rec_created_by = "admin";
                mTrackd.rec_company_id = comp_id;
                mTrackd.trackd_last_updated_on = latestEventCreatedDateTime.UtcDateTime;
                await context.tnt_trackd.AddAsync(mTrackd);
                context.SaveChanges();

                trackd_id = mTrackd.trackd_id;

                mTrackm = await context.tnt_trackm
                .Where(f => f.track_id == id)
                .FirstOrDefaultAsync();


                if (mTrackm == null)
                    throw new Exception("Record Not Found");

                mTrackm.track_trackd_id = trackd_id;
                mTrackm.track_last_updated_on = latestEventCreatedDateTime.UtcDateTime;
                context.SaveChanges();

                foreach (var e in trackingEvents)
                {
                    Record = new tnt_tracking_data();
                    Record.tnt_trackm_id = id;
                    Record.tnt_trackd_id = trackd_id;
                    Record.rec_company_id = comp_id;
                    Record.rec_created_by = "admin";

                    Record.tnt_eventCreatedDateTime = e.eventDateTime.Date;
                    Record.tnt_eventDateTime = e.eventDateTime.Date;
                    // UTC
                    Record.tnt_eventCreatedDateTime_utc = e.eventDateTime.UtcDateTime;
                    Record.tnt_eventDateTime_utc = e.eventDateTime.UtcDateTime;

                    Record.tnt_container = e.equipmentReference; // e?.equipmentReference;

                    Record.tnt_transport_mode = e?.modeOfTransportCode;

                    Record.tnt_event_type = e?.eventClassifierCode;
                    Record.tnt_event_confirm_status = "";
                    Record.tnt_status_code = e!.eventTypeCode;
                    Record.tnt_status_name = getStatus(e.eventTypeCode!);
                    Record.tnt_port_code = e.UNLocationCode; //e?.transportCall?.UNLocationCode;
                    Record.tnt_port_name = e.UNLocationCode; //e?.transportCall?.location?.locationName;
                    Record.tnt_port_location = e.otherFacility; //e?.transportCall?.location?.address?.na
                    Record.tnt_vessel = ""; //;e?.transportCall?.vessel?.vesselName;
                    Record.tnt_vessel_imon = e.transportReference; // e?.transportCall?.vessel?.vesselIMONumber;
                    Record.tnt_voyage = e.transportLegReference; // e?.transportCall?.importVoyageNumber;
                    Record.tnt_row_type = "";
                    if (Record.tnt_transport_mode == "1")
                        Record.tnt_transport_mode = "VESSEL";
                    else if (e.eventTypeCode == "GTOT" || e.eventTypeCode == "GTIN")
                        Record.tnt_transport_mode = "TRUCK";

                    await context.tnt_tracking_data.AddAsync(Record);
                    context.SaveChanges();

                }
                context.Database.CommitTransaction();
                return trackd_id;
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }

        }
        public async Task<int> SaveTrackingDetailsToDatabaseApi(string jsonResponse, int id, string cntrno, int carrier_id, int comp_id)
        {
            tnt_tracking_data Record;
            tnt_trackm? mTrackm;
            tnt_trackd mTrackd;

            //IEnumerable<TrackingEvent> trackingEvents = JsonConvert.DeserializeObject<IEnumerable<TrackingEvent>>(jsonResponse);

            IEnumerable<TrackingEvent> trackingEvents = JsonConvert.DeserializeObject<IEnumerable<TrackingEvent>>(jsonResponse) ?? Enumerable.Empty<TrackingEvent>();


            int trackd_id = 0;
            try
            {
                var latestEventCreatedDateTime = trackingEvents.Max(e => e.eventCreatedDateTime);

                context.Database.BeginTransaction();

                mTrackd = new tnt_trackd();
                mTrackd.trackd_trackm_id = id;
                mTrackd.rec_created_by = "admin";
                mTrackd.rec_company_id = comp_id;
                mTrackd.trackd_last_updated_on = latestEventCreatedDateTime.UtcDateTime;
                await context.tnt_trackd.AddAsync(mTrackd);
                context.SaveChanges();

                trackd_id = mTrackd.trackd_id;

                mTrackm = await context.tnt_trackm
                .Where(f => f.track_id == id)
                .FirstOrDefaultAsync();

                if (mTrackm == null)
                    throw new Exception("No Record Found");


                mTrackm.track_trackd_id = trackd_id;
                mTrackm.track_last_updated_on = latestEventCreatedDateTime.UtcDateTime;
                context.SaveChanges();

                foreach (var e in trackingEvents)
                {
                    Record = new tnt_tracking_data();
                    Record.tnt_trackm_id = id;
                    Record.tnt_trackd_id = trackd_id;
                    Record.rec_company_id = comp_id;
                    Record.rec_created_by = "admin";

                    //Record.tnt_eventCreatedDateTime = e.eventCreatedDateTime;
                    //Record.tnt_eventDateTime = e.eventDateTime;
                    // UTC
                    Record.tnt_eventCreatedDateTime_utc = e.eventCreatedDateTime.UtcDateTime;
                    Record.tnt_eventDateTime_utc = e.eventDateTime.UtcDateTime;

                    Record.tnt_row_type = "";

                    Record.tnt_container = e.equipmentReference; // e?.equipmentReference;

                    Record.tnt_transport_mode = e?.transportCall?.modeOfTransport;
                    Record.tnt_event_type = e?.eventClassifierCode;
                    Record.tnt_event_confirm_status = "";

                    if (e.eventType == "TRANSPORT")
                        Record.tnt_status_code = e?.transportEventTypeCode;
                    if (e.eventType == "EQUIPMENT")
                        Record.tnt_status_code = e?.equipmentEventTypeCode;
                    if (e.eventType == "SHIPMENT")
                        Record.tnt_status_code = e?.shipmentEventTypeCode;
                    Record.tnt_status_name = getStatus(Record.tnt_status_code!);

                    Record.tnt_vessel = e?.transportCall?.vessel?.vesselName;
                    Record.tnt_vessel_imon = e?.transportCall?.vessel?.vesselIMONumber;
                    Record.tnt_voyage = e?.transportCall?.importVoyageNumber;
                    if (Record.tnt_voyage == null)
                        Record.tnt_voyage = e?.transportCall?.exportVoyageNumber;

                    Record.tnt_port_code = e?.transportCall?.UNLocationCode;  //e?.transportCall?.UNLocationCode;
                    Record.tnt_port_name = e?.transportCall?.location?.locationName; ; //e?.transportCall?.location?.locationName;
                    Record.tnt_port_location = e?.transportCall?.location?.address?.name; //e?.transportCall?.location?.address?.name


                    await context.tnt_tracking_data.AddAsync(Record);
                    context.SaveChanges();

                }
                context.Database.CommitTransaction();
                return trackd_id;
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
                throw;
            }

        }
        public Nullable<DateTime> getShipsGoMaxDate(IEnumerable<TrackingEvent_ShipsGo> trackingEvents)
        {
            Nullable<DateTime> latestDate = null;

            foreach (var trackingEvent in trackingEvents)
            {
                List<DateTime> actualDates = new List<DateTime>();
                if (trackingEvent.LoadingDate?.IsActual == true)
                    actualDates.Add(trackingEvent.LoadingDate.Date);
                if (trackingEvent.DepartureDate?.IsActual == true)
                    actualDates.Add(trackingEvent.DepartureDate.Date);
                foreach (var tsPort in trackingEvent.TSPorts)
                {
                    if (tsPort.ArrivalDate?.IsActual == true)
                        actualDates.Add(tsPort.ArrivalDate.Date);

                    if (tsPort.DepartureDate?.IsActual == true)
                        actualDates.Add(tsPort.DepartureDate.Date);
                }
                if (trackingEvent.ArrivalDate?.IsActual == true)
                    actualDates.Add(trackingEvent.ArrivalDate.Date);
                if (trackingEvent.DischargeDate?.IsActual == true)
                    actualDates.Add(trackingEvent.DischargeDate.Date);
                if (actualDates.Any())
                {
                    latestDate = actualDates.Max();
                }
            }
            return latestDate;
        }
        public async Task<int> SaveTrackingDetailsToDatabaseApi_ShipsGo(string jsonResponse, int id, string cntrno, int carrier_id, int comp_id)
        {
            tnt_tracking_data Record;
            tnt_trackm? mTrackm;
            tnt_trackd mTrackd;

            IEnumerable<TrackingEvent_ShipsGo> trackingEvents = JsonConvert.DeserializeObject<IEnumerable<TrackingEvent_ShipsGo>>(jsonResponse);

            int trackd_id = 0;
            try
            {
                var latestEventCreatedDateTime = getShipsGoMaxDate(trackingEvents);

                context.Database.BeginTransaction();

                mTrackd = new tnt_trackd();
                mTrackd.trackd_trackm_id = id;
                mTrackd.rec_created_by = "admin";
                mTrackd.rec_company_id = comp_id;
                mTrackd.trackd_last_updated_on = latestEventCreatedDateTime;
                await context.tnt_trackd.AddAsync(mTrackd);
                context.SaveChanges();

                trackd_id = mTrackd.trackd_id;

                mTrackm = await context.tnt_trackm
                .Where(f => f.track_id == id)
                .FirstOrDefaultAsync();

                if (mTrackm == null)
                    throw new Exception("Record Not Found");

                mTrackm.track_trackd_id = trackd_id;
                mTrackm.track_last_updated_on = latestEventCreatedDateTime;
                context.SaveChanges();
                foreach (var e in trackingEvents)
                {
                    await SaveShipsGoRecord(id, trackd_id, comp_id, e, e.LoadingDate.Date, e.ContainerNumber, "VESSEL", e.LoadingDate.IsActual ? "ACT" : "EST", "LOAD", "", "", "", e.Pol);
                    await SaveShipsGoRecord(id, trackd_id, comp_id, e, e.DepartureDate.Date, e.ContainerNumber, "VESSEL", e.DepartureDate.IsActual ? "ACT" : "EST", "DEPA", "", "", "", e.Pol);
                    foreach (var t in e.TSPorts!)
                    {
                        await SaveShipsGoRecord(id, trackd_id, comp_id, e, t.ArrivalDate.Date, e.ContainerNumber, "VESSEL", e.ArrivalDate.IsActual ? "ACT" : "EST", "ARRI", t.Vessel, t.VesselIMO, t.VesselVoyage, t.Port);
                        await SaveShipsGoRecord(id, trackd_id, comp_id, e, t.DepartureDate.Date, e.ContainerNumber, "VESSEL", e.DepartureDate.IsActual ? "ACT" : "EST", "DEPA", t.Vessel, t.VesselIMO, t.VesselVoyage, t.Port);
                    }
                    await SaveShipsGoRecord(id, trackd_id, comp_id, e, e.ArrivalDate.Date, e.ContainerNumber, "VESSEL", e.ArrivalDate.IsActual ? "ACT" : "EST", "ARRI", e.Vessel, e.VesselIMO, e.VesselVoyage, e.Pod);
                    await SaveShipsGoRecord(id, trackd_id, comp_id, e, e.DischargeDate.Date, e.ContainerNumber, "VESSEL", e.DischargeDate.IsActual ? "ACT" : "EST", "DISC", e.Vessel, e.VesselIMO, e.VesselVoyage, e.Pod);
                }
                context.Database.CommitTransaction();
                return trackd_id;
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }

        private async Task SaveShipsGoRecord(int id, int trackd_id, int comp_id, TrackingEvent_ShipsGo e, DateTime dt, string cntrno, string transportmode, string event_type, string status_code,
            string vesselName, string imon, string voyage, string port)
        {
            tnt_tracking_data Record = new tnt_tracking_data();
            Record.tnt_trackm_id = id;
            Record.tnt_trackd_id = trackd_id;
            Record.rec_company_id = comp_id;
            Record.rec_created_by = "admin";

            Record.tnt_eventCreatedDateTime = dt;
            Record.tnt_eventDateTime = dt;
            // UTC
            Record.tnt_eventCreatedDateTime_utc = dt.ToUniversalTime();
            Record.tnt_eventDateTime_utc = dt.ToUniversalTime();

            Record.tnt_transport_mode = transportmode;
            Record.tnt_event_type = event_type;
            Record.tnt_event_confirm_status = "";

            Record.tnt_container = cntrno;
            Record.tnt_status_code = status_code;
            Record.tnt_status_name = getStatus(status_code);
            Record.tnt_vessel = vesselName;
            Record.tnt_vessel_imon = imon;
            Record.tnt_voyage = voyage;
            Record.tnt_port_code = port;
            Record.tnt_port_name = port;
            Record.tnt_port_location = port;
            Record.tnt_row_type = "";

            Record.rec_created_date = DbLib.GetDateTime();

            await context.tnt_tracking_data.AddAsync(Record);
            context.SaveChanges();
        }

        public async Task<IEnumerable<tnt_tracking_data_dto>> GetTrackingDetailsAsync(int trackd_id)
        {
            try
            {
                var timezone = "India Standard Time";
                IQueryable<tnt_tracking_data> query = context.tnt_tracking_data;
                query = query.Where(f => f.tnt_trackd_id == trackd_id)
                             .OrderBy(c => c.tnt_eventDateTime);

                var Records = await query
                .Select(e => new tnt_tracking_data_dto
                {
                    tnt_track_id = e.track_id,
                    tnt_trackm_id = e.tnt_trackm_id,
                    tnt_trackd_id = e.tnt_trackd_id,

                    tnt_event_date = ConvertUtcToTimeZone(e.tnt_eventCreatedDateTime_utc, timezone).ToString("yyyy-MM-dd"),
                    tnt_date = ConvertUtcToTimeZone(e.tnt_eventDateTime_utc, timezone).ToString("yyyy-MM-dd"),


                    tnt_transport_mode = e.tnt_transport_mode,
                    tnt_event_type = e.tnt_event_type,
                    tnt_event_confirm_status = e.tnt_event_confirm_status,

                    tnt_container = e.tnt_container,
                    tnt_status_code = e.tnt_status_code,
                    tnt_status_name = e.tnt_status_name,
                    tnt_port_code = e.tnt_port_code,
                    tnt_port_name = e.tnt_port_name,
                    tnt_port_location = e.tnt_port_location,
                    tnt_vessel = e.tnt_vessel,
                    tnt_vessel_imon = e.tnt_vessel_imon,
                    tnt_voyage = e.tnt_voyage,
                    tnt_row_type = e.tnt_row_type
                }).ToListAsync();
                return Records;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task UpdateTrackingAsync(int track_id)
        {
            try
            {
                int pod_row_id = 0;
                string pol_code = "";
                var timezone = "India Standard Time";

                var mTrackm = await context.tnt_trackm
                .Where(f => f.track_id == track_id)
                .FirstOrDefaultAsync();

                int trackd_id = mTrackm.track_trackd_id;

                var query = context.tnt_tracking_data
                        .Where(c => c.tnt_trackd_id == trackd_id)
                        .OrderBy(c => c.tnt_eventDateTime);

                var records = await query.ToListAsync();

                foreach (var Record in records)
                {
                    Record.tnt_row_type = "";
                    if (Record.tnt_transport_mode == "VESSEL")
                    {
                        Record.tnt_row_type = "VESSEL";
                        if (pol_code == "" && Record.tnt_status_code == "DEPA")
                        {
                            pol_code = Record.tnt_port_code;
                            mTrackm.track_pol_code = Record.tnt_port_code;
                            mTrackm.track_pol_name = Record.tnt_port_name;
                            mTrackm.track_pol_etd = DateTime.Parse(ConvertUtcToTimeZone(Record.tnt_eventDateTime_utc, timezone).ToString("yyyy-MM-dd"));

                            mTrackm.track_vessel_code = Record.tnt_vessel_imon;
                            mTrackm.track_vessel_name = Record.tnt_vessel;
                            mTrackm.track_voyage = Record.tnt_voyage;

                            Record.tnt_row_type = "POL";

                        }
                        if (Record.tnt_status_code == "ARRI")
                        {
                            pod_row_id = Record.track_id;
                            mTrackm.track_pod_code = Record.tnt_port_code;
                            mTrackm.track_pod_name = Record.tnt_port_name;
                            mTrackm.track_pod_eta = DateTime.Parse(ConvertUtcToTimeZone(Record.tnt_eventDateTime_utc, timezone).ToString("yyyy-MM-dd"));

                            if (Record.tnt_vessel != null || Record.tnt_vessel_imon != null)
                            {
                                mTrackm.track_vessel_code = Record.tnt_vessel_imon;
                                mTrackm.track_vessel_name = Record.tnt_vessel;
                                mTrackm.track_voyage = Record.tnt_voyage;
                            }
                        }
                    }
                }

                var detrecord = records.Find(r => r.track_id == pod_row_id);
                if (detrecord != null)
                {
                    detrecord.tnt_row_type = "POD";
                }

                context.Database.BeginTransaction();
                context.SaveChanges();
                context.Database.CommitTransaction();
            }
            catch (Exception Ex)
            {
                context.Database.RollbackTransaction();
                throw new Exception(Ex.Message.ToString());
            }
        }
        public static string getFacility(string code)
        {
            string mcode = code;
            if (code == "BORD")
                mcode = "Border";
            if (code == "CLOC")
                mcode = "Customer Location";
            if (code == "COFS")
                mcode = "Container Freight Station";
            if (code == "OFFD")
                mcode = "Off Stock Storage";
            if (code == "DEPO")
                mcode = "Depot";
            if (code == "INTE")
                mcode = "Inland Terminal";
            if (code == "POTE")
                mcode = "Port Terminal";
            if (code == "RAMP")
                mcode = "Ramp";
            if (code == "WAYP")
                mcode = "WayPoint";
            return mcode;
        }
        public static string getStatus(string code)
        {
            string mcode = code;

            if (code == "ARRI")
                mcode = "Arrived";
            if (code == "DEPA")
                mcode = "Departed";
            if (code == "LOAD")
                mcode = "Loaded";
            if (code == "DISC")
                mcode = "Discharged";
            if (code == "GTIN")
                mcode = "Gated In";
            if (code == "GTOT")
                mcode = "Gated Out";
            if (code == "STUF")
                mcode = "Stuffed";
            if (code == "STRP")
                mcode = "Stripped";
            if (code == "PICK")
                mcode = "Pick Up";
            if (code == "AVPU")
                mcode = "Available For Pick-Up";
            if (code == "DROP")
                mcode = "Drop Off";
            if (code == "AVDO")
                mcode = "Available For Drop-Off";
            if (code == "INSP")
                mcode = "Inspected";
            if (code == "RSEA")
                mcode = "Resealed";
            if (code == "RMVD")
                mcode = "Removed";
            if (code == "CUSS")
                mcode = "Customs Selected For Scan";
            if (code == "CUSI")
                mcode = "Customs Selected For Inspection";
            if (code == "CUSR")
                mcode = "Customs Released";
            if (code == "CROS")
                mcode = "Crossed";
            return mcode;
        }
        public static DateTime ConvertUtcToTimeZone(DateTime utcDateTime, string timeZoneId)
        {
            /*
            // Ensure the input DateTime is in UTC
            if (utcDateTime.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("The provided DateTime must be in UTC.", nameof(utcDateTime));
            }
            */
            // Find the target time zone
            TimeZoneInfo timeZone;
            try
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }
            catch (TimeZoneNotFoundException)
            {
                throw new ArgumentException($"The time zone ID '{timeZoneId}' is not valid.", nameof(timeZoneId));
            }
            catch (InvalidTimeZoneException)
            {
                throw new ArgumentException($"The time zone ID '{timeZoneId}' is not recognized or invalid.", nameof(timeZoneId));
            }

            // Convert the UTC DateTime to the specified time zone
            DateTime convertedDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);

            return convertedDateTime;
        }

        // Save tracking data into shipsgo server and get the request id
        public async Task<string> GenerateShipsGoRequestId(string authcode, int id, string cntrno, int carrier_id, int comp_id)
        {
            try
            {
                // Retrieve required settings from the data container
                string apiUrl = "https://shipsgo.com/api/v1.2/ContainerService/PostContainerInfo";

                string request_id = "";

                var track_record = await context.tnt_trackm
                        .Where(f => f.track_id == id)
                        .FirstOrDefaultAsync() ?? throw new Exception("No Data Found");

                request_id = track_record?.track_request_id ?? "";

                if (request_id != "")
                    return request_id!;

                var record = await context.mast_param
                            .Where(f => f.param_id == carrier_id)
                            .FirstOrDefaultAsync();

                string carrier_code = record?.param_value1 ?? "";

                // Prepare the request headers and body
                var keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("authCode", authcode);
                keyValuePairs.Add("containerNumber", cntrno);
                keyValuePairs.Add("shippingLine", carrier_code!);

                var content = new FormUrlEncodedContent(keyValuePairs);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

                HttpResponseMessage response;
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    response = await client.PostAsync(apiUrl, content);
                }
                // Process the response
                if (response.IsSuccessStatusCode)
                {
                    request_id = await response.Content.ReadAsStringAsync();
                    track_record.track_request_id = request_id;
                    context.SaveChanges();
                    return request_id;
                }
                else
                {
                    throw new HttpRequestException($"Error fetching data: {response.ReasonPhrase} - {cntrno}");
                }
            }
            catch (Exception)
            {
                // Optionally, log the exception or rethrow it
                throw;
            }
        }

        // Read Tracking Data from shipsgo server
        public async Task<string> GetShipsGoOnlineAsync(string authCode, string requestId, string cntrno)
        {
            try
            {
                HttpResponseMessage response;
                string baseUrl = "https://shipsgo.com/api/v1.2/ContainerService/GetContainerInfo/";
                var jsonResponse = "";
                string apiUrl = $"{baseUrl}" +
                                $"?authCode={Uri.EscapeDataString(authCode)}" +
                                $"&requestId={Uri.EscapeDataString(requestId)}" +
                                $"&mapPoint=true";
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    response = await client.GetAsync(apiUrl);
                }
                if (response.IsSuccessStatusCode)
                {
                    jsonResponse = await response.Content.ReadAsStringAsync();
                    LogResonse(requestId, jsonResponse);
                    return jsonResponse;
                }
                else
                {
                    throw new HttpRequestException($"Error fetching data: {response.ReasonPhrase} - {requestId}");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task logHistory(tnt_trackm old_record, tnt_trackm_dto record_dto)
        {
            var new_record = new tnt_trackm
            {
                track_id = record_dto.track_id,
                track_book_no = record_dto.track_book_no,
                track_cntr_no = record_dto.track_cntr_no,
                // track_carrier_id = record_dto.track_carrier_name,
            };

            await new LogHistory<tnt_trackm>(context)
                .Table("tnt_trackm", log_date)
                .PrimaryKey("track_id", record_dto.track_id)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0 , record_dto.rec_created_by!)
                .TrackColumn("track_book_no", "booking-no")
                .TrackColumn("track_cntr_no", "container-no")
                .SetRecord(old_record, new_record)
                .LogChangesAsync();
        }

    }
}
