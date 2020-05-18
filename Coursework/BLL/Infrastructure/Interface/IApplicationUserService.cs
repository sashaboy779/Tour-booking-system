using BLL.Infrastructure.DTO;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Interface
{
    public interface IApplicationUserService
    {
        bool IsInRole(string user, string roleName);
        List<ApplicationUserDTO> GetAllUsers();
        Task<ApplicationUserDTO> FindByIdAsync(string id);
        Task<ApplicationUserDTO> FindByNameAsync(string username);
        Task<IdentityResult> CreateAsync(ApplicationUserDTO user, string password);
        Task<IdentityResult> DeleteAsync(ApplicationUserDTO user);
        Task<IList<string>> GetRolesAsync(string id);
        Task<IdentityResult> RemoveFromRolesAsync(string id, string[] roles);
        Task<IdentityResult> AddToRolesAsync(string id, string[] rolesToAssign);
        Task<IdentityResult> AddToRoleAsync(string user, string roleName);
        Task<IdentityResult> RemoveFromRoleAsync(string user, string roleName);
    }
}
