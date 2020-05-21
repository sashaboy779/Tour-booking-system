﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebAPI.Filters
{
    public class KeyNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is KeyNotFoundException)
            {
                context.Response = context.Request.CreateResponse(
                    HttpStatusCode.NotFound,
                    new
                    {
                        message = context.Exception.Message
                    });
            }
        }
    }
}