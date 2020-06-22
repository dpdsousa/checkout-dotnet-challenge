using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;

namespace CheckoutChallenge.PaymentGateway.Business.Interfaces
{
    public interface IPaymentBc
    {
        Payment Get(Guid id);
        Payment Process(Payment payment);
    }
}
