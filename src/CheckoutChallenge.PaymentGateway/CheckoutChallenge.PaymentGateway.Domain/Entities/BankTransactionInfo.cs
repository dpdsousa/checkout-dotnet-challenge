using System;

namespace CheckoutChallenge.PaymentGateway.Domain.Entities
{
    public class BankTransactionInfo
    {
        public Guid BankTransactionId { get; set; }
        public PaymentStatus Status { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
