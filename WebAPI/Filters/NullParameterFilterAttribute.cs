using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI.Filters
{
    public class NullParameterFilterAttribute : ActionFilterAttribute
    {
        private readonly string parameterName;

        public NullParameterFilterAttribute(string parameterName)
        {
            this.parameterName = parameterName;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.TryGetValue(parameterName, out var parameterValue))
            {
                if (parameterValue == null)
                {
                    
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                        $"The {parameterName} cannot be null.");
                }
            }
        }
    }
}