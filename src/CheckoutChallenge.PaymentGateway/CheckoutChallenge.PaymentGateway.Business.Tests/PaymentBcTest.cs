using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using CheckoutChallenge.PaymentGateway.Domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CheckoutChallenge.PaymentGateway.Business.Tests
{
    public class PaymentBcTest
    {
        private readonly IPaymentBc _paymentBc;

        public PaymentBcTest()
        {
            var serviceProvider = TestEnvironmentSetup.ConfigServices();

            _paymentBc = serviceProvider.GetService<IPaymentBc>();
        }

        [Fact]
        public async void Process_ShouldCreateApprovedPayment_WhenAllIsWell()
        {
            //Arrange
            var payment = GeneratePayment();

            //Act
            var createdPayment = await _paymentBc.Process(payment);

            //Assert
            Assert.NotNull(createdPayment);
            Assert.NotEqual(default, createdPayment.Id);
            Assert.Equal(PaymentStatus.Approved, createdPayment.Status);
        }

        [Fact]
        public async void Process_ShouldThrowValidationException_WhenPaymentValuesAreWrong()
        {
            var payment = GeneratePayment();
            payment.Card.ExpiryYear = 2012;

            await Assert.ThrowsAsync<ValidationException>(() => _paymentBc.Process(payment));
        }

        [Fact]
        public async void Process_ShouldCreateDeclinedPayment_WhenBankApiReturnBadRequest()
        {
            var payment = GeneratePayment();
            payment.Amount = 717;

            var createdPayment = await _paymentBc.Process(payment);

            Assert.NotNull(createdPayment);
            Assert.NotEqual(default, createdPayment.Id);
            Assert.Equal(PaymentStatus.Declined, createdPayment.Status);
        }

        [Fact]
        public async void Process_ShouldCreatePaymentWithErrorStatus_WhenBankApiReturnInternalServerError()
        {
            var payment = GeneratePayment();
            payment.Amount = 500;

            var createdPayment = await _paymentBc.Process(payment);

            Assert.NotNull(createdPayment);
            Assert.NotEqual(default, createdPayment.Id);
            Assert.Equal(PaymentStatus.Error, createdPayment.Status);
        }

        [Fact]
        public async void Process_ShouldRetunrExistingPayment_WhenIdenticalRequestIsMade()
        {
            var payment = GeneratePayment();
            payment.IdempotencyId = Guid.NewGuid();

            var existingPayment = await _paymentBc.Process(payment);

            Assert.NotNull(existingPayment);
            Assert.Equal(payment.IdempotencyId, existingPayment.IdempotencyId);
        }

        [Fact]
        public async void Get_ShouldReturnPayment_IfPaymentExists()
        {
            var paymentId = Guid.NewGuid();

            var payment = await _paymentBc.Get(paymentId);

            Assert.NotNull(payment);
            Assert.Equal(paymentId, payment.Id);
        }

        [Fact]
        public async void Get_ShouldReturnNull_IfPaymentNotExists()
        {
            var paymentId = default(Guid);

            var payment = await _paymentBc.Get(paymentId);

            Assert.Null(payment);
        }

        private Payment GeneratePayment()
        {
            return new Payment
            {
                Amount = 12,
                Currency = "EUR",
                Card = new Card
                {
                    Cvv = "123",
                    ExpiryMonth = 7,
                    ExpiryYear = DateTime.Now.Year + 1,
                    HolderName = "Random Name",
                    Number = "1234-1234-1234-1234"
                },
                Status = PaymentStatus.Approved,
                MerchantId = Guid.NewGuid()
            };
        }
    }
}
