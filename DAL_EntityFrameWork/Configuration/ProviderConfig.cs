using System.Data.Entity.ModelConfiguration;
using DataEntities.Entities;

namespace DAL_EntityFrameWork.Configuration
{
    internal class ProviderConfig : EntityTypeConfiguration<Supplier>
    {
        public ProviderConfig()
        {
            HasKey<int>(provider => provider.Id);
            Property(provider => provider.Name).HasMaxLength(30).IsRequired();
            HasMany(provider => provider.Products);
        }
    }
}
