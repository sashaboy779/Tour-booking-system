using System.ComponentModel.DataAnnotations;


namespace BLL.Dto.TourBooking
{
    public class Booking
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int TourVariantId { get; set; }
    }
}
