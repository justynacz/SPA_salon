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
    public class TermsController : ControllerBase
    {
        private readonly ITermService _termService;

        public TermsController(ITermService termService)
        {
            _termService = termService;
        }

        // GET: api/Terms
        [HttpGet]
        public IEnumerable<Term> GetTerm()
        {
            return _termService.GetList();
        }

        // GET: api/Terms/5
        [HttpGet("{id}")]
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

        // PUT: api/Terms/5
        [HttpPut("{id}")]
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

        // POST: api/Terms
        [HttpPost]
        public async Task<IActionResult> CreateTerm([FromBody] NewTermModel term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var termCreated = await _termService.CreateTermAsync(term.Date, term.OfferId, term.WorkerId, term.Price);

            return CreatedAtAction("GetTerm", new { id = termCreated.TermId }, term);
        }

        // DELETE: api/Terms/5
        [HttpDelete("{id}")]
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