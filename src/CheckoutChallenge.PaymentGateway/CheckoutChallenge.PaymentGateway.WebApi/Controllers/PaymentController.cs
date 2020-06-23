using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.WebApi.Core;
using CheckoutChallenge.PaymentGateway.WebApi.DTOs;
using CheckoutChallenge.PaymentGateway.WebApi.DTOs.Mappers;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PaymentDto), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(PaymentMappers.Map(await _paymentBc.Get(id)));
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PaymentDto>), 200)]
        public async Task<IActionResult> GetByMerchantId([FromQuery] Guid merchantId)
        {
            return Ok(PaymentMappers.Map(await _paymentBc.GetByMerchantId(merchantId)));
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(PaymentDto), 200)]
        [ProducesResponseType(typeof(BadRequestMessage), 400)]
        [ProducesResponseType(typeof(ConflictMessage), 409)]
        public async Task<IActionResult> RequestPayment(PaymentRequestDto paymentRequest)
        {
            return Ok(PaymentMappers.Map(await _paymentBc.Process(PaymentMappers.Map(paymentRequest))));
        }
    }
}
