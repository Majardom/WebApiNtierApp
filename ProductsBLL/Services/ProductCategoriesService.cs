using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using AutoMapper;
using BllEntities.DTO;
using DataEntities.Entities;
using ProductsBLL.Exceptions;
using Structure.Interfaces.UnitOfWork;
using Structure.Interfaces.Services;

namespace ProductsBLL.Services
{
    public class ProductCategoriesService : BasicService, IProductCategoriesService, IDisposable
    {
        public ProductCategoriesService(IUnitOfWork dbUnitOfWork)
         : base(dbUnitOfWork)
        { }

        public IEnumerable<ProductCategoryDto> GetAllCategories()
        {
            var categories = DbUnitOfWork.ProductCategories.GetAll().ToList();
            if (!categories.Any())
                throw new ElementNotFoundException("Categories not found");

            return Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryDto>>(categories);
        }

        public ProductCategoryDto GetCategoryById(int categoryId)
        {
            var category = DbUnitOfWork.ProductCategories.GetById(categoryId);

            if (category is null)
                throw new ElementNotFoundException(categoryId);

            return Mapper.Map<ProductCategory, ProductCategoryDto>(category);
        }

        public void AddProductCategory(ProductCategoryDto category)
        {
            var categoryToAdd = Mapper.Map<ProductCategoryDto, ProductCategory>(category);
            DbUnitOfWork.ProductCategories.Add(categoryToAdd);
        }

        public void UpdateProductCategory(ProductCategoryDto category)
        {
            if(GetCategoryById(category.Id) == null)
                throw new ElementNotFoundException(category.Id);

            var categoryToUpdate = Mapper.Map<ProductCategoryDto, ProductCategory>(category);
            DbUnitOfWork.ProductCategories.Update(categoryToUpdate);
        }

        public void DeleteCategoryById(int categoryId)
        {
            if (GetCategoryById(categoryId) == null)
                throw new ElementNotFoundException(categoryId);

            var categoryToRemove = DbUnitOfWork.ProductCategories.GetById(categoryId);
            DbUnitOfWork.ProductCategories.Remove(categoryToRemove);
        }

        public IEnumerable<ProductDto> GetProductsByCategoryId(int categoryId)
        {
            var categoryProducts = (from product in DbUnitOfWork.Products.GetAll()
                                    where product.Category.Id == categoryId
                                    select product).ToList();

            if (!categoryProducts.Any())
                throw new ElementNotFoundException(categoryId);

            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(categoryProducts);
        }

        public IEnumerable<SupplierDto> GetSuppliersBySupplierId(int categoryId)
        {
            var categorySuppliers = (from supplier in DbUnitOfWork.Suppliers.GetAll()
                                     where supplier.Products.Any(product => product.Category.Id == categoryId)
                                     select supplier).ToList();

            if (!categorySuppliers.Any())
                throw new ElementNotFoundException(categoryId);

            return Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDto>>(categorySuppliers);
        }

        public IEnumerable<ProductCategoryDto> GetProductCategoriesByPredicate(string predicate)
        {
            var productCategories = GetAllCategories().Where(predicate).ToList();
                                   
            if (!productCategories.Any())
                throw new ElementNotFoundException("Can't find elements by predicate");

            return productCategories;
        }

        ~ProductCategoriesService()
        {
            Dispose(false);
        }
    }
}
