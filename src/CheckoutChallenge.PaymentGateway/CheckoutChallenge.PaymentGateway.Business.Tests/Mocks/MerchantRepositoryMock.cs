using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Business.Tests.Mocks
{
    public class MerchantRepositoryMock : IMerchantRepository
    {
        public Task<Merchant> Add(Merchant entity)
        {
            return Task.FromResult(entity);
        }

        public Task<Merchant> Get(Guid key)
        {
            var merchant = new Merchant { Id = key, Name = "Exists" };
            if (key == default)
            {
                merchant = null;
            }

            return Task.FromResult(merchant);
        }

        public Task<Merchant> Get(string name)
        {
            var merchant = new Merchant { Id = Guid.NewGuid(), Name = "Exists" };
            if (name != "Exists")
            {
                merchant = null;
            }
            return Task.FromResult(merchant);
        }
    }
}
