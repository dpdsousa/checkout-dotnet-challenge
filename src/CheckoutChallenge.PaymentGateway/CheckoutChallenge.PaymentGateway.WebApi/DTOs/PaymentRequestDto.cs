using System;

namespace CheckoutChallenge.PaymentGateway.WebApi.DTOs
{
    public class PaymentRequestDto
    {
        public Guid MerchantId { get; set; }
        public Guid IdempotencyId { get; set; } 
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public CardDto Card { get; set; }
    }
}
