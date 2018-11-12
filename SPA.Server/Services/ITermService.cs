using SPA.Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public interface ITermService
    {
        IEnumerable<Term> GetList();
        Task<Term> GetTermAsync(int termID);
        Task<Term> CreateTermAsync(DateTime date, int offerID, int workerID, decimal price);
        Task UpdateTermAsync(Term term);
        Task DeleteTermAsync(Term term);
    }
}
