namespace CheckoutChallenge.BankServiceMock.DTOs
{
    public class CardDto
    {
        public string Number { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string Cvv { get; set; }
    }
}