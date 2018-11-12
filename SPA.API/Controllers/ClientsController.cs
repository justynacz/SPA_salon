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
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<Client> GetClient()
        {
            return _clientService.GetList();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _clientService.GetClientAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient([FromRoute] int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            await _clientService.UpdateClientAsync(client);

            return NoContent();
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] NewClientModel client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientCreated = await _clientService.CreateClientAsync(client.PersonId);

            return CreatedAtAction("GetClient", new { id = clientCreated.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _clientService.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            await _clientService.DeleteClientAsync(client);

            return Ok(client);
        }
    }
}