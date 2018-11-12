using Microsoft.EntityFrameworkCore;
using SPA.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.Server.Services
{
    public class ReviewService : IReviewService
    {
        private readonly SPAContext _context;
        public ReviewService(SPAContext context)
        {
            _context = context;
        }
        public async Task<Review> CreateReviewAsync(int termID, int grade, string description)
        {
            var reviewToAdd = new Review()
            {
                TermId = termID,
                Grade = grade,
                Description = description
            };
            var reviewCreated = await _context.Review.AddAsync(reviewToAdd);
            await _context.SaveChangesAsync();
            return reviewCreated.Entity;
        }

        public async Task DeleteReviewAsync(Review review)
        {
            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Review> GetList()
        {
            return _context.Review;
        }

        public async Task<Review> GetReviewAsync(int reviewID)
        {
            var review = await _context.Review.FindAsync(reviewID);
            return review;
        }

        public async Task UpdateReviewAsync(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
