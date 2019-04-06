using System;
using System.Collections.Generic;
using BllEntities.DTO;
namespace Structure.Interfaces.Services
{
    public interface IProductCategoriesService : IDisposable
    {
        IEnumerable<ProductCategoryDto> GetAllCategories();
        ProductCategoryDto GetCategoryById(int categoryId);
        void AddProductCategory(ProductCategoryDto category);
        void UpdateProductCategory(ProductCategoryDto category);
        void DeleteCategoryById(int id);
        IEnumerable<ProductDto> GetProductsByCategoryId(int categoryId);
        IEnumerable<SupplierDto> GetSuppliersBySupplierId(int categoryId);
        IEnumerable<ProductCategoryDto> GetProductCategoriesByPredicate(string predicate);
        void ApplyChanges();
    }
}
