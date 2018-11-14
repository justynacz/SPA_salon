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
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Gets list of clients.
        /// </summary>
        /// <response code="200">Returns the list of clients</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Client> GetClient()
        {
            return _clientService.GetList();
        }

        /// <summary>
        /// Gets client with a specific id.
        /// </summary>
        /// <param name="id">Client id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the client cannot be found</response>
        /// <response code="200">Returns the client</response>
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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

        /// <summary>
        /// Updates client.
        /// </summary>
        /// <param name="id">Client id</param>  
        /// <param name="client">Client entity</param>
        /// <response code="400">If the request is bad or client ids do not match</response>
        /// <response code="204">Inform about success update</response>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
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

        /// <summary>
        /// Creates client.
        /// </summary>
        /// <param name="client">New client model</param>  
        /// <response code="400">If the request is bad</response>
        /// <response code="201">Returns created client</response>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateClient([FromBody] NewClientModel client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientCreated = await _clientService.CreateClientAsync(client.PersonId);

            return CreatedAtAction("GetClient", new { id = clientCreated.ClientId }, client);
        }

        /// <summary>
        /// Deletes a client with a specific id.
        /// </summary>
        /// <param name="id">Client to delete id</param>  
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the client cannot be found</response>
        /// <response code="200">Returns deleted client</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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