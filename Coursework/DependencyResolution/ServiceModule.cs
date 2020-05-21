using BLL.Infrastructure;
using BLL.Infrastructure.Interface;
using BLL.Interface;
using BLL.Services;
using BLL.Services.Interface;
using Ninject.Modules;

namespace DependencyResolution
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoleService>().To<RoleService>();
            Bind<IApplicationUserService>().To<ApplicationUserService>();
            Bind<IResortService, ResortService>();
            Bind<IToursService, ToursService>();
            Bind<IResortService, ResortService>();
            Bind<ISearchService>().To<SearchService>();
        }
    }
}
