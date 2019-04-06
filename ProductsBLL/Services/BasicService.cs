using System;
using Structure.Interfaces.UnitOfWork;

namespace ProductsBLL.Services
{
    public class BasicService : IDisposable
    {
        protected IUnitOfWork DbUnitOfWork;

        public BasicService(IUnitOfWork dbUnitOfWork)
        {
            DbUnitOfWork = dbUnitOfWork;
            _isDisposed = false;
        }

        public void ApplyChanges()
        {
            DbUnitOfWork.Save();
        }

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool isDisposing)
        {
            if (_isDisposed) return;

            if (isDisposing) { }

            DbUnitOfWork.Dispose();
            _isDisposed = true;
        }
    }
}
