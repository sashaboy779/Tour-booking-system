using DAL.EF;
using DAL.Entity;

namespace DAL.Repository
{
    public class ResortRepository : BaseRepository<Resort>
    {
        public ResortRepository(TourContext dbContext) : base(dbContext)
        {
        }
    }
}
