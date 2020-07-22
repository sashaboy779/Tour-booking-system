using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace BLL.Dto.Responses
{
    public class TourVariantDto 
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int TouristsNumber{ get; set; }
        public double PersonPrice { get; set; }
        public int TicketsNumber { get; set; }
        public RoomType RoomType { get; set; }
        public Food Food { get; set; }
        public virtual Travel Travel { get; set; }
    }
}
