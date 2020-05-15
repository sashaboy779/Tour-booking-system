using DAL.EF;
using DAL.Entity;

namespace DAL.Repository
{
    public class TourVariantRepository : BaseRepository<TourVariant>
    {
        public TourVariantRepository(TourContext dbContext) : base(dbContext)
        {
        }
    }
}
