using System;

namespace CheckoutChallenge.PaymentGateway.Data.GenericImplementation
{
    public class SampleRepository : ISampleRepository
    {
        public int GetSample(int sampleId)
        {
            return 42;
        }
    }
}
