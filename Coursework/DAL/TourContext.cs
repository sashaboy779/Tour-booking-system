using DAL.Entity;
using System.Data.Entity;

namespace DAL
{
    public class TourContext : DbContext
    {
        public DbSet<Resort> Resorts { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourVariant> TourVariants { get; set; }

        public TourContext() : base("name=Tour")
        {
        }

        public TourContext(string connectionStringName) : base(connectionStringName)
        {
        }
    }
}
