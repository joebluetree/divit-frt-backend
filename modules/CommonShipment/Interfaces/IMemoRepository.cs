
using Common.DTO.CommonShipment;

namespace CommonShipment.Interfaces
{
    //Name : Sourav V
    //Date : 09/04/2025
    //Remark : Version 1.0
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
