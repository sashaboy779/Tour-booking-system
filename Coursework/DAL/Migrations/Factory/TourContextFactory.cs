using DAL.EF;
using System.Data.Entity.Infrastructure;

namespace DAL.Migrations.Factory
{
    public class TourContextFactory : IDbContextFactory<TourContext>
    {
        public TourContext Create()
        {
            return new TourContext("Tour");
        }
    }
}
