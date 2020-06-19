namespace CheckoutChallenge.PaymentGateway.Data.Repositories.Core
{
    public interface ICoreRepository<TEntity, TKey> where TEntity : class
    {
        TEntity Get(TKey key);
        TEntity Add(TEntity entity);
    }
}
