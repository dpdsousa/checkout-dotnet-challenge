using CheckoutChallenge.PaymentGateway.Data.Repositories;

namespace CheckoutChallenge.PaymentGateway.Data.MongoDb.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        public int GetSample(int sampleId)
        {
            return 42;
        }
    }
}
