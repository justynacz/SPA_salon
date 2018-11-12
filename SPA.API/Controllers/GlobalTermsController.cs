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
    public class GlobalTermsController : ControllerBase
    {
        private readonly IGlobalTermService _globalTermService;

        public GlobalTermsController(IGlobalTermService globalTermService)
        {
            _globalTermService = globalTermService;
        }

        // GET: api/GlobalTerms
        [HttpGet]
        public IEnumerable<GlobalTerm> GetGlobalTerms()
        {
            return _globalTermService.GetList();
        }

        // GET: api/GlobalTerms/5
        [HttpGet("{id}")]
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

        // PUT: api/GlobalTerms/5
        [HttpPut("{id}")]
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

        // POST: api/GlobalTerms
        [HttpPost]
        public async Task<IActionResult> CreateGlobalTerm([FromBody] NewGlobalTermModel globalTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var globalTermCreated = await _globalTermService.CreateGlobalTermAsync(globalTerm.DateFrom, globalTerm.DateTo, globalTerm.OpenSaloon, globalTerm.Description);

            return CreatedAtAction("GetGlobalTerm", new { id = globalTermCreated.GlobalTermId }, globalTerm);
        }

        // DELETE: api/GlobalTerms/5
        [HttpDelete("{id}")]
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