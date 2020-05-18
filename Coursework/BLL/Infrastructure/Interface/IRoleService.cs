using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Interface
{
    public interface IRoleService
    {
        List<IdentityRole> GetRoles();
        Task<IdentityRole> FindByIdAsync(string id);
        Task<IdentityResult> CreateAsync(IdentityRole role);
        Task<IdentityResult> DeleteAsync(IdentityRole role);
    }
}
