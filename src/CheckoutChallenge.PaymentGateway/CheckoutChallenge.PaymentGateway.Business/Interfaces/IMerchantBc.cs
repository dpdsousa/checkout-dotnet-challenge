using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Business.Interfaces
{
    public interface IMerchantBc
    {
        Task<Merchant> Get(Guid id);
        Task<Merchant> Add(Merchant merchant);
    }
}