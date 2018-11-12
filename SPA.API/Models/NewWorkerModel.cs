using System;

namespace SPA.API.Models
{
    public class NewWorkerModel
    {
        public int PersonId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
