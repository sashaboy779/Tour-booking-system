using DAL;
using DAL.Entity;
using DAL.Interface;
using DAL.Repository;
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
            Bind<TourContext>().ToSelf();
        }
    }
}
