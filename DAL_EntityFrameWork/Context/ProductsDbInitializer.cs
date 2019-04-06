using System.Collections.Generic;
using System.Data.Entity;
using DataEntities.Entities;

namespace DAL_EntityFrameWork.Context
{
    internal class ProductsDbInitializer : CreateDatabaseIfNotExists<ProductsDbContext>
    {
        protected override void Seed(ProductsDbContext context)
        {
            base.Seed(context);
            ProductCategory category1 = new ProductCategory() {Name = "firstCategory"};
            Supplier provider1 = new Supplier() {Name = "firstProvider"};

            ProductCategory category2 = new ProductCategory() { Name = "secondCategory" };
            Supplier provider2 = new Supplier() { Name = "secondProvider" };

            context.Products.AddRange(new List<Product>()
            {
                new Product()
                {
                    Name =  "a",
                    Category = category1,
                    Supplier = provider1
                },
                new Product()
                {
                    Name =  "b",
                    Category = category2,
                    Supplier = provider1
                },
                new Product()
                {
                    Name =  "c",
                    Category = category2,
                    Supplier = provider1
                },
                new Product()
                {
                    Name =  "d",
                    Category = category1,
                    Supplier = provider1
                },
                new Product()
                {
                    Name =  "e",
                    Category = category1,
                    Supplier = provider2
                },
                new Product()
                {
                    Name =  "f",
                    Category = category2,
                    Supplier = provider2
                },
                new Product()
                {
                    Name =  "g",
                    Category = category1,
                    Supplier = provider2
                }
            });

    
            context.SaveChanges();
        }
    }
}
