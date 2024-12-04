using Database.Models.UserAdmin;

namespace UserAdmin.Interfaces
{
    public interface IAuthRepository
    {
        Task<mast_userm?> AuthenticateAsync(string username, string password);

        Task<Dictionary<string, object>> BranchLoginAsync(Dictionary<string, object> data);

        Task<Dictionary<string, object>> GetBranchListAsync(Dictionary<string, object> data);

    }

}
