using System.Collections.Generic;

namespace SPA.Server.Models
{
    public partial class Login
    {
        public Login()
        {
            Person = new HashSet<Person>();
        }

        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }

        public ICollection<Person> Person { get; set; }
    }
}
