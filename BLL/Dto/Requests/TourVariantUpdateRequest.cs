using System.ComponentModel.DataAnnotations;
using BLL.Dto.Enums;

namespace BLL.Dto.Requests
{
    public class TourVariantUpdateRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public double PersonPrice { get; set; }
        [Required]
        public int TicketsNumber { get; set; }
        [Required]
        public RoomType RoomType { get; set; }
        [Required]
        public Food Food { get; set; }
        [Required]
        public virtual TravelUpdateRequest Travel { get; set; }
    }
}
