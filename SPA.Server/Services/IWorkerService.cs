using SPA.Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public interface IWorkerService
    {
        IEnumerable<Worker> GetList();
        Task<Worker> GetWorkerAsync(int workerID);
        Task<Worker> CreateWorkerAsync(int personID, DateTime? dateFrom, DateTime? dateTo);
        Task UpdateWorkerAsync(Worker worker);
        Task DeleteWorkerAsync(Worker worker);
    }
}
