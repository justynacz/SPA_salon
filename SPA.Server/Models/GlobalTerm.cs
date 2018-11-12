using System;

namespace SPA.Server.Models
{
    public partial class GlobalTerm
    {
        public int GlobalTermId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? OpenSaloon { get; set; }
        public string Description { get; set; }
    }
}
