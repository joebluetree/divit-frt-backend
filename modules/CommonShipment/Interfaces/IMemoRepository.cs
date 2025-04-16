
using Common.DTO.CommonShipment;

namespace CommonShipment.Interfaces
{
    public interface IMemoRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<cargo_memo_dto?> GetRecordAsync(int id);
        Task<List<cargo_memo_dto>> GetMemoRemarksAsync(int id,string ParentType);
        Task<cargo_memo_dto> SaveAsync(int id, string mode, cargo_memo_dto record);
        Task<cargo_memo_dto> SaveParentAsync(int id,string mode, cargo_memo_dto record);
        Task<Dictionary<string, object>> DeleteAsync(int id);

    }
}
