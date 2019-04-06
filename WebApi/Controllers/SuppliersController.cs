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
    ///   ApiController to work with suppliers.
    /// </summary>
    [RoutePrefix("api/suppliers")]
    public class SuppliersController : ApiController, IDisposable
    {
        /// <summary>
        ///     Suppliers service.
        /// </summary>
        private readonly ISuppliersService _service;

        /// <summary>
        ///  Initializes apiController to work with suppliers.
        /// </summary>
        /// <param name="service">Suppliers service.</param>
        public SuppliersController(ISuppliersService service)
        {
            _service = service;
        }

        /// <summary>
        ///   Method to get all suppliers. Supports OData filters.
        /// </summary>
        /// <returns>Collection of SuppliersDto in HttpResponseMessage.</returns>
        [HttpGet]
        [Route("")]
        [EnableQuery]
        public HttpResponseMessage GetAllSuppliers()
        {
            var suppliers = _service.GetAllSuppliers();
            return Request.CreateResponse(HttpStatusCode.OK, suppliers);
        }

        /// <summary>
        ///     Method to get suppliers by id.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>Founded product in HttpResponseMessage.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetSupplierById(int id)
        {
            var supplier = _service.GetSupplierById(id);
            return Request.CreateResponse(HttpStatusCode.OK, supplier);
        }

        /// <summary>
        ///     Method to add supplier. 
        /// </summary>
        /// <param name="supplier">Supplier object from request body.</param>
        /// <returns>Http response message.</returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddSupplier([FromBody]SupplierDto supplier)
        {
            _service.AddSupplier(supplier);
            _service.ApplyChanges();
            return Request.CreateResponse(HttpStatusCode.OK, $"Suppliers added {supplier.Name}");
        }

        /// <summary>
        ///     Updates data for existing supplier object.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="supplier">Product object.</param>
        /// <returns>Http response message.</returns>
        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage UpdateSupplier(int id, [FromBody]SupplierDto supplier)
        {
            supplier.Id = id;
            _service.UpdateSupplier(supplier);
            _service.ApplyChanges();
            return Request.CreateResponse(HttpStatusCode.OK, $"Suppliers updated{supplier.Name}");
        }

        /// <summary>
        ///     Deletes existing supplier object.
        /// </summary>
        /// <param name="id">Supplier id.</param>
        /// <returns>Http response message.</returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage DeleteSupplierById(int id)
        {
            _service.DeleteSupplierById(id);
            _service.ApplyChanges();
            return Request.CreateResponse(HttpStatusCode.OK, $"Suppliers {id} deleted ");
        }

        /// <summary>
        ///   Method to get supplied products.
        /// </summary>
        /// <param name="id">Supplier id.</param>
        /// <returns>HttpResponseMessage with collection of ProductDto.</returns>
        [HttpGet]
        [Route("{id:int}/products")]
        public HttpResponseMessage GetSuppliedProducts(int id)
        {
            var products = _service.GetSuppliedProducts(id);
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _service?.Dispose();

            base.Dispose(disposing);
        }
    }
}
