using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CheckoutChallenge.PaymentGateway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleBc _sampleBc;
        private readonly ILogger<SampleController> _logger;

        public SampleController(ISampleBc sampleBc, ILogger<SampleController> logger)
        {
            _sampleBc = sampleBc;
            _logger = logger;
        }

        [HttpGet]
        [Route("{sampleId}")]
        public IActionResult Get(int sampleId)
        {
            _logger.LogInformation("Sample log!");
            return Ok(_sampleBc.SampleBcMethod(sampleId));
        }
    }
}
