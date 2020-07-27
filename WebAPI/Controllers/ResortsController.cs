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
        private readonly IResortService resortService;
        private readonly IToursService toursService;

        public ResortsController(IResortService resortService, IToursService toursService)
        {
            this.resortService = resortService;
            this.toursService = toursService;
        }

        [HttpGet]
        [Route("{id}", Name = "GetResort")]
        public IHttpActionResult GetResort(int id)
        {
            var resort = resortService.GetResort(id);
            return Ok(resort);
        }

        [HttpGet]
        public IHttpActionResult GetAllResorts()
        {
            var resorts = resortService.GetResorts();
            return Ok(resorts);
        }

        [HttpGet]
        [Route("{id}/tours")]
        public IHttpActionResult GetTours(int id)
        {
            var tours = toursService.GetByResort(id);
            return Ok(tours);
        }

        [HttpPost]
        [NullParameterFilter("request")]
        public IHttpActionResult AddResort(ResortPostRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var resort = resortService.AddResort(request);
            return Created(Url.Link("GetResort", new{id = resort.Id}),resort);
        }

        [HttpPut]
        [NullParameterFilter("request")]
        public IHttpActionResult UpdateResort(ResortUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            resortService.UpdateResort(request);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            resortService.DeleteResort(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
