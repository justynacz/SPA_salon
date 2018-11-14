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
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        /// <summary>
        /// Gets list of offers.
        /// </summary>
        /// <response code="200">Returns the list of offers</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Offer> GetOffers()
        {
            return _offerService.GetList();
        }

        /// <summary>
        /// Gets offer with a specific id.
        /// </summary>
        /// <param name="id">Offer id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the offer cannot be found</response>
        /// <response code="200">Returns the offer</response>
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetOffer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offer = await _offerService.GetOfferAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }

        /// <summary>
        /// Updates offer.
        /// </summary>
        /// <param name="id">Offer id</param>
        /// <param name="offer">Offer entity</param>
        /// <response code="400">If the request is bad or offer ids do not match</response>
        /// <response code="204">Inform about success update</response>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateOffer([FromRoute] int id, [FromBody] Offer offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != offer.OfferId)
            {
                return BadRequest();
            }

            await _offerService.UpdateOfferAsync(offer);

            return NoContent();
        }

        /// <summary>
        /// Creates offer.
        /// </summary>
        /// <param name="offer">New offer model</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="201">Returns created offer</response>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateOffer([FromBody] NewOfferModel offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offerCreated = await _offerService.CreateOfferAsync(offer.Name, offer.Description, offer.RoleId);

            return CreatedAtAction("GetOffer", new { id = offerCreated.OfferId }, offer);
        }

        /// <summary>
        /// Deletes offer with a specific id.
        /// </summary>
        /// <param name="id">Offer to delete id</param>
        /// <response code="400">If the request is bad</response>
        /// <response code="404">If the offer cannot be found</response>
        /// <response code="200">Returns deleted offer</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteOffer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offer = await _offerService.GetOfferAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            await _offerService.DeleteOfferAsync(offer);

            return Ok(offer);
        }        
    }
}