using System.Net;
using System.Web.Http;
using BLL.Dto.Requests;
using BLL.Services.Interface;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [KeyNotFoundExceptionFilter]
    [RoutePrefix("api/tours")]
    [Authorize(Roles = "Admin, Manager")]
    public class ToursController : ApiController
    {
        private readonly IToursService toursService;
        private readonly ITourVariantService tourVariantService;
        
        public ToursController(IToursService toursService, ITourVariantService tourVariantService)
        {
            this.toursService = toursService;
            this.tourVariantService = tourVariantService;
        }

        [HttpGet]
        [Route("{id}", Name = "GetTour")]
        public IHttpActionResult GetTour(int id)
        {
            var tour = toursService.GetTour(id);
            return Ok(tour);
        }

        [HttpGet]
        public IHttpActionResult GetTours()
        {
            var tours = toursService.GetTours();
            return Ok(tours);
        }

        [HttpGet]
        [Route("{id}/variants")]
        public IHttpActionResult GetTourVariants(int id)
        {
            var tourVariants = tourVariantService.GetByTour(id);
            return Ok(tourVariants);
        }

        [HttpPost]
        [NullParameterFilter("request")]
        public IHttpActionResult AddTour(TourPostRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var tour = toursService.AddTour(request);
            return Created(Url.Link("GetTour", new {id = tour.Id}), tour);
        }

        [HttpPut]
        [NullParameterFilter("request")]
        public IHttpActionResult UpdateTour(TourUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            toursService.UpdateTour(request);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteTour(int id)
        {
            toursService.DeleteTour(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
