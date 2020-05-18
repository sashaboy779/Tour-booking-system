using BLL.Dto.Enums;
using BLL.Dto.Responses;

namespace BLL.Dto.Requests
{
    public class TourVariantPostRequest
    {
        public int TourId { get; set; }
        public double PersonPrice { get; set; }
        public int TicketsNumber { get; set; }
        public RoomType RoomType { get; set; }
        public Food Food { get; set; }
        public virtual TravelDto Travel { get; set; }
    }
}