using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CheckoutChallenge.PaymentGateway.Business.Tests
{
    public class SampleBcTest
    {
        private readonly ISampleBc _sampleBc;


        public SampleBcTest()
        {
            var serviceProvider = TestEnvironmentSetup.ConfigServices();

            _sampleBc = serviceProvider.GetService<ISampleBc>();
        }

        [Fact]
        public void SampleBcMethod_Test()
        {
            //Arrange
            var sampleId = 10;

            //Act
            var returnedValue = _sampleBc.SampleBcMethod(sampleId);

            //Assert
            Assert.Equal(42, returnedValue);
        }

        [Fact]
        public void FailingTestJustToSeeTheCIDoingStuff()
        {
            //True == False
            Assert.True(false);
        }
    }
}
