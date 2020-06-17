using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Business.Tests.Mocks;
using CheckoutChallenge.PaymentGateway.Data;
using CheckoutChallenge.PaymentGateway.Data.GenericImplementation;
using Microsoft.Extensions.DependencyInjection;

namespace CheckoutChallenge.PaymentGateway.Business.Tests
{
    public static class TestEnvironmentSetup
    {
        public static ServiceProvider ConfigServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<ISampleBc, SampleBc>();

            services.AddTransient<ISampleRepository, SampleRepositoryMock>();

            return services.BuildServiceProvider();
        } 
    }
}
