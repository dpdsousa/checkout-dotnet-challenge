using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Data.Repositories.Core
{
    public interface ICoreRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> Get(TKey key);
        Task<TEntity> Add(TEntity entity);
    }
}
