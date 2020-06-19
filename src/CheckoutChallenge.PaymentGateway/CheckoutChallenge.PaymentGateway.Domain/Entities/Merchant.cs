using CheckoutChallenge.PaymentGateway.Domain.Entities.Core;
using System;

namespace CheckoutChallenge.PaymentGateway.Domain.Entities
{
    public class Merchant : IdModel<Guid>
    {
        public string Name { get; set; }
    }
}
