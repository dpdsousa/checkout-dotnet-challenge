using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Data.Repositories;

namespace CheckoutChallenge.PaymentGateway.Business
{
    public class SampleBc : ISampleBc
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleBc(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public int SampleBcMethod(int sampleId)
        {
            return _sampleRepository.GetSample(sampleId);
        }
    }
}
