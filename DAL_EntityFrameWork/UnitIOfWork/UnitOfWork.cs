using System;
using DAL_EntityFrameWork.OperationResults;
using Structure.Interfaces.DbContext;
using Structure.Interfaces.OperationStatus;
using Structure.Interfaces.Repository;
using Structure.Interfaces.UnitOfWork;

namespace DAL_EntityFrameWork.UnitIOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IProductsDbContext _context;

        public ISuppliersRepository Suppliers { get; private set; }

        public IProductCategoriesRepository ProductCategories { get; private set; }

        public IProductsRepository  Products { get; private set; }

        public UnitOfWork(ISuppliersRepository suppliers, IProductCategoriesRepository productCategories, IProductsRepository products, IProductsDbContext context)
        {
            Suppliers = suppliers;
            ProductCategories = productCategories;
            Products = products;
            _context = context;
        }

        private bool _isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
                return;

            if (isDisposing)
            {
                Suppliers = null;
                Products = null;
                ProductCategories = null;
            }

            _context.Dispose();
            _isDisposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public IOperation Save()
        {
            _context.SaveChanges();
            return new OperationResult("Unit of work saved", true);
        }
    }
}
