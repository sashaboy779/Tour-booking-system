using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entity;

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
    }
}
