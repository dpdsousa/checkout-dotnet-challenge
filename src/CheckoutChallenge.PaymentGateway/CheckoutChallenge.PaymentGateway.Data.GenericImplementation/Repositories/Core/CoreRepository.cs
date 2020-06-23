using CheckoutChallenge.PaymentGateway.Data.Repositories.Core;
using System;

namespace CheckoutChallenge.PaymentGateway.Data.GenericImplementation.Repositories.Core
{
    public class CoreRepository<TEntity, TKey> : ICoreRepository<TEntity, TKey> where TEntity : class
    {
        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TKey key)
        {
            throw new NotImplementedException();
        }
    }
}
