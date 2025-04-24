using Common.DTO.CommonShipment;

namespace CommonShipment.Interfaces
{

    //Name : Alen Cherian
    //Date : 22/04/2025
    //Remark : Version 1.0

    public interface IMessengerSlipRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_slip_dto?> GetRecordAsync(int id);
        Task<cargo_slip_dto?> GetDefaultDataAsync(int id);
        Task<cargo_slip_dto> SaveAsync(int id, string mode, cargo_slip_dto record);
        Task<cargo_slip_dto> SaveParentAsync(int id, string mode, cargo_slip_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
