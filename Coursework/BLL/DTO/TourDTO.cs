using System.Collections.Generic;

namespace BLL.DTO
{
    public class TourDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TourTypeDTO Type { get; set; }
        public double Rating { get; set; }
        public virtual List<TourVariantDTO> TourVariants { get; set; }
    }
}