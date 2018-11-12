using System;

namespace SPA.API.Models
{
    public class NewGlobalTermModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? OpenSaloon { get; set; }
        public string Description { get; set; }
    }
}
