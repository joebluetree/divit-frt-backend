using System;
using Common.DTO.Masters;

namespace Masters.Interfaces;

public interface IWiretransmRepository
{
    Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
    Task<mast_wiretransm_dto?> GetRecordAsync(int id);
    Task<mast_wiretransm_dto> SaveAsync(int id, string mode, mast_wiretransm_dto record);
    Task<mast_wiretransm_dto> SaveParentAsync(int id,string mode, mast_wiretransm_dto record);
    Task<Dictionary<string, object>> DeleteAsync(int id);
}
