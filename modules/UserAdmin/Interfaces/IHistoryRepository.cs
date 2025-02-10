using System;
using Common.DTO.UserAdmin;

namespace UserAdmin.Interfaces;

public interface IHistoryRepository
{
    Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    Task<mast_history_dto?> GetRecordAsync(int id);
    Task<mast_history_dto> SaveAsync(int id, string mode, mast_history_dto record);
    Task<Dictionary<string, object>> DeleteAsync(int id);

}
