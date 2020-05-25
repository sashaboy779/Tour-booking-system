using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dto.TourBooking;

namespace BLL.Services.Interface
{
    public interface IBookingService
    {
        void BookTour(Booking booking);
        void CancelTourBooking(Booking booking);   
    }
}
