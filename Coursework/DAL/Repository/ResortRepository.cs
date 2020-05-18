using DAL.EF;
using DAL.Entity;

namespace DAL.Repository
{
    public class ResortRepository : BaseRepository<Resort>
    {
        public ResortRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
