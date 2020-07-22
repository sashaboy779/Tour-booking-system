using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Infrastructure.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BLL.Infrastructure
{
    public class RoleService : IRoleService
    {
        private RoleManager<IdentityRole> manager;

        public RoleService(RoleManager<IdentityRole> manager)
        {
            this.manager = manager;
        }

        public Task<IdentityResult> CreateAsync(IdentityRole role)
        {
            return manager.CreateAsync(role);
        }

        public Task<IdentityResult> DeleteAsync(IdentityRole role)
        {
            return manager.DeleteAsync(role);
        }

        public Task<IdentityRole> FindByIdAsync(string id)
        {
            return manager.FindByIdAsync(id);
        }

        public List<IdentityRole> GetRoles()
        {
            return manager.Roles.ToList();
        }
    }
}
