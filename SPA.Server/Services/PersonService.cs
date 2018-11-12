using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPA.Server.Models;

namespace SPA.Server.Services
{
    public class PersonService : IPersonService
    {
        private readonly SPAContext _context;
        private readonly ILoginService _loginService;
        public PersonService(
            SPAContext context,
            ILoginService loginService)
        {
            _context = context;
            _loginService = loginService;
        }

        public async Task<Person> CreatePersonAsync(string name, string surname, string email)
        {
            var personToAdd = new Person()
            {
                Name = name,
                Surname = surname,
                Email = email
            };
            var personCreated = await _context.Person.AddAsync(personToAdd);
            await _context.SaveChangesAsync();
            return personCreated.Entity;
        }

        public async Task DeletePersonAsync(Person personToDelete)
        {
            _context.Person.Remove(personToDelete);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Person> GetList()
        {
            return _context.Person;
        }

        public async Task<Person> GetPersonAsync(int personID)
        {
            var person = await _context.Person.FindAsync(personID);
            return person;
        }

        public async Task MatchPersonWithEmailAsync(Person person, int loginID)
        {
            //var login = await _loginService.GetLoginAsync(loginID);
            person.LoginId = loginID;
            //person.Login = login;
            await UpdatePersonAsync(person);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        
    }
}
