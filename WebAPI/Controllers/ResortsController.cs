using System.Net;
using System.Web.Http;
using BLL.Dto.Requests;
using BLL.Services.Interface;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [KeyNotFoundExceptionFilter]
    [RoutePrefix("api/resorts")]
    [Authorize(Roles = "Admin, Moderator")]
    public class ResortsController : ApiController
    {
        private readonly IResortService _resortService;
        private readonly IToursService _toursService;

        public ResortsController(IResortService resortService, IToursService toursService)
        {
            _resortService = resortService;
            _toursService = toursService;
        }

        [Route("{id}", Name = "GetResort")]
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var resort = _resortService.AddResort(request);
            return Created(Url.Link("GetResort", new{id = resort.Id}),resort);
        }

        [HttpPut]
        [NullParameterFilter("request")]
        public IHttpActionResult UpdateResort(ResortUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _resortService.UpdateResort(request);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _resortService.DeleteResort(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
