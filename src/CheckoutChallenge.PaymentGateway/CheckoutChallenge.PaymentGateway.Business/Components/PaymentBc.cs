using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Business.Validators;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.ApiClients;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using CheckoutChallenge.PaymentGateway.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Business.Components
{
    /// <summary>
    /// PaymentBc - Business Component
    /// Class responsible for all the business logic related to payments functionalities
    /// </summary>
    public class PaymentBc : IPaymentBc
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMerchantRepository _merchantRepository;
        private readonly IBankApiClient _bankApiClient;
        private readonly ILogger<PaymentBc> _logger;

        public PaymentBc(
            IPaymentRepository paymentRepository, 
            IMerchantRepository merchantRepository,
            IBankApiClient bankApiClient, 
            ILogger<PaymentBc> logger)
        {
            _paymentRepository = paymentRepository;
            _merchantRepository = merchantRepository;
            _bankApiClient = bankApiClient;
            _logger = logger;
        }

        public async Task<Payment> Get(Guid id)
        {
            return await _paymentRepository.Get(id);
        }

        public async Task<IEnumerable<Payment>> GetByMerchantId(Guid merchantId)
        {
            return await _paymentRepository.GetByMerchantId(merchantId);
        }

        public async Task<Payment> Process(Payment payment)
        {
            var dbPayment = await _paymentRepository.GetByIdempotencyId(payment.IdempotencyId);
            if(dbPayment != null)
            {
                _logger.LogWarning($"IDEMPOTENT :: An identical request was already made for this Payment (Id - {dbPayment.Id}");
                return dbPayment;
            }

            var dbMerchant = await _merchantRepository.Get(payment.MerchantId);
            if(dbMerchant == null)
            {
                throw new BusinessException(
                    BusinessExceptionCodes.MerchantHasNoContract,
                    "This Merchant has no contract with us, therefore we cannot accept payment requests.");
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
            payment.CreatedOn = DateTime.UtcNow;
            payment.UpdatedOn = DateTime.UtcNow;

            return await _paymentRepository.Add(payment);
        }
    }
}
