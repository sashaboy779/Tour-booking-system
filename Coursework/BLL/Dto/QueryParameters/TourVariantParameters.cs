using BLL.Dto.Enums;

namespace BLL.Dto.QueryParameters
{
    public class TourVariantParameters
    {
        public int TourId { get; set; }
        public int MinTourists { get; set; } 
        public int MaxTourists{ get; set; }
        public double MinPersonPrice { get; set; }
        public double MaxPersonPrice { get; set; }
        public RoomType? Room { get; set; }
        public Food? Food { get; set; }
        public TransportType? Transport { get; set; }            
        public bool TravelIncluded { get; set; }
    }
}