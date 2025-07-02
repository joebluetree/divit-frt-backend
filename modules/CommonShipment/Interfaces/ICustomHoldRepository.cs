
using Common.DTO.CommonShipment;

namespace CommonShipment.Interfaces
{
    //Name : Sourav V
    //Date : 01/07/2025
    //Remark : Version 1.0
    public interface ICustomHoldRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_custom_hold_dto?> GetRecordAsync(int id);
        Task<cargo_custom_hold_dto?> GetDefaultDataAsync(int id);
        Task<cargo_custom_hold_dto> SaveAsync(int id, string mode, cargo_custom_hold_dto record);
        Task<cargo_custom_hold_dto> SaveParentAsync(int id,string mode, cargo_custom_hold_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
