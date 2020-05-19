using System.Collections.Generic;

namespace DAL.Entity
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TourType Type { get; set; }
        public double Rating { get; set; }
        public int ResortId { get; set; }
        public virtual Resort Resort { get; set; }
        public virtual List<TourVariant> TourVariants { get; set; }
    }
}