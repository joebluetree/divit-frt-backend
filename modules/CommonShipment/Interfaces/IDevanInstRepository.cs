
using Common.DTO.CommonShipment;

namespace CommonShipment.Interfaces
{
    //Name : Sourav V
    //Date : 24/06/2025
    //Remark : Version 1.0
    public interface IDevanInstRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_devan_inst_dto?> GetRecordAsync(int id);
        Task<cargo_devan_inst_dto> GetDefaultData(int id,string parent_type);
        Task<cargo_devan_inst_dto> SaveAsync(int id, string mode, cargo_devan_inst_dto record);
        Task<cargo_devan_inst_dto> SaveParentAsync(int id,string mode, cargo_devan_inst_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
