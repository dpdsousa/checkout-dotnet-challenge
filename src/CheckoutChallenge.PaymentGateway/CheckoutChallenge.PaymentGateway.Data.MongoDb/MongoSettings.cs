namespace CheckoutChallenge.PaymentGateway.Data.MongoDb
{
    public class MongoSettings : IDatabaseSettings
    {
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set ; }
    }
}
