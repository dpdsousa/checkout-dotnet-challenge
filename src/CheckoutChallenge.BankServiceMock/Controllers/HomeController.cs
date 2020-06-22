using CheckoutChallenge.BankServiceMock.Core;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutChallenge.BankServiceMock.Controllers
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
                Message = "Bank Service Mock API up and running",
            });
        }
    }
}
