using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BllEntities.DTO;
using DataEntities.Entities;
using ProductsBLL.Exceptions;
using Structure.Interfaces.Services;
using Structure.Interfaces.UnitOfWork;

namespace ProductsBLL.Services
{
    public class SuppliersService : BasicService, ISuppliersService, IDisposable
    {
        public SuppliersService(IUnitOfWork dbUnitOfWork)
            : base(dbUnitOfWork)
        { }

        public IEnumerable<SupplierDto> GetAllSuppliers()
        {
            var suppliers = DbUnitOfWork.Suppliers.GetAll().ToList();
            if (!suppliers.Any())
                throw new ElementNotFoundException("Suppliers not found");

            return Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDto>>(suppliers);
        }

        public SupplierDto GetSupplierById(int supplierId)
        {
            var supplier = DbUnitOfWork.Suppliers.GetById(supplierId);
            if (supplier == null)
                throw new ElementNotFoundException(supplierId);

            return Mapper.Map<Supplier, SupplierDto>(supplier);
        }

        public void AddSupplier(SupplierDto supplier)
        {
            var supplierToAdd = Mapper.Map<SupplierDto, Supplier>(supplier);
            DbUnitOfWork.Suppliers.Add(supplierToAdd);
        }

        public void UpdateSupplier(SupplierDto supplier)
        {

            if (GetSupplierById(supplier.Id) == null)
                throw new ElementNotFoundException(supplier.Id);

            var supplierToUpdate = Mapper.Map<SupplierDto, Supplier>(supplier);
            DbUnitOfWork.Suppliers.Update(supplierToUpdate);
        }

        public void DeleteSupplierById(int supplierId)
        {
            if (GetSupplierById(supplierId) == null)
                throw new ElementNotFoundException(supplierId);

            var supplierToRemove = DbUnitOfWork.Suppliers.GetById(supplierId);
            DbUnitOfWork.Suppliers.Remove(supplierToRemove);
        }

        public IEnumerable<ProductDto> GetSuppliedProducts(int supplierId)
        {
            var suppliedProducts = (from supplier in DbUnitOfWork.Suppliers.GetAll()
                                    where supplierId == supplier.Id
                                    select supplier.Products).First().ToList();

            if (!suppliedProducts.Any())
                throw new ElementNotFoundException(supplierId);

            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(suppliedProducts);
        }

        ~SuppliersService()
        {
            Dispose(false);
        }
    }
}
