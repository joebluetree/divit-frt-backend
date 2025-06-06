using System;
using Common.DTO.UserAdmin;


namespace UserAdmin.Interfaces;

public interface IGenRemarkmRepository
{
    Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    Task<List<gen_remarkm_dto>> GetDetailsAsync(int? id, string? parent_type);
    Task<gen_remarkm_dto?> GetRecordAsync(int id);
    Task<gen_remarkm_dto> SaveAsync(int id, string mode, gen_remarkm_dto record);
    Task<gen_remarkm_dto> SaveParentAsync(int id, string mode, gen_remarkm_dto record);
    Task<Dictionary<string, object>> DeleteAsync(int id);
}
