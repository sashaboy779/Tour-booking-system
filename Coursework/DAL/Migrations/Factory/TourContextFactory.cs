using DAL.EF;
using System.Data.Entity.Infrastructure;

namespace DAL.Migrations.Factory
{
    public class TourContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext("Tour");
        }
    }
}
