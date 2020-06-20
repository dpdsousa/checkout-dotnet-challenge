using System;
using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
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
        public IActionResult Get(Guid id)
        {
            return Ok(_merchantBc.Get(id));
        }

        //TODO: Add DTOs and handle responses
        [HttpPost]
        public IActionResult Create(Merchant merchant)
        {
            return Ok(_merchantBc.Add(merchant));
        }
    }
}
