using SPA.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetList();
        Task<Role> GetRoleAsync(int roleID);
        Task<Role> CreateRoleAsync(string name, string description);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Role role);
    }
}
