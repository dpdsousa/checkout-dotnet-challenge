using CheckoutChallenge.PaymentGateway.Business.Components;
using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Business.Tests.Mocks;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CheckoutChallenge.PaymentGateway.Business.Tests
{
    public static class TestEnvironmentSetup
    {
        public static ServiceProvider ConfigServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IMerchantBc, MerchantBc>();
            services.AddTransient<IPaymentBc, PaymentBc>();

            services.AddTransient<IMerchantRepository, MerchantRepositoryMock>();
            services.AddTransient<IPaymentRepository, PaymentRepositoryMock>();


            return services.BuildServiceProvider();
        } 
    }
}
