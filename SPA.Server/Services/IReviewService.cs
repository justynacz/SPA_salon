using SPA.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public interface IReviewService
    {
        IEnumerable<Review> GetList();
        Task<Review> GetReviewAsync(int reviewID);
        Task<Review> CreateReviewAsync(int termID, int grade, string description);
        Task UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(Review review);
    }
}
