using System.Collections.Generic;

namespace SPA.Server.Models
{
    public partial class Client
    {
        public Client()
        {
            Term = new HashSet<Term>();
        }

        public int ClientId { get; set; }
        public int PersonId { get; set; }

        public Person Person { get; set; }
        public ICollection<Term> Term { get; set; }
    }
}
