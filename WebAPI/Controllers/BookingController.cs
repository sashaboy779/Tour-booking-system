using System.Net;
using System.Web.Http;
using BLL.Dto.TourBooking;
using BLL.Services.Interface;
using Microsoft.AspNet.Identity;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [Authorize]
    [InvalidOperationExceptionFilter]
    [KeyNotFoundExceptionFilter]
    [RoutePrefix("api/booking")]
    public class BookingController : ApiController
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpPut]
        [Route("bookTour")]
        public IHttpActionResult BookTour(Booking booking)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if (User.Identity.GetUserId() != booking.UserId)
                return BadRequest("Current user id does not match id from request");
            bookingService.BookTour(booking);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("cancelBooking")]
        public IHttpActionResult CancelBooking(Booking booking)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if (User.Identity.GetUserId() != booking.UserId)
                return BadRequest("Current user id does not match id from request");
            bookingService.CancelTourBooking(booking);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
