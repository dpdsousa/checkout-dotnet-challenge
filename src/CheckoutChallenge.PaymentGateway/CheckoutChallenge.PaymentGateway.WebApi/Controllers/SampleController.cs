using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutChallenge.PaymentGateway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleBc _sampleBc;

        public SampleController(ISampleBc sampleBc)
        {
            _sampleBc = sampleBc;
        }

        [HttpGet]
        [Route("{sampleId}")]
        public IActionResult Get(int sampleId)
        {
            return Ok(_sampleBc.SampleBcMethod(sampleId));
        }
    }
}
