using System.Collections.Generic;

namespace SPA.Server.Models
{
    public partial class Role
    {
        public Role()
        {
            Offer = new HashSet<Offer>();
            WorkerRole = new HashSet<WorkerRole>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Offer> Offer { get; set; }
        public ICollection<WorkerRole> WorkerRole { get; set; }
    }
}
