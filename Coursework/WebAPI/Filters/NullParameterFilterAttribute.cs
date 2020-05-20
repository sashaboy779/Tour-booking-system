using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI.Filters
{
    public class NullParameterFilterAttribute : ActionFilterAttribute
    {
        private readonly string _parameterName;

        public NullParameterFilterAttribute(string parameterName)
        {
            _parameterName = parameterName;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.TryGetValue(_parameterName, out var parameterValue))
            {
                if (parameterValue == null)
                {
                    
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                        $"The {_parameterName} cannot be null.");
                }
            }
        }
    }
}