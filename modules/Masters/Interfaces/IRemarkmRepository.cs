using System;
using Common.DTO.Masters;

namespace Masters.Interfaces;

public interface IRemarkmRepository
{
    Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    Task<mast_remarkm_dto?> GetRecordAsync(int id);
    Task<mast_remarkm_dto> SaveAsync(int id, string mode, mast_remarkm_dto record);

    Task<mast_remarkm_dto> SaveParentAsync(int id,string mode, mast_remarkm_dto record);
    Task<Dictionary<string, object>> DeleteAsync(int id);
}
