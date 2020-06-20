using CheckoutChallenge.PaymentGateway.Data.Context;
using CheckoutChallenge.PaymentGateway.Data.Repositories.Core;
using MongoDB.Driver;
using System;

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

        public TEntity Add(TEntity entity)
        {
            _dbCollection.InsertOne(entity);
            return entity;
        }

        public TEntity Get(TKey key)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", key);
            return _dbCollection.Find(filter).FirstOrDefault();
        }
    }
}
