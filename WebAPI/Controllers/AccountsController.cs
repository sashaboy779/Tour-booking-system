using BLL.Infrastructure.DTO;
using BLL.Infrastructure.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	[Authorize(Roles = "Admin")]
	[RoutePrefix("api/accounts")]
	public class AccountsController : BaseApiController
	{
		public AccountsController(IApplicationUserService userService, IRoleService roleService)
			: base(userService, roleService)
		{
		}

		[HttpGet]
		[Route("users")]
		public IHttpActionResult GetUsers()
		{
			var user = userService.GetAllUsers();
			return Ok(user);
		}

		[HttpGet]
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

		[HttpGet]
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

		[HttpPost]
		[AllowAnonymous]
		[Route("create")]
		public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (createUserModel == null)
				return BadRequest("Error. Model is empty");

			var user = new ApplicationUserDto()
			{
				UserName = createUserModel.Username,
				Email = createUserModel.Email,
				FirstName = createUserModel.FirstName,
				LastName = createUserModel.LastName
			};

			var addUserResult = await userService.CreateAsync(user, createUserModel.Password);
			if (!addUserResult.Succeeded)
				return GetErrorResult(addUserResult);

			await AssignRolesToUser(user.Id, new[] { "User" });
			var locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));
			return Created(locationHeader, user);
		}

		[HttpDelete]
		[Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
		{
			var user = await userService.FindByIdAsync(id);

			if (user == null) return NotFound();
			var result = await userService.DeleteAsync(user);

			if (!result.Succeeded)
			{
				return GetErrorResult(result);
			}
			return Ok();
		}

        [HttpPut]
		[Route("user/{id:guid}/roles")]
		public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
		{
			var user = await userService.FindByIdAsync(id);
			if (user == null)
				return NotFound();

			var currentRoles = await userService.GetRolesAsync(user.Id);
			var rolesNotExists = rolesToAssign.Except(roleService.GetRoles().Select(x => x.Name)).ToArray();

			if (rolesNotExists.Any())
				return RolesNotExists(rolesNotExists);

			var removeResult = await userService.RemoveFromRolesAsync(user.Id, currentRoles.ToArray());
			if (!removeResult.Succeeded)
				return FailRemoveRole();

			var addResult = await userService.AddToRolesAsync(user.Id, rolesToAssign);
			if (!addResult.Succeeded)
				return FailAddToRole();
			return Ok();
		}
		
		private IHttpActionResult RolesNotExists(string[] roles)
		{
			ModelState.AddModelError("",
				$"Roles '{string.Join(",", roles)}' does not exists in the system");
			return BadRequest(ModelState);
		}

		private IHttpActionResult FailRemoveRole()
		{
			ModelState.AddModelError("", "Failed to remove user roles");
			return BadRequest(ModelState);
		}

		private IHttpActionResult FailAddToRole()
		{
			ModelState.AddModelError("", "Failed to add user roles");
			return BadRequest(ModelState);
		}
	}
}