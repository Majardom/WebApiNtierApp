using Ninject.Modules;
using ProductsBLL.Services;
using Structure.Interfaces.Services;

namespace WebApi.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductCategoriesService>().To<ProductCategoriesService>().InSingletonScope();
            Bind<IProductsService>().To<ProductsService>().InSingletonScope();
            Bind<ISuppliersService>().To<SuppliersService>().InSingletonScope();
        }
    }
}