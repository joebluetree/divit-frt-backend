using System;
using Common.DTO.UserAdmin;

namespace UserAdmin.Interfaces;

public interface IHistoryRepository
{
    Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    Task<mast_history_dto?> GetRecordAsync(int id);

}
