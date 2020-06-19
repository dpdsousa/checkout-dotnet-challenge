using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using CheckoutChallenge.PaymentGateway.Domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CheckoutChallenge.PaymentGateway.Business.Tests
{
    public class MerchantBcTest
    {
        private readonly IMerchantBc _merchantBc;

        public MerchantBcTest()
        {
            var serviceProvider = TestEnvironmentSetup.ConfigServices();

            _merchantBc = serviceProvider.GetService<IMerchantBc>();
        }

        [Fact]
        public void MerchantBc_ShouldCreateMerchant_WhenAllIsWell()
        {
            //Arrange
            var merchant = new Merchant { Name = "TestMerchant" };

            //Act
            var createdMerchant = _merchantBc.Add(merchant);

            //Assert
            Assert.NotNull(createdMerchant);
            Assert.Equal(merchant.Name, createdMerchant.Name);
            Assert.NotEqual(default, createdMerchant.Id);
        }

        [Fact]
        public void MerchantBc_ShouldThrowException_WhenMerchantWithSameNameExists()
        {
            var merchant = new Merchant { Name = "Exists" };

            Assert.Throws<MerchantAlreadyExistsException>(() => _merchantBc.Add(merchant));
        }

        [Fact]
        public void MerchantBc_ShouldReturnMerchant_WhenMerchantExists()
        {
            var merchant = new Merchant { Id = Guid.NewGuid(), Name = "Exists" };

            var dbMerchant = _merchantBc.Get(merchant.Id);

            Assert.NotNull(dbMerchant);
            Assert.Equal(merchant.Id, dbMerchant.Id);
        }

        [Fact]
        public void MerchantBc_ShouldReturnNull_WhenMerchantDoesntExist()
        {
            var merchantId = default(Guid);

            var dbMerchant = _merchantBc.Get(merchantId);

            Assert.Null(dbMerchant);
        }
    }
}
