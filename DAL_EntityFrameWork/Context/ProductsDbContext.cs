using System.Data.Entity;
using DataEntities.Entities;
using DAL_EntityFrameWork.Configuration;
using Structure.Interfaces.DbContext;
using Ninject;

namespace DAL_EntityFrameWork.Context
{
    public class ProductsDbContext : DbContext, IProductsDbContext
    {
        static ProductsDbContext()
        {
            Database.SetInitializer(new ProductsDbInitializer());
        }

        public ProductsDbContext(string connectionString)
            : base(connectionString)
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Providers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductCategoryConfig());
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new ProviderConfig());
        }
    }
}
