using Microsoft.EntityFrameworkCore;
using SPA.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public class LoginService: ILoginService
    {
        private readonly SPAContext _context;
        public LoginService(SPAContext context)
        {
            _context = context;
        }

        public async Task ChangePasswordAsync(int loginId, string newPassword)
        {
            var login = await GetLoginAsync(loginId);
            login.Password = newPassword;
            _context.Entry(login).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<Login> CreateLoginAsync(string username, string password)
        {
            var loginToAdd = new Login()
            {
                Username = username,
                Password = password,
                Active = true
            };

            var loginCreated = await _context.Login.AddAsync(loginToAdd);
            await _context.SaveChangesAsync();
            return loginCreated.Entity;
        }

        public async Task DeleteLoginAsync(Login login)
        {
            _context.Login.Remove(login);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Login> GetList()
        {
            return _context.Login;
        }

        public async Task<Login> GetLoginAsync(int loginID)
        {
            var login = await _context.Login.FindAsync(loginID);
            return login;
        }
    }
}
