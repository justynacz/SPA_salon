using Microsoft.AspNetCore.Mvc;
using SPA.API.Models;
using SPA.Server.Models;
using SPA.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Gets list of roles.
        /// </summary>
        /// <response code="200">Returns the list of roles</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Role> GetRoles()
        {
            return _roleService.GetList();
        }

        /// <summary>
        /// Gets role with a specific id.
        /// </summary>
        /// <param name="id">Role id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the role cannot be found</response>
        /// <response code="200">Returns the role</response>
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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

        /// <summary>
        /// Updates role.
        /// </summary>
        /// <param name="id">Role id</param>
        /// <param name="role">Role entity</param>
        /// <response code="400">If the request is bad or role ids do not match</response>
        /// <response code="204">Inform about success update</response>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
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

        /// <summary>
        /// Creates role.
        /// </summary>
        /// <param name="role">New role model</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="201">Returns created role</response>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateRole([FromBody] NewRoleModel role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleCreated = await _roleService.CreateRoleAsync(role.Name, role.Description);

            return CreatedAtAction("GetRole", new { id = roleCreated.RoleId }, role);
        }

        /// <summary>
        /// Deletes role with a specific id.
        /// </summary>
        /// <param name="id">Role to delete id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the role cannot be found</response>
        /// <response code="200">Returns deleted role</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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