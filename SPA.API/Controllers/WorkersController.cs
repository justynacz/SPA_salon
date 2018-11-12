using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.API.Models;
using SPA.Server.Models;
using SPA.Server.Services;

namespace SPA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        // GET: api/Workers
        [HttpGet]
        public IEnumerable<Worker> GetWorkers()
        {
            return _workerService.GetList();
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
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

        // PUT: api/Workers/5
        [HttpPut("{id}")]
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

        // POST: api/Workers
        [HttpPost]
        public async Task<IActionResult> CreateWorker([FromBody] NewWorkerModel worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workerCreated = await _workerService.CreateWorkerAsync(worker.PersonId, worker.DateFrom, worker.DateTo);

            return CreatedAtAction("GetWorker", new { id = workerCreated.WorkerId }, worker);
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
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