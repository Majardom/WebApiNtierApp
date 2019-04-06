using DAL_EntityFrameWork.OperationResults;
using DataEntities.Entities;
using Structure.Interfaces.DbContext;
using Structure.Interfaces.OperationStatus;
using Structure.Interfaces.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL_EntityFrameWork.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDalEntity
    {
        protected DbSet<TEntity> Entities;
        protected IProductsDbContext Context;

        public GenericRepository(IProductsDbContext context)
        {
            Entities = context.Set<TEntity>();
            Context = context;
        }

        public TEntity GetById(int id)
        {
            return Entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public IOperation Add(TEntity entity)
        {
            Entities.Add(entity);
            return new OperationResult($"Added entity {entity.Id}", true);
        }

        public IOperation Remove(TEntity entity)
        {
            Entities.Remove(entity);
            return new OperationResult($"Removed entity {entity.Id}", true);
        }

        public IOperation Update(TEntity entity)
        {
            var currentEntity = GetById(entity.Id);
            Context.Entry(currentEntity).CurrentValues.SetValues(entity);
            Context.Entry(currentEntity).State = EntityState.Modified;
            return new OperationResult($"Updated entity {entity.Id}", true);
        }

        public IOperation SaveChanges()
        {
            Context.SaveChanges();
            return new OperationResult("Saved changes", true);
        }
    }
}
