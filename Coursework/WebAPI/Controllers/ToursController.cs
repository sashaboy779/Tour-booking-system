using System.Net;
using System.Web.Http;
using BLL.Dto.Requests;
using BLL.Interface;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [KeyNotFoundExceptionFilter]
    [RoutePrefix("api/tours")]
    [Authorize(Roles = "Admin, Moderator")]
    public class ToursController : ApiController
    {
        private readonly IToursService _toursService;
        private readonly ITourVariantService _tourVariantService;
        
        public ToursController(IToursService toursService, ITourVariantService tourVariantService)
        {
            _toursService = toursService;
            _tourVariantService = tourVariantService;
        }

        [Route("{id}", Name = "GetTour")]
        [HttpGet]
        public IHttpActionResult GetTour(int id)
        {
            var tour = _toursService.GetTour(id);
            return Ok(tour);
        }

        [HttpGet]
        public IHttpActionResult GetTours()
        {
            var tours = _toursService.GetTours();
            return Ok(tours);
        }

        [Route("{id}/variants")]
        [HttpGet]
        public IHttpActionResult GetTourVariants(int id)
        {
            var tourVariants = _tourVariantService.GetByTour(id);
            return Ok(tourVariants);
        }

        [HttpPost]
        [NullParameterFilter("request")]
        public IHttpActionResult AddTour(TourPostRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var tour = _toursService.AddTour(request);
            return Created(Url.Link("GetTour", new {id = tour.Id}), tour);
        }

        [HttpPut]
        [NullParameterFilter("request")]
        public IHttpActionResult UpdateTour(TourUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _toursService.UpdateTour(request);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTour(int id)
        {
            _toursService.DeleteTour(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
