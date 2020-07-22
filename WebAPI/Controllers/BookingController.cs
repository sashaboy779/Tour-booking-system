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
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPut]
        [Route("bookTour")]
        public IHttpActionResult BookTour(Booking booking)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if (User.Identity.GetUserId() != booking.UserId)
                return BadRequest("Current user id does not match id from request");
            _bookingService.BookTour(booking);
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
            _bookingService.CancelTourBooking(booking);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
