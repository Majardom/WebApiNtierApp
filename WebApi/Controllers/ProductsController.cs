using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using BllEntities.DTO;
using Structure.Interfaces.Services;

namespace WebApi.Controllers
{
    /// <summary>
    ///   ApiController to work with products.
    /// </summary>
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController, IDisposable
    {
        /// <summary>
        ///     Products service.
        /// </summary>
        private readonly IProductsService _service;

        /// <summary>
        ///  Initializes apiController to work with products.
        /// </summary>
        /// <param name="service">Products service.</param>
        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        /// <summary>
        ///   Method to get all products. Supports OData filters.
        /// </summary>
        /// <returns>Collection of ProductDto in HttpResponseMessage.</returns>
        [HttpGet]
        [Route("")]
        [EnableQuery]
        public HttpResponseMessage GetAllProducts()
        {
            var products = _service.GetAllProducts();
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        /// <summary>
        ///     Method to get product by id.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>Founded product in HttpResponseMessage.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetProductById(int id)
        {
            var product = _service.GetProductById(id);
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        /// <summary>
        ///     Method to add product. 
        /// </summary>
        /// <param name="product">Product object from request body.</param>
        /// <returns>Http response message.</returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddProduct([FromBody]ProductDto product)
        {
            _service.AddProduct(product);
            _service.ApplyChanges();
            return Request.CreateResponse(HttpStatusCode.OK, $"Product added {product.Name}");
        }


        /// <summary>
        ///     Updates data for existing product object.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="product">Product object.</param>
        /// <returns>Http response message.</returns>
        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage UpdateProductCategory(int id, [FromBody]ProductDto product)
        {
            product.Id = id;
            _service.UpdateProduct(product);
            _service.ApplyChanges();
            return Request.CreateResponse(HttpStatusCode.OK, $"Product updated{product.Name}");
        }


        /// <summary>
        ///     Deletes existing product object.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>Http response message.</returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage DeleteProductCategoryById(int id)
        {
            _service.DeleteProductById(id);
            _service.ApplyChanges();
            return Request.CreateResponse(HttpStatusCode.OK, $"Product {id} deleted ");
        }

         protected override void Dispose(bool disposing)
        {
            if (disposing)
                _service?.Dispose();

            base.Dispose(disposing);
        }
    }
}
