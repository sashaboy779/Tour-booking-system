using DAL;
using DAL.EF;
using DAL.Entity;
using DAL.Repository;
using DAL.Repository.Interface;
using Ninject.Modules;

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
