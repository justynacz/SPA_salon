using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SPA.API.Models;
using SPA.Server.Models;
using SPA.Server.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SPA.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginsController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <response code="400">If the request is bad</response>
        /// <response code="200">Returns the login</response>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult Authenticate([FromBody]AuthenticateModel authenticateModel)
        {
            var login = _loginService.Authenticate(authenticateModel.Username, authenticateModel.Password);

            if (login == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Some secret key for authentication");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,login.LoginId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = login.LoginId,
                Username = login.Username,
                Token = tokenString
            });
        }

        /// <summary>
        /// Gets list of logins
        /// </summary>
        /// <response code="200">Returns the list of logins</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Login> GetLogins()
        {
            return _loginService.GetList();
        }

        /// <summary>
        /// Gets login with a specific id.
        /// </summary>
        /// <param name="id">Login id</param>  
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the login cannot be found</response>
        /// <response code="200">Returns the login</response>
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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

        /// <summary>
        /// Changes user password.
        /// </summary>
        /// <param name="id">Client id</param>
        /// <param name="changePasswordModel">Change password model</param>  
        /// <response code="400">If the request is bad or login ids do not match or repeat of new password is not the same as new password or old password is invalid</response>
        /// <response code="204">Inform about success update</response>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
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

        /// <summary>
        /// Creates login.
        /// </summary>
        /// <param name="login">New login model</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="201">Returns created login</response>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateLogin([FromBody] NewLoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var loginCreated = await _loginService.CreateLoginAsync(login.Username, login.Password);

            return CreatedAtAction("GetLogin", new { id = loginCreated.LoginId }, loginCreated);
        }

        /// <summary>
        /// Deletes login with a specific id.
        /// </summary>
        /// <param name="id">Login to delete id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the login cannot be found</response>
        /// <response code="200">Returns deleted login</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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