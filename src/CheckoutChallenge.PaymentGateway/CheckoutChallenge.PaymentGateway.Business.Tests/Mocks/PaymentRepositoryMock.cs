using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;

namespace CheckoutChallenge.PaymentGateway.Business.Tests.Mocks
{
    public class PaymentRepositoryMock : IPaymentRepository
    {
        public Payment Add(Payment entity)
        {
            return entity;
        }

        public Payment Get(Guid key)
        {
            var payment = new Payment { Id = key };
            if (key == default)
            {
                payment = null;
            }

            return payment;
        }
    }
}
