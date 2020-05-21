using BLL.Infrastructure.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	[RoutePrefix("api/roles")]
    [Authorize(Roles = "Admin, Manager")]
    public class RolesController : BaseApiController
    {
        public RolesController(IApplicationUserService userService, IRoleService roleService)
            : base(userService, roleService)
        {
        }

        [Route("{id:guid}", Name = "GetRoleById")]
        public async Task<IHttpActionResult> GetRole(string Id)
        {
            var role = await roleService.FindByIdAsync(Id);
            if (role != null)
            {
                return Ok(role);
            }
            return NotFound();
        }

        [Route("", Name = "GetAllRoles")]
        public IHttpActionResult GetAllRoles()
        {
            var roles = roleService.GetRoles();
            return Ok(roles);
        }

        [Route("create")]
        public async Task<IHttpActionResult> Create(CreateRoleBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = new IdentityRole { Name = model.Name };
            var result = await this.roleService.CreateAsync(role);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            Uri locationHeader = new Uri(Url.Link("GetRoleById", new { id = role.Id }));
            return Created(locationHeader, role);
        }

        [Route("{id:guid}")]
        public async Task<IHttpActionResult> DeleteRole(string Id)
        {
            var role = await this.roleService.FindByIdAsync(Id);

            if (role != null)
            {
                IdentityResult result = await this.roleService.DeleteAsync(role);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                return Ok();
            }
            return NotFound();
        }

        [Route("ManageUsersInRole")]
        public async Task<IHttpActionResult> ManageUsersInRole(UsersInRoleModel model)
        {
            var role = await this.roleService.FindByIdAsync(model.Id);

            if (role == null)
            {
                ModelState.AddModelError("", "Role does not exist");
                return BadRequest(ModelState);
            }

            await AddToRole(model.EnrolledUsers, role.Name);
            await RemoveFromRole(model.RemovedUsers, role.Name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        private async Task AddToRole(List<string> usersId, string roleName)
        {
            foreach (string user in usersId)
            {
                var appUser = await userService.FindByIdAsync(user);

                if (appUser == null)
                {
                    ModelState.AddModelError("", String.Format("User: {0} does not exists", user));
                    continue;
                }

                if (!userService.IsInRole(user, roleName))
                {
                    IdentityResult result = await userService.AddToRoleAsync(user, roleName);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", String.Format("User: {0} could not be added to role", user));
                    }
                }
            }
        }

        private async Task RemoveFromRole(List<string> usersId, string roleName)
        {
            foreach (string user in usersId)
            {
                var appUser = await userService.FindByIdAsync(user);

                if (appUser == null)
                {
                    ModelState.AddModelError("", String.Format("User: {0} does not exists", user));
                    continue;
                }

                IdentityResult result = await userService.RemoveFromRoleAsync(user, roleName);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", String.Format("User: {0} could not be removed from role", user));
                }
            }
        }
    }
}
