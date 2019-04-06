using System;
using System.Collections.Generic;
using BllEntities.DTO;

namespace Structure.Interfaces.Services
{
    public interface ISuppliersService : IDisposable
    {
        IEnumerable<SupplierDto> GetAllSuppliers();
        SupplierDto GetSupplierById(int supplierId);
        void AddSupplier(SupplierDto supplier);
        void UpdateSupplier(SupplierDto supplier);
        void DeleteSupplierById(int id);
        IEnumerable<ProductDto> GetSuppliedProducts(int supplierId);
        void ApplyChanges();
    }
}
