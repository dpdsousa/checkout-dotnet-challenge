using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Business.Validators;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.ApiClients;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Business.Components
{
    public class PaymentBc : IPaymentBc
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IBankApiClient _bankApiClient;

        public PaymentBc(IPaymentRepository paymentRepository, IBankApiClient bankApiClient)
        {
            _paymentRepository = paymentRepository;
            _bankApiClient = bankApiClient;
        }

        public async Task<Payment> Get(Guid id)
        {
            return await _paymentRepository.Get(id);
        }

        public async Task<Payment> Process(Payment payment)
        {
            var paymentValidator = new PaymentValidator();
            var validationResult = paymentValidator.Validate(payment);

            HandleErrors.HandleValidatorResult(validationResult);

            var transactionResults = await _bankApiClient.PostTransaction(payment);

            payment.Id = Guid.NewGuid();
            return await _paymentRepository.Add(payment);
        }
    }
}
