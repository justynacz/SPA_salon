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
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Gets list of people.
        /// </summary>
        /// <response code="200">Returns the list of people</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Person> GetPeople()
        {
            return _personService.GetList();
        }

        /// <summary>
        /// Gets person with a specific id.
        /// </summary>
        /// <param name="id">Person id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the person cannot be found</response>
        /// <response code="200">Returns the person</response>
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _personService.GetPersonAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        /// <summary>
        /// Updates person.
        /// </summary>
        /// <param name="id">Offer id</param>
        /// <param name="person">Person entity</param>
        /// <response code="400">If the request is bad or person ids do not match</response>
        /// <response code="204">Inform about success update</response>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonId)
            {
                return BadRequest();
            }

            await _personService.UpdatePersonAsync(person);

            return NoContent();
        }

        /// <summary>
        /// Creates person.
        /// </summary>
        /// <param name="person">New person model</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="201">Returns created person</response>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreatePerson([FromBody] NewPersonModel person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personCreated = await _personService.CreatePersonAsync(person.Name, person.Surname, person.Email);

            await _personService.MatchPersonWithEmailAsync(personCreated, person.LoginId);

            return CreatedAtAction("GetPerson", new { id = personCreated.PersonId }, person);
        }

        /// <summary>
        /// Deletes person with a specific id.
        /// </summary>
        /// <param name="id">Person to delete id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the person cannot be found</response>
        /// <response code="200">Returns deleted person</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _personService.GetPersonAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            await _personService.DeletePersonAsync(person);

            return Ok(person);
        }        
    }
}