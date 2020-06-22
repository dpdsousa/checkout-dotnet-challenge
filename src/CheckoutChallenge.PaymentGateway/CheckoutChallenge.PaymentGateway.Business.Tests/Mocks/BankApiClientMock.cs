using CheckoutChallenge.PaymentGateway.Domain.ApiClients;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Business.Tests.Mocks
{
    public class BankApiClientMock : IBankApiClient
    {
        public Task<BankTransactionInfo> PostTransaction(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
