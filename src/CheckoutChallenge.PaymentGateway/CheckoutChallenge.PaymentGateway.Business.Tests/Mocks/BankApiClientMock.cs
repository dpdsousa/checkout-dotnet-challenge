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
            var transactionInfo = new BankTransactionInfo
            {
                BankTransactionId = Guid.NewGuid(),
                Status = PaymentStatus.Approved,
                ErrorCode = string.Empty,
                Message = string.Empty
            };

            if(payment.Amount == 717)
            {
                transactionInfo.Message = "Error";
                transactionInfo.ErrorCode = "ErrorCode";
                transactionInfo.Status = PaymentStatus.Declined;
            }

            if (payment.Amount == 500)
            {
                transactionInfo.Message = "Error";
                transactionInfo.ErrorCode = "ErrorCode";
                transactionInfo.Status = PaymentStatus.Error;
            }

            return Task.FromResult(transactionInfo);
        }
    }
}
