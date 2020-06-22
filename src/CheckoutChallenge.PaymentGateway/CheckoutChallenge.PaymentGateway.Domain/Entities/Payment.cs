using CheckoutChallenge.PaymentGateway.Domain.Entities.Core;
using System;

namespace CheckoutChallenge.PaymentGateway.Domain.Entities
{
    public class Payment : IdModel<Guid>
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Card Card { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
