using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using BLL.Dto.Enums;
using BLL.Dto.Responses;


namespace BLL.Dto.Requests
{
    public class TourVariantUpdateRequest
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public double PersonPrice { get; set; }
        public int TicketsNumber { get; set; }
        public RoomType RoomType { get; set; }
        public Food Food { get; set; }
        public virtual TravelUpdateRequest Travel { get; set; }
    }
}
