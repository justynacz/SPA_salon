using System.Collections.Generic;

namespace SPA.Server.Models
{
    public partial class Person
    {
        public Person()
        {
            Client = new HashSet<Client>();
            Worker = new HashSet<Worker>();
        }

        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? LoginId { get; set; }

        public Login Login { get; set; }
        public ICollection<Client> Client { get; set; }
        public ICollection<Worker> Worker { get; set; }
    }
}
