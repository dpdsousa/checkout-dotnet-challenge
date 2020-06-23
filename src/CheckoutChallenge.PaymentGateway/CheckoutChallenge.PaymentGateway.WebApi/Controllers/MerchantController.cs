using System;
using System.Threading.Tasks;
using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using CheckoutChallenge.PaymentGateway.WebApi.Core;
using CheckoutChallenge.PaymentGateway.WebApi.DTOs;
using CheckoutChallenge.PaymentGateway.WebApi.DTOs.Mappers;
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
            return Ok(MerchantMappers.Map(await _merchantBc.Get(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BadRequestMessage), 400)]
        [ProducesResponseType(typeof(ConflictMessage), 409)]
        public async Task<IActionResult> Create(CreateMerchantDto merchant)
        {
            var createdMerchant = await _merchantBc.Add(new Merchant { Name = merchant.Name });
            return Ok(MerchantMappers.Map(createdMerchant));
        }
    }
}
