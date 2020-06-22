namespace CheckoutChallenge.PaymentGateway.Domain.Entities
{
    public class Card
    {
        public string Number { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string Cvv { get; set; }
        public string HolderName { get; set; }
    }
}