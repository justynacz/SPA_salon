using Microsoft.EntityFrameworkCore;
using SPA.Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public class TermService : ITermService
    {
        private readonly SPAContext _context;
        public TermService(SPAContext context)
        {
            _context = context;
        }
        public async Task<Term> CreateTermAsync(DateTime date, int offerID, int workerID, decimal price)
        {
            var termToAdd = new Term()
            {
                Date = date.Date,
                //Hour = date.Hour,
                OfferId = offerID,
                WorkerId = workerID,
                Price = price
            };
            var termCreated = await _context.Term.AddAsync(termToAdd);
            await _context.SaveChangesAsync();
            return termCreated.Entity;
        }

        public async Task DeleteTermAsync(Term term)
        {
            _context.Term.Remove(term);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Term> GetList()
        {
            return _context.Term;
        }

        public async Task<Term> GetTermAsync(int termID)
        {
            var term = await _context.Term.FindAsync(termID);
            return term;
        }

        public async Task UpdateTermAsync(Term term)
        {
            _context.Entry(term).State = EntityState.Modified;
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
