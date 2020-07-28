using BLL.Infrastructure.Interface;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly IApplicationUserService userService;
        protected readonly IRoleService roleService;

        public BaseApiController(IApplicationUserService userService, IRoleService roleService)
        {
            this.roleService = roleService;
            this.userService = userService;
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}