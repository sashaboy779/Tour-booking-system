using System.Web.Http;
using BLL.Dto.Requests;
using BLL.Interface;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [KeyNotFoundExceptionFilter]
    public class ResortsController : ApiController
    {
        private readonly IResortService _resortService;
        private readonly IToursService _toursService;

        public ResortsController(IResortService resortService, IToursService toursService)
        {
            _resortService = resortService;
            _toursService = toursService;
        }

        [HttpGet]
        public IHttpActionResult GetResort(int id)
        {
            var resort = _resortService.GetResort(id);
            return Ok(resort);
        }

        [HttpGet]
        public IHttpActionResult GetAllResorts()
        {
            var resorts = _resortService.GetResorts();
            return Ok(resorts);
        }

        [Route("{id}/tours")]
        [HttpGet]
        public IHttpActionResult GetTours(int id)
        {
            var tours = _toursService.GetByResort(id);
            return Ok(tours);
        }

        [HttpPost]
        [NullParameterFilter("request")]
        public IHttpActionResult AddResort(ResortPostRequest request)
        {
            var resort = _resortService.AddResort(request);
            return Created(Url.Link("GetResort", new{id = resort.Id}),resort);
        }

        [HttpPut]
        [NullParameterFilter("request")]
        public void UpdateResort(ResortUpdateRequest request)
        {
            _resortService.UpdateResort(request);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _resortService.DeleteResort(id);
        }

    }
}
