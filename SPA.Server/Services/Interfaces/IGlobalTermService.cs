using SPA.Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public interface IGlobalTermService
    {
        IEnumerable<GlobalTerm> GetList();
        Task<GlobalTerm> GetGlobalTermAsync(int globalTermID);
        Task<GlobalTerm> CreateGlobalTermAsync(DateTime dateFrom, DateTime? dateTo, bool? openSaloon, string description);
        Task UpdateGlobalTermAsync(GlobalTerm globalTerm);
        Task DeleteGlobalTermAsync(GlobalTerm globalTerm);
    }
}
