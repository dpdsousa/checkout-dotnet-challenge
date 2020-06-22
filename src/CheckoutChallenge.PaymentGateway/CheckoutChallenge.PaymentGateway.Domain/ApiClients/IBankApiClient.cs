using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Domain.ApiClients
{
    public interface IBankApiClient
    {
        Task<BankTransactionInfo> PostTransaction(Payment payment);
    }
}
