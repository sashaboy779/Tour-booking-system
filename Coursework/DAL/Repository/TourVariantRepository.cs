using System.Data.Entity;
using DAL.EF;
using DAL.Entity;

namespace DAL.Repository
{
    public class TourVariantRepository : BaseRepository<TourVariant>
    {
        public TourVariantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override void Update(TourVariant item)
        {
            base.Update(item);
            db.Entry(item.Travel).State = EntityState.Modified;
        }

        public override void Delete(TourVariant item)
        {
            db.Set<Travel>().Remove(item.Travel);
            base.Delete(item);
        }
    }
}
