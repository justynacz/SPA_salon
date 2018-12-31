using SPA.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetList();
        Task<Client> GetClientAsync(int clientID);
        Task<Client> CreateClientAsync(int personID);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Client client);
    }
}
