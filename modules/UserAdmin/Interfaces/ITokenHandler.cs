using Database.Models.UserAdmin;
using Common.UserAdmin.DTO;
namespace UserAdmin.Interfaces
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(mast_userm user);
    }
}
