using System;
using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using CheckoutChallenge.PaymentGateway.WebApi.Core;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutChallenge.PaymentGateway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentBc _paymentBc;

        public PaymentController(IPaymentBc paymentBc)
        {
            _paymentBc = paymentBc;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_paymentBc.Get(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BadRequestMessage), 400)]
        [ProducesResponseType(typeof(ConflictMessage), 409)]
        public IActionResult RequestPayment(Payment payment)
        {
            return Ok(_paymentBc.Process(payment));
        }
    }
}
