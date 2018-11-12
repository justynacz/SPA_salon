using System.Collections.Generic;

namespace SPA.Server.Models
{
    public partial class Offer
    {
        public Offer()
        {
            Term = new HashSet<Term>();
        }

        public int OfferId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public ICollection<Term> Term { get; set; }
    }
}
