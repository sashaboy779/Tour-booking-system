using BLL.Infrastructure.DTO;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Interface
{
    public interface IApplicationUserService
    {
        bool IsInRole(string user, string roleName);
        List<ApplicationUserDto> GetAllUsers();
        Task<ApplicationUserDto> FindByIdAsync(string id);
        Task<ApplicationUserDto> FindByNameAsync(string username);
        Task<IdentityResult> CreateAsync(ApplicationUserDto user, string password);
        Task<IdentityResult> DeleteAsync(ApplicationUserDto user);
        Task<IList<string>> GetRolesAsync(string id);
        Task<IdentityResult> RemoveFromRolesAsync(string id, string[] roles);
        Task<IdentityResult> AddToRolesAsync(string id, string[] rolesToAssign);
        Task<IdentityResult> AddToRoleAsync(string user, string roleName);
        Task<IdentityResult> RemoveFromRoleAsync(string user, string roleName);
    }
}
