using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using ProductsBLL.Exceptions;

namespace WebApi.Exceptions
{
    public class NotFoundExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        ///  Filter which handles errors related to model state validation.
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ElementNotFoundException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);   
            }
        }
    }
}