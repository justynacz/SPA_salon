using Microsoft.EntityFrameworkCore;
using SPA.Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public class GlobalTermService : IGlobalTermService
    {
        private readonly SPAContext _context;
        public GlobalTermService(SPAContext context)
        {
            _context = context;
        }
        public async Task<GlobalTerm> CreateGlobalTermAsync(DateTime dateFrom, DateTime? dateTo, bool? openSaloon, string description)
        {
            var globalTermToAdd = new GlobalTerm()
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                OpenSaloon = openSaloon,
                Description = description
            };
            var globalTermCreated = await _context.GlobalTerm.AddAsync(globalTermToAdd);
            await _context.SaveChangesAsync();
            return globalTermCreated.Entity;
        }

        public async Task DeleteGlobalTermAsync(GlobalTerm globalTerm)
        {
            _context.GlobalTerm.Remove(globalTerm);
            await _context.SaveChangesAsync();
        }

        public async Task<GlobalTerm> GetGlobalTermAsync(int globalTermID)
        {
            var globalTerm = await _context.GlobalTerm.FindAsync(globalTermID);
            return globalTerm;
        }

        public IEnumerable<GlobalTerm> GetList()
        {
            return _context.GlobalTerm;
        }

        public async Task UpdateGlobalTermAsync(GlobalTerm globalTerm)
        {
            _context.Entry(globalTerm).State = EntityState.Modified;
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
