using BLL.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TourVariantDTO
    {
        public int Id { get; set; }
        public int TouristsNumber { get; set; }
        public double PersonPrice { get; set; }
        public int TicketsNumber { get; set; }
        public RoomTypeDTO RoomType { get; set; }
        public FoodDTO Food { get; set; }
        public virtual TravelDTO Travel { get; set; }
        public virtual List<ApplicationUserDTO> Tourists { get; set; }
    }
}
