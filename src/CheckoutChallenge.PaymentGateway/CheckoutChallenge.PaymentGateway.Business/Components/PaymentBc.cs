using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Business.Validators;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.ApiClients;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Business.Components
{
    public class PaymentBc : IPaymentBc
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IBankApiClient _bankApiClient;
        private readonly ILogger<PaymentBc> _logger;

        public PaymentBc(IPaymentRepository paymentRepository, IBankApiClient bankApiClient, ILogger<PaymentBc> logger)
        {
            _paymentRepository = paymentRepository;
            _bankApiClient = bankApiClient;
            _logger = logger;
        }

        public async Task<Payment> Get(Guid id)
        {
            return await _paymentRepository.Get(id);
        }

        public async Task<Payment> Process(Payment payment)
        {
            var dbPayment = await _paymentRepository.GetByIdempotencyId(payment.IdempotencyId);
            if(dbPayment != null)
            {
                _logger.LogWarning($"IDEMPOTENT :: An identical request was already made for this Payment (Id - {dbPayment.Id}");
                return dbPayment;
            }

            var paymentValidator = new PaymentValidator();
            var validationResult = paymentValidator.Validate(payment);

            HandleErrors.HandleValidatorResult(validationResult);

            var transactionResults = await _bankApiClient.PostTransaction(payment);

            payment.Id = Guid.NewGuid();
            payment.Status = transactionResults.Status;
            payment.BankTransactionId = transactionResults.BankTransactionId;
            payment.HasError = payment.Status != PaymentStatus.Approved;
            payment.ErrorCode = transactionResults.ErrorCode;
            payment.ErrorMessage = transactionResults.Message;

            return await _paymentRepository.Add(payment);
        }
    }
}
