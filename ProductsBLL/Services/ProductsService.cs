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
    public class ProductsService : BasicService, IProductsService, IDisposable
    {
        public ProductsService(IUnitOfWork dbUnitOfWork)
            : base(dbUnitOfWork)
        { }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = DbUnitOfWork.Products.GetAll().ToList();
            if (!products.Any())
                throw new ElementNotFoundException("Categories not found");

            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetProductById(int productId)
        {
            var product = DbUnitOfWork.Products.GetById(productId);

            if (product is null)
                throw new ElementNotFoundException(productId);

            return Mapper.Map<Product, ProductDto>(product);
        }

        public void AddProduct(ProductDto product)
        {
            var productToAdd = Mapper.Map<ProductDto, Product>(product);
            DbUnitOfWork.Products.Add(productToAdd);
        }

        public void UpdateProduct(ProductDto product)
        {
            if (GetProductById(product.Id) == null)
                throw new ElementNotFoundException(product.Id);

            var productToUpdate = Mapper.Map<ProductDto, Product>(product);
            DbUnitOfWork.Products.Update(productToUpdate);
        }

        public void DeleteProductById(int productId)
        {
            if (GetProductById(productId) == null)
                throw new ElementNotFoundException(productId);

            var productToRemove = DbUnitOfWork.Products.GetById(productId);
            DbUnitOfWork.Products.Remove(productToRemove);
        }

        ~ProductsService()
        {
            Dispose(false);
        }
    }
}
