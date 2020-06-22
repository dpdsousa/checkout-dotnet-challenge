using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Business.Interfaces
{
    public interface IPaymentBc
    {
        Task<Payment> Get(Guid id);
        Task<Payment> Process(Payment payment);
    }
}
