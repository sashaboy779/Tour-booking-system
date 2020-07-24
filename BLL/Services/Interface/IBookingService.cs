using BLL.Dto.TourBooking;

namespace BLL.Services.Interface
{
    public interface IBookingService
    {
        void BookTour(Booking booking);
        void CancelTourBooking(Booking booking);   
    }
}
