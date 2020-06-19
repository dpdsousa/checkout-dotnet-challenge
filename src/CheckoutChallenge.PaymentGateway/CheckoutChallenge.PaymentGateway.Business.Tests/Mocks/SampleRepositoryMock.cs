using CheckoutChallenge.PaymentGateway.Data.Repositories;

namespace CheckoutChallenge.PaymentGateway.Business.Tests.Mocks
{
    public class SampleRepositoryMock : ISampleRepository
    {
        public int GetSample(int sampleId)
        {
            return 42;
        }
    }
}
