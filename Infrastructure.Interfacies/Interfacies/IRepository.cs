using System.Linq;

namespace Infrastructure.Interfacies.Interfacies
{
    public interface IRepository<TEntity, TEntityKey>
        where TEntity : class
        where TEntityKey : struct
    {
        TEntity GetByKey(TEntityKey key);
        IQueryable<TEntity> GetAll();
        TEntityKey Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}