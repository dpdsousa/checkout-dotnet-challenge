using CheckoutChallenge.BankServiceMock.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace CheckoutChallenge.BankServiceMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public IActionResult ProcessTransaction(TransactionRequestDto transaction)
        {
            switch (transaction.Amount)
            {
                case 500: 
                    return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "Unkown Error!" });
                case 717:
                    return StatusCode((int)HttpStatusCode.BadRequest, new TransactionResponseDto
                    {
                        BankTransactionId = Guid.NewGuid(),
                        ErrorCode = "EE717EE",
                        Message = "Restricted card",
                        Status = PaymentStatus.Declined
                    }); 
                case 818:
                    return StatusCode((int)HttpStatusCode.BadRequest, new TransactionResponseDto
                    {
                        BankTransactionId = Guid.NewGuid(),
                        ErrorCode = "EE818EE",
                        Message = "Insufficient funds",
                        Status = PaymentStatus.Declined
                    }); 
                case 919:
                    return StatusCode((int)HttpStatusCode.BadRequest, new TransactionResponseDto
                    {
                        BankTransactionId = Guid.NewGuid(),
                        ErrorCode = "EE919EE",
                        Message = "Security violation",
                        Status = PaymentStatus.Declined
                    });
                default:
                    return Ok(new TransactionResponseDto
                    {
                        BankTransactionId = Guid.NewGuid(),
                        Status = PaymentStatus.Approved
                    });
            }
        }
    }
}
