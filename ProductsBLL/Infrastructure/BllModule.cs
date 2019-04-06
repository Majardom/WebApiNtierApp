using DAL_EntityFrameWork.Context;
using DAL_EntityFrameWork.Repositories;
using DAL_EntityFrameWork.UnitIOfWork;
using Ninject.Modules;
using Structure.Interfaces.DbContext;
using Structure.Interfaces.Repository;
using Structure.Interfaces.UnitOfWork;

namespace ProductsBLL.Infrastructure
{
    public class BllModule : NinjectModule
    {
        private readonly string _connectionString;

        public BllModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IProductsDbContext>().To<ProductsDbContext>().InSingletonScope().WithConstructorArgument(_connectionString);
            Bind<IProductsRepository>().To<ProductsRepository>().InSingletonScope();
            Bind<ISuppliersRepository>().To<SuppliersRepository>().InSingletonScope();
            Bind<IProductCategoriesRepository>().To<ProductCategoriesRepository>().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}
