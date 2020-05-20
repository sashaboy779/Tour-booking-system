﻿using BLL.Infrastructure;
using BLL.Infrastructure.Interface;
using BLL.Interface;
using BLL.Services;
using Ninject.Modules;

namespace DependencyResolution
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoleService>().To<RoleService>();
            Bind<IApplicationUserService>().To<ApplicationUserService>();
            Bind<IResortService>().To<ResortService>();
            Bind<IToursService>().To<ToursService>();
            Bind<ITourVariantService>().To<TourVariantsService>();
        }
    }
}
