using CheckoutChallenge.PaymentGateway.Data.Repositories.Core;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Data.Repositories
{
    public interface IPaymentRepository : ICoreRepository<Payment, Guid>
    {
        Task<Payment> GetByIdempotencyId(Guid idempotencyId);
    }
}
