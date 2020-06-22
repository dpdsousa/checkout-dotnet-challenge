using CheckoutChallenge.PaymentGateway.Domain.ApiClients.Extensions;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
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
            if (!result.IsSuccessStatusCode)
            {
                //TODO: This
            }
            return result.Content.ReadAsJsonAsync<BankTransactionInfo>().Result;
        }
    }
}
