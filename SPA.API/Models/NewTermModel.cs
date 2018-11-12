using System;

namespace SPA.API.Models
{
    public class NewTermModel
    {
        public DateTime Date { get; set; }
        public int OfferId { get; set; }
        public int WorkerId { get; set; }
        public decimal Price { get; set; }
    }
}
