using System.Collections.Generic;
using DataEntities.Entities;
using Structure.Interfaces.OperationStatus;

namespace Structure.Interfaces.Repository
{
    public interface IGenericRepository<TEntity>  where TEntity : BaseDalEntity 
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IOperation Add(TEntity entity);
        IOperation Remove(TEntity entity);
        IOperation Update(TEntity entity);
    }
}
