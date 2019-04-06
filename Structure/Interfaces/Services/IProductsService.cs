using System;
using System.Collections.Generic;
using BllEntities.DTO;

namespace Structure.Interfaces.Services
{
    public interface IProductsService: IDisposable
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(int productId);
        void AddProduct(ProductDto product);
        void UpdateProduct(ProductDto product);
        void DeleteProductById(int product);
        void ApplyChanges();
    }
}
