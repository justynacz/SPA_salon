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
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            return _personService.GetList();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
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

        // PUT: api/People/5
        [HttpPut("{id}")]
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

        // POST: api/People
        [HttpPost]
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

        // DELETE: api/People/5
        [HttpDelete("{id}")]
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