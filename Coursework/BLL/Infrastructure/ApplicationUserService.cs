using AutoMapper;
using BLL.Infrastructure.DTO;
using BLL.Infrastructure.Interface;
using DAL.Identity;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class ApplicationUserService : IApplicationUserService
    {
        private UserManager<ApplicationUser> manager;
        private IMapper mapper;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            manager = userManager;
            this.mapper = mapper;
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
            var appUser = mapper.Map<ApplicationUser>(user);
            return await manager.CreateAsync(appUser, password);
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUserDTO user)
        {
            var appUser = mapper.Map<ApplicationUser>(user);
            return await manager.DeleteAsync(appUser);
        }

        public async Task<ApplicationUserDTO> FindByIdAsync(string id)
        {   
            var appUser = await manager.FindByIdAsync(id);
            return mapper.Map<ApplicationUserDTO>(appUser);
        }

        public async Task<ApplicationUserDTO> FindByNameAsync(string username)
        {
            var appUser = await manager.FindByNameAsync(username);
            return mapper.Map<ApplicationUserDTO>(appUser);
        }

        public List<ApplicationUserDTO> GetAllUsers()
        {
            return mapper.Map<List<ApplicationUserDTO>>(manager.Users.ToList());
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
