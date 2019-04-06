using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using ProductsBLL.Exceptions;

namespace WebApi.Attributes
{
    public class NotFoundExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ElementNotFoundException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);   
            }
        }
    }
}