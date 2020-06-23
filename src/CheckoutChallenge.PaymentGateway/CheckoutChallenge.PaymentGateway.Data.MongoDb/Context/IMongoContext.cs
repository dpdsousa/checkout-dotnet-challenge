using MongoDB.Driver;

namespace CheckoutChallenge.PaymentGateway.Data.Context
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
