namespace SPA.Server.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int TermId { get; set; }
        public int Grade { get; set; }
        public string Description { get; set; }

        public Term Term { get; set; }
    }
}
