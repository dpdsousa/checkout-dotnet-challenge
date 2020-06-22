using System;

namespace CheckoutChallenge.BankServiceMock.DTOs
{
    public class TransactionResponseDto
    {
        public Guid BankTransactionId { get; set; }
        public PaymentStatus Status { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
