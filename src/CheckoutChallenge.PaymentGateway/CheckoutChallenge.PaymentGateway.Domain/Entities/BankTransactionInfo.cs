using System;

namespace CheckoutChallenge.PaymentGateway.Domain.Entities
{
    public class BankTransactionInfo
    {
        Guid BankTransactionId { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
