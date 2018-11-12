using Microsoft.EntityFrameworkCore;
using SPA.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public class ClientService: IClientService
    {
        private readonly SPAContext _context;
        public ClientService(SPAContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateClientAsync(int personID)
        {
            var clientToAdd = new Client()
            {
                PersonId = personID
            };
            var clientCreated = await _context.Client.AddAsync(clientToAdd);
            await _context.SaveChangesAsync();
            return clientCreated.Entity;
        }

        public async Task DeleteClientAsync(Client client)
        {
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetClientAsync(int clientID)
        {
            var client = await _context.Client.FindAsync(clientID);
            return client;
        }

        public IEnumerable<Client> GetList()
        {
            return _context.Client;
        }

        public async Task UpdateClientAsync(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
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
