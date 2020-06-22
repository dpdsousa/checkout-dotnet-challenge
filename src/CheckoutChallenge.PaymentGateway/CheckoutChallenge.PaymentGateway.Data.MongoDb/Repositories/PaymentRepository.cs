using CheckoutChallenge.PaymentGateway.Data.Context;
using CheckoutChallenge.PaymentGateway.Data.MongoDb.Repositories.Core;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;

namespace CheckoutChallenge.PaymentGateway.Data.MongoDb.Repositories
{
    public class PaymentRepository : CoreRepository<Payment, Guid>, IPaymentRepository
    {
        public PaymentRepository(IMongoContext mongoContext) : base(mongoContext)
        {
        }
    }
}
