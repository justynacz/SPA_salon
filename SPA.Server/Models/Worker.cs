using System;
using System.Collections.Generic;

namespace SPA.Server.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Term = new HashSet<Term>();
            WorkerRole = new HashSet<WorkerRole>();
        }

        public int WorkerId { get; set; }
        public int PersonId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public Person Person { get; set; }
        public ICollection<Term> Term { get; set; }
        public ICollection<WorkerRole> WorkerRole { get; set; }
    }
}
