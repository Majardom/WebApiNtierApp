using DataEntities.Entities;
using Structure.Interfaces.DbContext;
using Structure.Interfaces.Repository;

namespace DAL_EntityFrameWork.Repositories
{
    public class ProductCategoriesRepository : GenericRepository<ProductCategory>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(IProductsDbContext context)
        : base(context)
        { }
    }
}
