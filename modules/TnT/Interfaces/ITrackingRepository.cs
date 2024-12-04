using Common.DTO.Tnt;
using Database.Lib;

namespace TnT.Interfaces
{
    public interface ITrackingRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<tnt_trackm_dto> GetRecordAsync(int id);
        Task<tnt_trackm_dto> SaveAsync(int id, string mode, tnt_trackm_dto record);
        Task<tnt_trackm_dto> SaveParentAsync(int id, string mode, tnt_trackm_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);
        Task<IEnumerable<TrackingEvent>> TestGetLinerTrackingDetailsAsync(int id, string cntrno, int carrier_id, int comp_id);
        Task<string> GetLinerTrackingDetailsOnlineAsync(DataContainer dc, int id, string cntrno, int carrier_id, int comp_id);
        Task<int> SaveTrackingDetailsToDatabase(DataContainer dc, string jsonResponse, int id, string cntrno, int carrier_id, int comp_id);
        Task<IEnumerable<tnt_tracking_data_dto>> GetTrackingDetailsAsync(int trackd_id);
        Task UpdateTrackingAsync(int track_id);
        Task<string> GenerateShipsGoRequestId(string authCode, int id, string cntrno, int carrier_id, int comp_id);
        Task<string> GetShipsGoOnlineAsync(string authCode, string requestId, string cntrno);

    }
}
