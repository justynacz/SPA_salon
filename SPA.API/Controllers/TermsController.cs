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
    public class TermsController : ControllerBase
    {
        private readonly ITermService _termService;

        public TermsController(ITermService termService)
        {
            _termService = termService;
        }

        /// <summary>
        /// Gets list of terms.
        /// </summary>
        /// <response code="200">Returns the list of terms</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Term> GetTerm()
        {
            return _termService.GetList();
        }

        /// <summary>
        /// Gets term with a specific id.
        /// </summary>
        /// <param name="id">Term id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the term cannot be found</response>
        /// <response code="200">Returns the term</response>
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetTerm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var term = await _termService.GetTermAsync(id);

            if (term == null)
            {
                return NotFound();
            }

            return Ok(term);
        }

        /// <summary>
        /// Updates term.
        /// </summary>
        /// <param name="id">Term id</param>
        /// <param name="term">Term entity</param>
        /// <response code="400">If the request is bad or term ids do not match</response>
        /// <response code="204">Inform about success update</response>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateTerm([FromRoute] int id, [FromBody] Term term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != term.TermId)
            {
                return BadRequest();
            }

            await _termService.UpdateTermAsync(term);

            return NoContent();
        }

        /// <summary>
        /// Creates term.
        /// </summary>
        /// <param name="term">New term model</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="201">Returns created term</response>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateTerm([FromBody] NewTermModel term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var termCreated = await _termService.CreateTermAsync(term.Date, term.OfferId, term.WorkerId, term.Price);

            return CreatedAtAction("GetTerm", new { id = termCreated.TermId }, term);
        }

        /// <summary>
        /// Deletes term with a specific id.
        /// </summary>
        /// <param name="id">Term to delete id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the term cannot be found</response>
        /// <response code="200">Returns deleted term</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteTerm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var term = await _termService.GetTermAsync(id);
            if (term == null)
            {
                return NotFound();
            }

            await _termService.DeleteTermAsync(term);

            return Ok(term);
        }
    }
}