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
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        // GET: api/Offers
        [HttpGet]
        public IEnumerable<Offer> GetOffers()
        {
            return _offerService.GetList();
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]
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

        // PUT: api/Offers/5
        [HttpPut("{id}")]
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

        // POST: api/Offers
        [HttpPost]
        public async Task<IActionResult> CreateOffer([FromBody] NewOfferModel offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offerCreated = await _offerService.CreateOfferAsync(offer.Name, offer.Description, offer.RoleId);

            return CreatedAtAction("GetOffer", new { id = offerCreated.OfferId }, offer);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
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