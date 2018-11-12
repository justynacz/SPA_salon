using Microsoft.EntityFrameworkCore;
using SPA.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public class RoleService : IRoleService
    {
        private readonly SPAContext _context;
        public RoleService(SPAContext context)
        {
            _context = context;
        }
        public async Task<Role> CreateRoleAsync(string name, string description)
        {
            var roleToAdd = new Role()
            {
                Name = name,
                Description = description
            };
            var roleCreated = await _context.Role.AddAsync(roleToAdd);
            await _context.SaveChangesAsync();
            return roleCreated.Entity;
        }

        public async Task DeleteRoleAsync(Role role)
        {
            _context.Role.Remove(role);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Role> GetList()
        {
            return _context.Role;
        }

        public async Task<Role> GetRoleAsync(int roleID)
        {
            var role = await _context.Role.FindAsync(roleID);
            return role;
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
