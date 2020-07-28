using System.Net;
using System.Web.Http;
using BLL.Dto.Requests;
using BLL.Services.Interface;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [KeyNotFoundExceptionFilter]
    [RoutePrefix("api/tourVariants")]
    [Authorize(Roles = "Admin, Manager")]
    public class TourVariantsController : ApiController
    {
        private readonly ITourVariantService tourVariantService;

        public TourVariantsController(ITourVariantService tourVariantService)
        {
            this.tourVariantService = tourVariantService;
        }

        [HttpGet]
        [Route("{id}", Name = "GetTourVariant")]
        public IHttpActionResult GetTourVariant(int id)
        {
            var tourVariant = tourVariantService.GetTourVariant(id);
            return Ok(tourVariant);             
        }

        [HttpGet]
        public IHttpActionResult GetTourVariants()
        {
            var tourVariants = tourVariantService.GetTourVariants();
            return Ok(tourVariants);
        }

        [HttpGet]
        [Route("{id}/tourists")]
        public IHttpActionResult GetTourists(int id)
        {
            var tourists = tourVariantService.GetTourists(id);
            return Ok(tourists);
        }

        [HttpGet]
        [Route("byTourist/{touristId}")]
        public IHttpActionResult GetByTourist(string touristId)
        {
            var tourVariants = tourVariantService.GetByTourist(touristId);
            return Ok(tourVariants);
        }

        [HttpPost]
        [NullParameterFilter("request")]
        [InvalidOperationExceptionFilter]
        public IHttpActionResult AddTourVariant(TourVariantPostRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var tourVariant = tourVariantService.AddTourVariant(request);
            return Created(Url.Link("GetTourVariant", new { id = tourVariant.Id}), tourVariant);
        }

        [HttpPut]
        [NullParameterFilter("request")]
        [InvalidOperationExceptionFilter]
        public IHttpActionResult UpdateTourVariant(TourVariantUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            tourVariantService.UpdateTourVariant(request);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteTourVariant(int id)
        {
            tourVariantService.DeleteTourVariant(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
