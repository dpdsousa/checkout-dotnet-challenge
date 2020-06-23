using CheckoutChallenge.PaymentGateway.Domain.ApiClients.Extensions;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using CheckoutChallenge.PaymentGateway.Domain.Exceptions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Domain.ApiClients
{
    public class BankApiClient : IBankApiClient
    {
        private readonly HttpClient _httpClient;

        public BankApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BankTransactionInfo> PostTransaction(Payment payment)
        {
            var result = await _httpClient.PostAsJsonAsync("api/transaction", payment);
            if (!result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new BusinessException(
                    BusinessExceptionCodes.BankApiInternalServerError,
                    "We couldn't process your payment. The acquiring bank is letting us down.");
            }
            return result.Content.ReadAsJsonAsync<BankTransactionInfo>().Result;
        }
    }
}
