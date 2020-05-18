using DAL.Entity;
using DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Resort> Resorts { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourVariant> TourVariants { get; set; }

        public ApplicationDbContext(string connectionStringName) : base(connectionStringName, throwIfV1Schema: false)
        {
        }
    }
}
