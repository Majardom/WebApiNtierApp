using System.Data.Entity.ModelConfiguration;
using DataEntities.Entities;

namespace DAL_EntityFrameWork.Configuration
{
    internal class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            HasKey<int>(product => product.Id);
            Property(product => product.Name).HasMaxLength(30).IsRequired();
            HasRequired(product => product.Supplier);
            HasRequired(product => product.Category);
        }
    }
}
