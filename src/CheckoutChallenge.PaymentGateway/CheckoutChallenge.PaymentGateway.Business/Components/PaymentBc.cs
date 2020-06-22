using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Business.Validators;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using CheckoutChallenge.PaymentGateway.Domain.Exceptions;
using FluentValidation.Results;
using System;

namespace CheckoutChallenge.PaymentGateway.Business.Components
{
    public class PaymentBc : IPaymentBc
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentBc(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Payment Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Payment Process(Payment payment)
        {
            var cardValidator = new CardValidator();
            var validationResult = cardValidator.Validate(payment.Card);

            HandleErrors.HandleValidatorResult(validationResult);

            payment.Id = Guid.NewGuid();
            return _paymentRepository.Add(payment);
        }

        
    }
}
