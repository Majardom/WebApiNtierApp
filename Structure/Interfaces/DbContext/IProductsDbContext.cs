using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DataEntities.Entities;

namespace Structure.Interfaces.DbContext
{
    public interface IProductsDbContext : IDisposable
    {
        DbSet<Product> Products { get; set; }
        DbSet<Supplier> Providers { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}
