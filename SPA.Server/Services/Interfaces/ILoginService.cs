using SPA.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public interface ILoginService
    {
        IEnumerable<Login> GetList();
        Login Authenticate(string username, string password);
        Task<Login> GetLoginAsync(int loginID);
        Task<Login> CreateLoginAsync(string username, string password);
        Task ChangePasswordAsync(int loginId, string newPassword);
        Task DeleteLoginAsync(Login login);
    }
}
