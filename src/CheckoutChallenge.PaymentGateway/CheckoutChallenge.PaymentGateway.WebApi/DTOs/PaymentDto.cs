using System;

namespace CheckoutChallenge.PaymentGateway.WebApi.DTOs
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public Guid MerchantId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public CardDto Card { get; set; }
        public string Status { get; set; }
        public bool HasError { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
