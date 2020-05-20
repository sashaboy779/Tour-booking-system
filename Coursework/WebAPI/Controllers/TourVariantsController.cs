using System.Web.Http;
using BLL.Dto.Requests;
using BLL.Interface;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [KeyNotFoundExceptionFilter]
    [RoutePrefix("api/tourVariants")]
    public class TourVariantsController : ApiController
    {
        private readonly ITourVariantService _tourVariantService;

        public TourVariantsController(ITourVariantService tourVariantService)
        {
            _tourVariantService = tourVariantService;
        }

        [Route("{id}", Name = "GetTourVariant")]
        [HttpGet]
        public IHttpActionResult GetTourVariant(int id)
        {
            var tourVariant = _tourVariantService.GetTourVariant(id);
            return Ok(tourVariant);             
        }

        [HttpGet]
        public IHttpActionResult GetTourVariants()
        {
            var tourVariants = _tourVariantService.GetTourVariants();
            return Ok(tourVariants);
        }

        [Route("{id}/tourists")]
        [HttpGet]
        public IHttpActionResult GetTourists(int id)
        {
            var tourists = _tourVariantService.GetTourists(id);
            return Ok(tourists);
        }

        [Route("byTourist/{touristId}")]
        [HttpGet]
        public IHttpActionResult GetByTourist(string touristId)
        {
            var tourVariants = _tourVariantService.GetByTourist(touristId);
            return Ok(tourVariants);
        }

        [HttpPost]
        [NullParameterFilter("request")]
        public IHttpActionResult AddTourVariant(TourVariantPostRequest request)
        {
            var tourVariant = _tourVariantService.AddTourVariant(request);
            return Created(Url.Link("GetTourVariant", new { id = tourVariant.Id}), tourVariant);
        }

        [HttpPut]
        [NullParameterFilter("request")]
        public void UpdateTourVariant(TourVariantUpdateRequest request)
        {
            _tourVariantService.UpdateTourVariant(request);
        }

        [Route("{id}")]
        [HttpDelete]
        public void DeleteTourVariant(int id)
        {
            _tourVariantService.DeleteTourVariant(id);
        }
    }
}
