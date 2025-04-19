using Common.DTO.CommonShipment;

namespace CommonShipment.Interfaces
{

    //Name : Sourav V
    //Date : 17/04/2025
    //Remark : Version 1.0

    public interface IDelvOrderRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_delivery_order_dto?> GetRecordAsync(int id);
        // Task<cargo_delivery_order_dto?> GetDefaultDataAsync(int id);
        Task<cargo_delivery_order_dto> SaveAsync(int id, string mode, cargo_delivery_order_dto record);
        Task<cargo_delivery_order_dto> SaveParentAsync(int id, string mode, cargo_delivery_order_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
