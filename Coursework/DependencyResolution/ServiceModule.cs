using BLL.Infrastructure;
using BLL.Infrastructure.Interface;
using Ninject.Modules;

namespace DependencyResolution
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoleService>().To<RoleService>();
            Bind<IApplicationUserService>().To<ApplicationUserService>();
        }
    }
}
