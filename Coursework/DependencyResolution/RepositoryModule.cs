using DAL;
using DAL.EF;
using DAL.Entity;
using DAL.Interface;
using DAL.Repository;
using Ninject.Modules;
using System.Data.Entity;

namespace DependencyResolution
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Resort>>().To<ResortRepository>();
            Bind<IRepository<Tour>>().To<TourRepository>();
            Bind<IRepository<TourVariant>>().To<TourVariantRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            
            Bind<ApplicationDbContext>().ToSelf().WithConstructorArgument("connectionStringName", "Tour");
        }
    }
}
