using System;
using DAL.Entity;

namespace DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Resort> Resorts { get; }
        IRepository<Tour> Tours { get; }
        IRepository<TourVariant> TourVariants { get; }
        void Save();
    }
}
