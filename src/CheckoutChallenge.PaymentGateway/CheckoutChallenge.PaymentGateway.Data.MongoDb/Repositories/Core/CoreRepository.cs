using CheckoutChallenge.PaymentGateway.Data.Context;
using CheckoutChallenge.PaymentGateway.Data.Repositories.Core;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Data.MongoDb.Repositories.Core
{
    public class CoreRepository<TEntity, TKey> : ICoreRepository<TEntity, TKey> where TEntity : class
    {
        private readonly IMongoContext _mongoContext;
        protected readonly IMongoCollection<TEntity> _dbCollection;

        public CoreRepository(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<TEntity> Get(TKey key)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", key);
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
