
using Common.DTO.OtherOp;

namespace OtherOp.Interfaces
{
    public interface IOtherOpRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_otherop_dto?> GetRecordAsync(int id);
        Task<cargo_otherop_dto> SaveAsync(int id, string mode, cargo_otherop_dto record);

        Task<cargo_otherop_dto> SaveParentAsync(int id,string mode, cargo_otherop_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
