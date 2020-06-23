using CheckoutChallenge.PaymentGateway.Data.Repositories.Core;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Data.Repositories
{
    public interface IPaymentRepository : ICoreRepository<Payment, Guid>
    {
        Task<Payment> GetByIdempotencyId(Guid idempotencyId);
        
        //TODO: The method below returns all payments. 
        //It should return a paged result.
        Task<IEnumerable<Payment>> GetByMerchantId(Guid merchantId);
    }
}
