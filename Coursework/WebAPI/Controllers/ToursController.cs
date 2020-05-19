using System.Web.Http;
using BLL.Dto.Requests;
using BLL.Interface;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [KeyNotFoundExceptionFilter]
    public class ToursController : ApiController
    {
        private readonly IToursService _toursService;

        public ToursController(IToursService toursService)
        {
            _toursService = toursService;
        }

        [Route("{id}", Name = "GetTour")]
        [HttpGet]
        public IHttpActionResult GetTour(int id)
        {
            var tour = _toursService.GetTour(id);
            return Ok(tour);
        }

        [HttpGet]
        public IHttpActionResult GetTours(int id)
        {
            var tours = _toursService.GetTours();
            return Ok(tours);
        }

        [HttpPost]
        public IHttpActionResult AddTour(TourPostRequest request)
        {
            var tour = _toursService.AddTour(request);
            return Created(Url.Link("GetTour", new {id = tour.Id}), tour);
        }

        [HttpPut]
        public void UpdateTour(TourUpdateRequest request)
        {
            _toursService.UpdateTour(request);
        }

        [HttpDelete]
        public void DeleteTour(int id)
        {
            _toursService.DeleteTour(id);
        }
    }
}
