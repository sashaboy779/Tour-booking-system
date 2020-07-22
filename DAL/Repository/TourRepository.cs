using DAL.EF;
using DAL.Entity;

namespace DAL.Repository
{
    public class TourRepository : BaseRepository<Tour>
    {
        public TourRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
