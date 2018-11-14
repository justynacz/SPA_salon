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
    public class GlobalTermsController : ControllerBase
    {
        private readonly IGlobalTermService _globalTermService;

        public GlobalTermsController(IGlobalTermService globalTermService)
        {
            _globalTermService = globalTermService;
        }

        /// <summary>
        /// Gets list of global terms.
        /// </summary> 
        /// <response code="200">Returns the list of global terms</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<GlobalTerm> GetGlobalTerms()
        {
            return _globalTermService.GetList();
        }

        /// <summary>
        /// Gets global term with a specific id.
        /// </summary>
        /// <param name="id">Global term id</param>  
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the global term cannot be found</response>
        /// <response code="200">Returns the global term</response>
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetGlobalTerm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var globalTerm = await _globalTermService.GetGlobalTermAsync(id);

            if (globalTerm == null)
            {
                return NotFound();
            }

            return Ok(globalTerm);
        }

        /// <summary>
        /// Updates global term.
        /// </summary>
        /// <param name="id">Global term id</param>  
        /// <param name="globalTerm">Global term entity</param>
        /// <response code="400">If the request is bad or global term ids do not match</response>
        /// <response code="204">Inform about success update</response>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateGlobalTerm([FromRoute] int id, [FromBody] GlobalTerm globalTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != globalTerm.GlobalTermId)
            {
                return BadRequest();
            }

            await _globalTermService.UpdateGlobalTermAsync(globalTerm);

            return NoContent();
        }

        /// <summary>
        /// Creates global term
        /// </summary>
        /// <param name="globalTerm">New global term model</param>  
        /// <response code="400">If the request is bad</response>
        /// <response code="201">Returns created global term</response>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateGlobalTerm([FromBody] NewGlobalTermModel globalTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var globalTermCreated = await _globalTermService.CreateGlobalTermAsync(globalTerm.DateFrom, globalTerm.DateTo, globalTerm.OpenSaloon, globalTerm.Description);

            return CreatedAtAction("GetGlobalTerm", new { id = globalTermCreated.GlobalTermId }, globalTerm);
        }

        /// <summary>
        /// Deletes global term with a specific id.
        /// </summary>
        /// <param name="id">Global term to delete id</param>  
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the global term cannot be found</response>
        /// <response code="200">Returns deleted global term</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteGlobalTerm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var globalTerm = await _globalTermService.GetGlobalTermAsync(id);
            if (globalTerm == null)
            {
                return NotFound();
            }

            await _globalTermService.DeleteGlobalTermAsync(globalTerm);

            return Ok(globalTerm);
        }
    }
}