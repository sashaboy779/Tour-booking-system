using DAL.Entity;

namespace DAL.Repository
{
    public class TourRepository : BaseRepository<Tour>
    {
        public TourRepository(TourContext dbContext) : base(dbContext)
        {
        }
    }
}
