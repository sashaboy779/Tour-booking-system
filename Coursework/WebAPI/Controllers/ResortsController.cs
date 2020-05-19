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

        public ResortsController(IResortService resortService)
        {
            _resortService = resortService;
        }

        [Route("{id}")]
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

        [HttpPost]
        public IHttpActionResult AddResort(ResortPostRequest request)
        {
            var resort = _resortService.AddResort(request);
            return Created(Url.Link("GetResort", new{id = resort.Id}),resort);
        }

        [HttpPut]
        public void UpdateResort(ResortUpdateRequest request)
        {
            _resortService.UpdateResort(request);
        }

        [Route("id")]
        [HttpDelete]
        public void Delete(int id)
        {
            _resortService.DeleteResort(id);
        }

    }
}
