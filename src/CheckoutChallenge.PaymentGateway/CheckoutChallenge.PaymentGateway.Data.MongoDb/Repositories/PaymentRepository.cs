using CheckoutChallenge.PaymentGateway.Data.Context;
using CheckoutChallenge.PaymentGateway.Data.MongoDb.Repositories.Core;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Data.MongoDb.Repositories
{
    public class PaymentRepository : CoreRepository<Payment, Guid>, IPaymentRepository
    {
        public PaymentRepository(IMongoContext mongoContext) : base(mongoContext)
        {
        }

        public async Task<Payment> GetByIdempotencyId(Guid idempotencyId)
        {
            return await _dbCollection.Find(x => x.IdempotencyId == idempotencyId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Payment>> GetByMerchantId(Guid merchantId)
        {
            return await _dbCollection.Find(x => x.MerchantId == merchantId).ToListAsync();
        }
    }
}
