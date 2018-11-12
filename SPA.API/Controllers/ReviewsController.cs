using Microsoft.AspNetCore.Mvc;
using SPA.API.Models;
using SPA.Server.Models;
using SPA.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/Reviews
        [HttpGet]
        public IEnumerable<Review> GetReviews()
        {
            return _reviewService.GetList();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = await _reviewService.GetReviewAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview([FromRoute] int id, [FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            await _reviewService.UpdateReviewAsync(review);

            return NoContent();
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] NewReviewModel review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewCreated = await _reviewService.CreateReviewAsync(review.TermId, review.Grade, review.Description);

            return CreatedAtAction("GetReview", new { id = reviewCreated.ReviewId }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = await _reviewService.GetReviewAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            await _reviewService.DeleteReviewAsync(review);

            return Ok(review);
        }
    }
}