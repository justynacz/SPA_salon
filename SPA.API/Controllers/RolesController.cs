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
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/Roles
        [HttpGet]
        public IEnumerable<Role> GetRoles()
        {
            return _roleService.GetList();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleService.GetRoleAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, [FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.RoleId)
            {
                return BadRequest();
            }

            await _roleService.UpdateRoleAsync(role);

            return NoContent();
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] NewRoleModel role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleCreated = await _roleService.CreateRoleAsync(role.Name, role.Description);

            return CreatedAtAction("GetRole", new { id = roleCreated.RoleId }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleService.GetRoleAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            await _roleService.DeleteRoleAsync(role);

            return Ok(role);
        }        
    }
}