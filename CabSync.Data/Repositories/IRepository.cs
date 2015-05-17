using System.Collections.Generic;

namespace CabSync.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entiry);
        void Delete(int entityId);
        IEnumerable<TEntity> Read();
        void Update(TEntity entiry);
    }
}
