using Common.DTO.CommonShipment;

namespace CommonShipment.Interfaces
{

    //Name : Sourav V
    //Date : 17/04/2025
    //Remark : Version 1.0
    // version 2- GetDetail added

    public interface IDeliveryOrderRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_delivery_order_dto?> GetRecordAsync(int id, string parent_type);
        Task<cargo_delivery_order_dto?> GetDefaultDataAsync(int id,string parent_type);
        Task<List<cargo_delivery_order_dto>> GetDetailsAsync(int id, string parent_type);
        Task<cargo_delivery_order_dto> SaveAsync(int id, string mode, cargo_delivery_order_dto record);
        Task<cargo_delivery_order_dto> SaveParentAsync(int id, string mode, cargo_delivery_order_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
