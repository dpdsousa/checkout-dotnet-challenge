using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Business.Interfaces
{
    public interface IPaymentBc
    {
        Task<Payment> Get(Guid id);
        Task<IEnumerable<Payment>> GetByMerchantId(Guid merchantId);
        Task<Payment> Process(Payment payment);
    }
}
