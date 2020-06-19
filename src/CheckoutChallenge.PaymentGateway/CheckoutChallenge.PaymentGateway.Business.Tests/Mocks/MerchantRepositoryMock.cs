using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;

namespace CheckoutChallenge.PaymentGateway.Business.Tests.Mocks
{
    public class MerchantRepositoryMock : IMerchantRepository
    {
        public Merchant Add(Merchant entity)
        {
            return entity;
        }

        public Merchant Get(Guid key)
        {
            var merchant = new Merchant { Id = key, Name = "Exists" };
            if (key == default)
            {
                merchant = null;
            }

            return merchant;
        }

        public Merchant Get(string name)
        {
            var merchant = new Merchant { Id = Guid.NewGuid(), Name = "Exists" };
            if (name != "Exists")
            {
                merchant = null;
            }
            return merchant;
        }
    }
}
