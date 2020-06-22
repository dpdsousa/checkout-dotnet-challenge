namespace CheckoutChallenge.BankServiceMock.DTOs
{
    public class TransactionRequestDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public CardDto Card { get; set; }
    }
}
