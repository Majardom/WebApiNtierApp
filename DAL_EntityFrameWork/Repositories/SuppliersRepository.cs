using DataEntities.Entities;
using Structure.Interfaces.DbContext;
using Structure.Interfaces.Repository;

namespace DAL_EntityFrameWork.Repositories
{
    public class SuppliersRepository : GenericRepository<Supplier>, ISuppliersRepository
    {
        public SuppliersRepository(IProductsDbContext context)
            : base(context)
        { }
    }
}
