using CheckoutChallenge.PaymentGateway.Data.GenericImplementation.Repositories.Core;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;

namespace CheckoutChallenge.PaymentGateway.Data.GenericImplementation.Repositories
{
    public class MerchantRepository : CoreRepository<Merchant, Guid>, IMerchantRepository
    {
        public Merchant Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
