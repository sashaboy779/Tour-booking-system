using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebAPI.Filters
{
    public class InvalidOperationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is InvalidOperationException)
            {
                context.Response = context.Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        message = context.Exception.Message
                    });
            }
        }
    }
}