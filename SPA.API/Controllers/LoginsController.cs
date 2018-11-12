using Microsoft.AspNetCore.Mvc;
using SPA.API.Models;
using SPA.Server.Models;
using SPA.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginsController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: api/Logins
        [HttpGet]
        public IEnumerable<Login> GetLogin()
        {
            return _loginService.GetList();
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _loginService.GetLoginAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        // PUT: api/Logins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangePassword([FromRoute] int id, [FromBody] ChangePasswordModel changePasswordModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != changePasswordModel.LoginId)
                return BadRequest();

            if (changePasswordModel.NewPassword != changePasswordModel.NewPasswordRepeat)
                return BadRequest();

            var login = await _loginService.GetLoginAsync(id);

            if (login.Password != changePasswordModel.OldPassword)
                return BadRequest();

            await _loginService.ChangePasswordAsync(id, changePasswordModel.NewPassword);

            return NoContent();
        }

        // POST: api/Logins
        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] NewLoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var loginCreated = await _loginService.CreateLoginAsync(login.Username, login.Password);

            return CreatedAtAction("GetLogin", new { id = loginCreated.LoginId }, loginCreated);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _loginService.GetLoginAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            await _loginService.DeleteLoginAsync(login);

            return Ok(login);
        }
    }
}