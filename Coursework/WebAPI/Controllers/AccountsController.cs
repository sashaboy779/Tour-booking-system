using BLL.Infrastructure.DTO;
using BLL.Infrastructure.Interface;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{

	[RoutePrefix("api/accounts")]
	public class AccountsController : BaseApiController
	{
		public AccountsController(IApplicationUserService userService, IRoleService roleService)
			: base(userService, roleService)
		{
		}

		[Authorize(Roles = "Admin")]
		[Authorize]
		[Route("users")]
		public IHttpActionResult GetUsers()
		{
			var user = userService.GetAllUsers();
			return Ok(user);
		}

		[Authorize(Roles = "Admin")]
		[Route("user/{id:guid}", Name = "GetUserById")]
		public async Task<IHttpActionResult> GetUser(string Id)
		{
			var user = await userService.FindByIdAsync(Id);

			if (user != null)
			{
				return Ok(user);
			}
			return NotFound();
		}

		[Authorize(Roles = "Admin")]
		[Route("user/{username}")]
		public async Task<IHttpActionResult> GetUserByName(string username)
		{
			var user = await userService.FindByNameAsync(username);

			if (user != null)
			{
				return Ok(user);
			}
			return NotFound();
		}

		[AllowAnonymous]
		[Route("create")]
		public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (createUserModel == null)
				return BadRequest("Error. Model is empty");

			var user = new ApplicationUserDTO()
			{
				UserName = createUserModel.Username,
				Email = createUserModel.Email,
				FirstName = createUserModel.FirstName,
				LastName = createUserModel.LastName
			};

			IdentityResult addUserResult = await userService.CreateAsync(user, createUserModel.Password);
			if (!addUserResult.Succeeded)
				return GetErrorResult(addUserResult);

			await AssignRolesToUser(user.Id, new string[] { "User" });
			Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));
			return Created(locationHeader, user);
		}

		[Authorize(Roles = "Admin")]
		[Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
		{
			var user = await userService.FindByIdAsync(id);

			if (user != null)
			{
				IdentityResult result = await userService.DeleteAsync(user);

				if (!result.Succeeded)
				{
					return GetErrorResult(result);
				}
				return Ok();
			}
			return NotFound();
		}

		[Authorize(Roles = "Admin")]
		[Route("user/{id:guid}/roles")]
		[HttpPut]
		public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
		{
			var user = await userService.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			var currentRoles = await userService.GetRolesAsync(user.Id);
			var rolesNotExists = rolesToAssign.Except(roleService.GetRoles().Select(x => x.Name)).ToArray();

			if (rolesNotExists.Count() > 0)
			{
				ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
				return BadRequest(ModelState);
			}

			IdentityResult removeResult = await userService.RemoveFromRolesAsync(user.Id, currentRoles.ToArray());
			if (!removeResult.Succeeded)
			{
				ModelState.AddModelError("", "Failed to remove user roles");
				return BadRequest(ModelState);
			}

			IdentityResult addResult = await userService.AddToRolesAsync(user.Id, rolesToAssign);
			if (!addResult.Succeeded)
			{
				ModelState.AddModelError("", "Failed to add user roles");
				return BadRequest(ModelState);
			}
			return Ok();
		}
	}
}