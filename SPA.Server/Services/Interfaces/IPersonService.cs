using SPA.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetList();
        Task<Person> GetPersonAsync(int personID);
        Task<Person> CreatePersonAsync(string name, string surname, string email);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Person person);
        Task MatchPersonWithEmailAsync(Person person, int loginID);
    }
}
