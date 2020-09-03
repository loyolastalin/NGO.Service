using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace NGO.Wepapi.Filters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(ArgumentException))
            {
                status = HttpStatusCode.NotFound;
            }
       
            var errorResponse =
               context.Request.CreateErrorResponse(status, context.Exception.Message);
            context.Response = errorResponse;

            base.OnException(context);
        }
    }
}