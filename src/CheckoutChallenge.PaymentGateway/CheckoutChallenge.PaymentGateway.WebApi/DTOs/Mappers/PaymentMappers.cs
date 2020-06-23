using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System.Data.Common;

namespace CheckoutChallenge.PaymentGateway.WebApi.DTOs.Mappers
{
    public static class PaymentMappers
    {
        public static Payment Map(PaymentRequestDto paymentRequest)
        {
            return new Payment
            {
                Amount = paymentRequest.Amount,
                Currency = paymentRequest.Currency,
                IdempotencyId = paymentRequest.IdempotencyId,
                MerchantId = paymentRequest.MerchantId,
                Card = new Card
                {
                    Cvv = paymentRequest.Card.Cvv,
                    ExpiryMonth = paymentRequest.Card.ExpiryMonth,
                    ExpiryYear = paymentRequest.Card.ExpiryYear,
                    HolderName = paymentRequest.Card.HolderName,
                    Number = paymentRequest.Card.Number
                }
            };
        }

        public static PaymentDto Map(Payment payment)
        {
            return new PaymentDto
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Currency = payment.Currency,
                MerchantId = payment.MerchantId,
                ErrorCode = payment.ErrorCode,
                ErrorMessage = payment.ErrorMessage,
                HasError = payment.HasError,
                Status = payment.Status.ToString(),
                CreatedOn = payment.CreatedOn,
                Card = new CardDto
                {
                    Cvv = payment.Card.Cvv,
                    ExpiryMonth = payment.Card.ExpiryMonth,
                    ExpiryYear = payment.Card.ExpiryYear,
                    HolderName = payment.Card.HolderName,
                    Number = payment.Card.Number
                }
            };
        }
    }
}
