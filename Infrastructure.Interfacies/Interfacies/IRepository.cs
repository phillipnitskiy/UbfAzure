using System.Linq;

namespace Infrastructure.Interfacies.Interfacies
{
    public interface IRepository<TEntity, in TEntityKey>
        where TEntity : class
        where TEntityKey : struct
    {
        TEntity GetByKey(TEntityKey key);
        IQueryable<TEntity> GetAll();
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}