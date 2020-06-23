using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Business.Tests.Mocks
{
    public class PaymentRepositoryMock : IPaymentRepository
    {
        public Task<Payment> Add(Payment entity)
        {
            return Task.FromResult(entity);
        }

        public Task<Payment> Get(Guid key)
        {
            var payment = new Payment { Id = key };
            if (key == default)
            {
                payment = null;
            }

            return Task.FromResult(payment);
        }

        public Task<Payment> GetByIdempotencyId(Guid idempotencyId)
        {
            Payment payment = null;
            if (idempotencyId != default)
            {
                payment = new Payment { IdempotencyId = idempotencyId };
            }
            return Task.FromResult(payment);
        }

        public Task<IEnumerable<Payment>> GetByMerchantId(Guid merchantId)
        {
            var payments = new List<Payment>()
            {
                new Payment
                {
                    Id = Guid.NewGuid(),
                    MerchantId = merchantId,
                    Card = new Card
                    {
                        ExpiryMonth = 12
                    }
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    MerchantId = merchantId,
                    Card = new Card
                    {
                        ExpiryMonth = 12
                    }
                }
            };
            return Task.FromResult<IEnumerable<Payment>>(payments);
        }
    }
}
