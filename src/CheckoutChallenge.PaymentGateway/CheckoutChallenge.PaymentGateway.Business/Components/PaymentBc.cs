using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Business.Validators;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
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
            var paymentValidator = new PaymentValidator();
            var validationResult = paymentValidator.Validate(payment);

            HandleErrors.HandleValidatorResult(validationResult);

            payment.Id = Guid.NewGuid();
            return _paymentRepository.Add(payment);
        }

        
    }
}
