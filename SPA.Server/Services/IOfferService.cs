using SPA.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public interface IOfferService
    {
        IEnumerable<Offer> GetList();
        Task<Offer> GetOfferAsync(int offerID);
        Task<Offer> CreateOfferAsync(string name, string description, int roleID);
        Task UpdateOfferAsync(Offer offer);
        Task DeleteOfferAsync(Offer offer);
    }
}
