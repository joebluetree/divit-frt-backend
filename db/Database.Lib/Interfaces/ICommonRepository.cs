using Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Reflection;

namespace Database.Lib.Interfaces
{
    public interface ICommonRepository
    {
        Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data);
        Task<long> GetSequenceAsync(string name);
        Task<DataContainer> GetParamSettings(int id, string caption = "");
        
        Task<DataContainer> GetCompanySettings(int id,string caption = "");
        Task<DataContainer> GetBranchSettings(int id, string caption = "");



    }


}
