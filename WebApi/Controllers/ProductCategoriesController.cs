using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using BllEntities.DTO;
using Structure.Interfaces.Services;

namespace WebApi.Controllers
{
    /// <summary>
    ///   ApiController to work with product categories.
    /// </summary>
    [RoutePrefix("api/categories")]
    public class ProductCategoriesController : ApiController
    {
        /// <summary>
        ///     Product categories service.
        /// </summary>
        private readonly IProductCategoriesService _service;

        /// <summary>
        ///  Initializes apiController to work with product categories.
        /// </summary>
        /// <param name="service">Product categories service.</param>
        public ProductCategoriesController(IProductCategoriesService service)
        {
            _service = service;
        }


        /// <summary>
        ///   Method to get all product categories. Supports OData filters.
        /// </summary>
        /// <returns>Collection of ProductCategoriesDto in HttpResponseMessage.</returns>
        [HttpGet]
        [Route("")]
        [EnableQuery]
        public HttpResponseMessage GetAllCategories()
        {
            var categories = _service.GetAllCategories();
            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }


        /// <summary>
        ///     Method to get product category by id.
        /// </summary>
        /// <param name="id">Product category id.</param>
        /// <returns>Founded product category in HttpResponseMessage.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            var category = _service.GetCategoryById(id);
            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        /// <summary>
        ///     Method to add product category. 
        /// </summary>
        /// <param name="category">Product category object from request body.</param>
        /// <returns>Http response message.</returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddProductCategory([FromBody]ProductCategoryDto category)
        {
            if(ModelState.IsValid)
            _service.AddProductCategory(category);
            _service.ApplyChanges();
            return Request.CreateResponse(HttpStatusCode.OK, $"Category added {category.Name}");
        }

        /// <summary>
        ///     Updates data for existing product category object.
        /// </summary>
        /// <param name="id">Product category id.</param>
        /// <param name="category">Product category object.</param>
        /// <returns>Http response message.</returns>
        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage UpdateProductCategory(int id, [FromBody]ProductCategoryDto category)
        {
            category.Id = id;
            _service.UpdateProductCategory(category);
            _service.ApplyChanges();
            return Request.CreateResponse(HttpStatusCode.OK, $"Category updated{category.Name}");
        }


        /// <summary>
        ///     Deletes existing product category object.
        /// </summary>
        /// <param name="id">Product category id.</param>
        /// <returns>Http response message.</returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage DeleteProductCategoryById(int id)
        {
            _service.DeleteCategoryById(id);
            _service.ApplyChanges();
            return Request.CreateResponse(HttpStatusCode.OK, $"Category {id} deleted ");
        }


        /// <summary>
        ///    Method to get products with specified product category.
        /// </summary>
        /// <param name="id">Product category id.</param>
        /// <returns>Http response message with ProductDto collection.</returns>
        [HttpGet]
        [Route("{id:int}/products")]
        public HttpResponseMessage GetProductsByCategoryId(int id)
        {
            var result = _service.GetProductsByCategoryId(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        /// <summary>
        ///    Method to get providers with specified product category.
        /// </summary>
        /// <param name="id">Product category id.</param>
        /// <returns>Http response message with ProviderDto collection.</returns>
        [HttpGet]
        [Route("{id:int}/suppliers")]
        public HttpResponseMessage GetSuppliersBySupplierId(int id)
        {
            var result = _service.GetSuppliersBySupplierId(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _service?.Dispose();

            base.Dispose(disposing);
        }
    }
}
