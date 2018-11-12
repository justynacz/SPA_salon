using Microsoft.EntityFrameworkCore;
using SPA.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public class OfferService: IOfferService
    {
        public readonly SPAContext _context;
        public OfferService(SPAContext context)
        {
            _context = context;
        }

        public async Task<Offer> CreateOfferAsync(string name, string description, int roleID)
        {
            var offerToAdd = new Offer()
            {
                Name = name,
                Description = description,
                RoleId = roleID
            };

            var offerCreated = await _context.Offer.AddAsync(offerToAdd);
            return offerCreated.Entity;
        }

        public async Task DeleteOfferAsync(Offer offer)
        {
            _context.Offer.Remove(offer);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Offer> GetList()
        {
            return _context.Offer;
        }

        public async Task<Offer> GetOfferAsync(int offerID)
        {
            var offer = await _context.Offer.FindAsync(offerID);
            return offer;
        }

        public async Task UpdateOfferAsync(Offer offer)
        {
            _context.Entry(offer).State = EntityState.Modified;
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
