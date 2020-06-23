using CheckoutChallenge.PaymentGateway.WebApi.Core;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutChallenge.PaymentGateway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(AppStatus), 200)]
        public IActionResult Get()
        {
            return Ok(new AppStatus
            {
                Status = "Alive 😉",
                Message = "Payment controller API up and running",
            });
        }
    }
}
