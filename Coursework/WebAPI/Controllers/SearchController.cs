using System.Collections;
using System.Web.Http;
using AutoMapper;
using BLL.Dto.QueryParameters;
using BLL.Services.Interface;
using WebAPI.Filters;
using WebAPI.Models.SearchModels;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private readonly ISearchService service;
        private readonly IMapper mapper; 

        public SearchController(ISearchService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [Route("resort/{id}")]
        public IHttpActionResult FindResort(int id)
        {
            var resort = service.GetResortById(id);
            return ReturnResult(resort);
        }
        
        [HttpGet]
        [Route("resort")]
        [ValidateModelStateFilter]
        public IHttpActionResult FindResorts([FromBody]ResortSearchModel searchModel)
        {
            var resort = service.GetResorts(mapper.Map<ResortParameters>(searchModel));
            return ReturnResult(resort);
        }
        
        [HttpGet]
        [Route("tour/{id}")]
        public IHttpActionResult FindTour(int id)
        {
            var tour = service.GetTourById(id);
            return ReturnResult(tour);
        }
        
        [HttpGet]
        [Route("tour")]
        [ValidateModelStateFilter]
        public IHttpActionResult FindTours([FromBody]TourSearchModel searchModel)
        {
            var tours = service.GetTours(mapper.Map<TourParameters>(searchModel));
            return ReturnResult(tours);
        }

        [HttpGet]
        [Route("tour/rating/more")]
        public IHttpActionResult FindToursByRatingMore(double tourRating)
        {
            if (tourRating < 0 || tourRating >= 5)
            {
                return BadRequest("Variable tourRating is not correct");
            }
            
            var tours = service.GetToursByRatingMore(tourRating);
            return ReturnResult(tours);
        }

        [HttpGet]
        [Route("tourvariant")]
        [ValidateModelStateFilter]
        public IHttpActionResult FindTourVariants([FromBody]TourVariantSearchModel searchModel)
        {
            var variants = service.GetTourVariants(mapper.Map<TourVariantParameters>(searchModel));
            return ReturnResult(variants);
        }

        private IHttpActionResult ReturnResult<T>(T result)
        {
            if (result == null || result is IList list && list.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}