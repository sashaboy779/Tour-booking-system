using DAL.Identity;
using System.Collections.Generic;

namespace DAL.Entity
{
    public class TourVariant
    {
        public int Id { get; set; }
        public int TouristsNumber{ get; set; }
        public double PersonPrice { get; set; }
        public int TicketsNumber { get; set; }
        public RoomType RoomType { get; set; }
        public Food Food { get; set; }
        public virtual Travel Travel { get; set; }
        public virtual List<ApplicationUser> Tourists { get; set; }
    }
}