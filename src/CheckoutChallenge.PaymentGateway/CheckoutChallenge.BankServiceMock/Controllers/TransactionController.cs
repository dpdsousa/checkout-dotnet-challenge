using CheckoutChallenge.BankServiceMock.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutChallenge.BankServiceMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public IActionResult ProcessTransaction(TransactionRequestDto transaction)
        {
            return BadRequest(transaction);
        }
    }
}
