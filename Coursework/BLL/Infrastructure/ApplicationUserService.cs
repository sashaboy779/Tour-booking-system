using BLL.Infrastructure.DTO;
using BLL.Infrastructure.Interface;
using DAL.Identity;
using Microsoft.AspNet.Identity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class ApplicationUserService : IApplicationUserService
    {
        private UserManager<ApplicationUser> manager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager)
        {
            manager = userManager;
        }

        public async Task<IdentityResult> AddToRoleAsync(string user, string roleName)
        {
            return await manager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> AddToRolesAsync(string id, string[] rolesToAssign)
        {
            return await manager.AddToRolesAsync(id, rolesToAssign);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUserDTO user, string password)
        {
            // add map
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            }; 

            return await manager.CreateAsync(applicationUser, password);
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUserDTO user)
        {
            // add map
            ApplicationUser applicationUser = new ApplicationUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return await manager.DeleteAsync(applicationUser);
        }

        public async Task<ApplicationUserDTO> FindByIdAsync(string id)
        {   
            var appUser = await manager.FindByIdAsync(id);
            ApplicationUserDTO user = new ApplicationUserDTO
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email
            };

            return user;
        }

        public async Task<ApplicationUserDTO> FindByNameAsync(string username)
        {
            var appUser = await manager.FindByNameAsync(username);
            ApplicationUserDTO user = new ApplicationUserDTO
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email
            };

            return user;
        }

        public List<ApplicationUserDTO> GetAllUsers()
        {
            var appUsers = manager.Users.ToList();
            return new List<ApplicationUserDTO>();
        }

        public async Task<IList<string>> GetRolesAsync(string id)
        {
            return await manager.GetRolesAsync(id);
        }

        public bool IsInRole(string user, string roleName)
        {
            return manager.IsInRole(user, roleName);
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(string user, string roleName)
        {
            return await manager.RemoveFromRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> RemoveFromRolesAsync(string id, string[] roles)
        {
            return await manager.RemoveFromRolesAsync(id, roles);
        }
    }
}
