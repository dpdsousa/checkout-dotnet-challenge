using CheckoutChallenge.PaymentGateway.Domain.Entities.Core;
using System;

namespace CheckoutChallenge.PaymentGateway.Domain.Entities
{
    public class Payment : IdModel<Guid>
    {
        public Guid IdempotencyId { get; set; } //TODO: Use this!
        public Guid BankTransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Card Card { get; set; }
        public PaymentStatus Status { get; set; }
        public bool HasError { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

    }
}
