using Structure.Interfaces.OperationStatus;
using Structure.Interfaces.Repository;
using System;

namespace Structure.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISuppliersRepository Suppliers { get; }
        IProductsRepository Products { get; }
        IProductCategoriesRepository ProductCategories { get; }
        IOperation Save();
    }
}
