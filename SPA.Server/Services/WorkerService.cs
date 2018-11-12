using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPA.Server.Models;

namespace SPA.Server.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly SPAContext _context;
        public WorkerService(SPAContext context)
        {
            _context = context;
        }
        public async Task<Worker> CreateWorkerAsync(int personID, DateTime? dateFrom, DateTime? dateTo)
        {
            var workerToAdd = new Worker()
            {
                PersonId = personID,
                DateFrom = dateFrom,
                DateTo = dateTo
            };
            var workerCreated = await _context.Worker.AddAsync(workerToAdd);
            await _context.SaveChangesAsync();
            return workerCreated.Entity;
        }

        public async Task DeleteWorkerAsync(Worker worker)
        {
            _context.Worker.Remove(worker);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Worker> GetList()
        {
            return _context.Worker;
        }

        public async Task<Worker> GetWorkerAsync(int workerID)
        {
            var worker = await _context.Worker.FindAsync(workerID);
            return worker;
        }

        public async Task UpdateWorkerAsync(Worker worker)
        {
            _context.Entry(worker).State = EntityState.Modified;
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
