using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
