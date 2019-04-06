using DataEntities.Entities;
using Structure.Interfaces.DbContext;
using Structure.Interfaces.Repository;

namespace DAL_EntityFrameWork.Repositories
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(IProductsDbContext context)
            : base(context)
        { }
    }
}
