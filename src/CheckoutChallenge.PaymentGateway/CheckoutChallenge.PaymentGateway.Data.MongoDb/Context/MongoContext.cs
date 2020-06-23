using CheckoutChallenge.PaymentGateway.Data.Context;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CheckoutChallenge.PaymentGateway.Data.MongoDb.Context
{
    public class MongoContext : IMongoContext
    {
        private MongoClient MongoClient { get; set; }
        private IMongoDatabase Db { get; set; }

        public MongoContext(IOptions<MongoSettings> configuration)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
            MongoClient = new MongoClient(configuration.Value.ConnectionString);
            Db = MongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

         public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Db.GetCollection<T>(name);
        }
    }
}
