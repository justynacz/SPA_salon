using Microsoft.AspNetCore.Mvc;
using SPA.API.Models;
using SPA.Server.Models;
using SPA.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPA.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// Gets a list of reviews.
        /// </summary>
        /// <response code="200">Returns the list of reviews</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Review> GetReviews()
        {
            return _reviewService.GetList();
        }

        /// <summary>
        /// Gets review with a specific id.
        /// </summary>
        /// <param name="id">Review id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the review cannot be found</response>
        /// <response code="200">Returns the review</response>
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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

        /// <summary>
        /// Updates review.
        /// </summary>
        /// <param name="id">Review id</param>
        /// <param name="review">Review entity</param>
        /// <response code="400">If the request is bad or review ids do not match</response>
        /// <response code="204">Inform about success update</response>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
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

        /// <summary>
        /// Creates review.
        /// </summary>
        /// <param name="review">New review model</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="201">Returns created review</response>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateReview([FromBody] NewReviewModel review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewCreated = await _reviewService.CreateReviewAsync(review.TermId, review.Grade, review.Description);

            return CreatedAtAction("GetReview", new { id = reviewCreated.ReviewId }, review);
        }

        /// <summary>
        /// Deletes review with a specific id.
        /// </summary>
        /// <param name="id">Review id</param>
        /// <response code="400">If the request is bad</response>
         /// <response code="404">If the review cannot be found</response>
         /// <response code="200">Returns deleted review</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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