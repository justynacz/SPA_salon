using System;
using System.Collections.Generic;

namespace SPA.Server.Models
{
    public partial class Term
    {
        public Term()
        {
            Review = new HashSet<Review>();
        }

        public int TermId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public int OfferId { get; set; }
        public int WorkerId { get; set; }
        public int? ClientId { get; set; }
        public bool? Done { get; set; }
        public decimal Price { get; set; }

        public Client Client { get; set; }
        public Offer Offer { get; set; }
        public Worker Worker { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
