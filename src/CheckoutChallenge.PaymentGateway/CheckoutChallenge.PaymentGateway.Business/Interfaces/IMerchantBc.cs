using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;

namespace CheckoutChallenge.PaymentGateway.Business.Interfaces
{
    public interface IMerchantBc
    {
        Merchant Get(Guid id);
        Merchant Add(Merchant merchant);
    }
}