using System.Data.Entity.ModelConfiguration;
using DataEntities.Entities;

namespace DAL_EntityFrameWork.Configuration
{
    internal class ProductCategoryConfig : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfig()
        {
            HasKey<int>(productCategory => productCategory.Id);
            Property(productCategory => productCategory.Name).HasMaxLength(30).IsRequired();
        }
    }
}
