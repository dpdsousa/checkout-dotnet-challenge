using System;
using System.Threading.Tasks;
using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using CheckoutChallenge.PaymentGateway.WebApi.Core;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutChallenge.PaymentGateway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantBc _merchantBc;

        public MerchantController(IMerchantBc merchantBc)
        {
            _merchantBc = merchantBc;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _merchantBc.Get(id));
        }

        //TODO: Add DTOs and handle responses
        [HttpPost]
        [ProducesResponseType(typeof(BadRequestMessage), 400)]
        [ProducesResponseType(typeof(ConflictMessage), 409)]
        public async Task<IActionResult> Create(Merchant merchant)
        {
            return Ok(await _merchantBc.Add(merchant));
        }
    }
}
