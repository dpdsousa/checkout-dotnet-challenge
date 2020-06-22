using System;
using System.Threading.Tasks;
using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.WebApi.Core;
using CheckoutChallenge.PaymentGateway.WebApi.DTOs;
using CheckoutChallenge.PaymentGateway.WebApi.DTOs.Mappers;
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
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(PaymentMappers.Map(await _paymentBc.Get(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BadRequestMessage), 400)]
        [ProducesResponseType(typeof(ConflictMessage), 409)]
        public async Task<IActionResult> RequestPayment(PaymentRequestDto paymentRequest)
        {
            return Ok(await _paymentBc.Process(PaymentMappers.Map(paymentRequest)));
        }
    }
}
