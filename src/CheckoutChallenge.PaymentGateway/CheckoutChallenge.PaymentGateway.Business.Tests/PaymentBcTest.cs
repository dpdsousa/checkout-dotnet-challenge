﻿using CheckoutChallenge.PaymentGateway.Business.Interfaces;
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
        public void Process_ShouldCreatePayment_WhenAllIsWell()
        {
            //Arrange
            var payment = GeneratePayment();

            //Act
            var createdPayment = _paymentBc.Process(payment);

            //Assert
            Assert.NotNull(createdPayment);
            Assert.NotEqual(default, createdPayment.Id);
        }

        [Fact]
        public void Process_ShouldThrowValidationException_WhenPaymentValuesAreWrong()
        {
            //Arrange
            var payment = GeneratePayment();
            payment.Card.ExpiryYear = 2012;

            //Act
            Assert.Throws<ValidationException>(() => _paymentBc.Process(payment));
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
                Status = PaymentStatus.Approved
            };
        }
    }
}
