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
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        /// <summary>
        /// Gets list of workers.
        /// </summary>
        /// <response code="200">Returns the list of workers</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Worker> GetWorkers()
        {
            return _workerService.GetList();
        }

        /// <summary>
        /// Gets worker with a specific id.
        /// </summary>
        /// <param name="id">Worker id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the worker cannot be found</response>
        /// <response code="200">Returns the worker</response>
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetWorker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var worker = await _workerService.GetWorkerAsync(id);

            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        /// <summary>
        /// Updates worker.
        /// </summary>
        /// <param name="id">Worker id</param>
        /// <param name="worker">Worker entity</param>
        /// <response code="400">If the request is bad or worker ids do not match</response>
        /// <response code="204">Inform about success update</response>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateWorker([FromRoute] int id, [FromBody] Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worker.WorkerId)
            {
                return BadRequest();
            }

            await _workerService.UpdateWorkerAsync(worker); 

            return NoContent();
        }

        /// <summary>
        /// Creates worker.
        /// </summary>
        /// <param name="worker">New worker model</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="201">Returns created worker</response>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateWorker([FromBody] NewWorkerModel worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workerCreated = await _workerService.CreateWorkerAsync(worker.PersonId, worker.DateFrom, worker.DateTo);

            return CreatedAtAction("GetWorker", new { id = workerCreated.WorkerId }, worker);
        }

        /// <summary>
        /// Deletes worker with a specific id.
        /// </summary>
        /// <param name="id">Worker to delete id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the worker cannot be found</response>
        /// <response code="200">Returns deleted worker</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteWorker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var worker = await _workerService.GetWorkerAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            await _workerService.DeleteWorkerAsync(worker);

            return Ok(worker);
        }
    }
}