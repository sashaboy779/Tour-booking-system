using Ninject.Modules;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Identity;
using DAL.EF;
using Ninject;

namespace DependencyResolution
{
    public class IdentityModule : NinjectModule
    {
        public override void Load()
        {
            Bind<RoleManager<IdentityRole>>().To<ApplicationRoleManager>();
            Bind<UserManager<ApplicationUser>>().To<ApplicationUserManager>();

            Bind<RoleStore<IdentityRole>>().ToSelf().WithConstructorArgument("context", context => 
                KernelInstance.Get<ApplicationDbContext>());
            Bind<UserStore<ApplicationUser>>().ToSelf().WithConstructorArgument("context", context =>
                KernelInstance.Get<ApplicationDbContext>());
        }
    }
}
