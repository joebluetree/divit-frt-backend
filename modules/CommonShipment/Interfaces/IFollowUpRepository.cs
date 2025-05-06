using Common.DTO.CommonShipment;

namespace CommonShipment.Interfaces
{
    //Name : Alen Cherian
    //Date : 09/04/2025
    //Remark : Version 1.0

    public interface IFollowUpRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_followup_dto?> GetRecordAsync(int id, string parent_type);
        Task<cargo_followup_dto?> GetDefaultDataAsync(int id);
        Task<List<cargo_followup_dto>> GetDetailsAsync(int id, string parent_type);
        Task<cargo_followup_dto> SaveAsync(int id, string mode, cargo_followup_dto record);
        Task<cargo_followup_dto> SaveParentAsync(int id, string mode, cargo_followup_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);
    }
}