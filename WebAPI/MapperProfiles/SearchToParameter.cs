using AutoMapper;
using BLL.Dto.QueryParameters;
using WebAPI.Models.SearchModels;

namespace WebAPI.MapperProfiles
{
    public class SearchToParameter : Profile
    {
        public SearchToParameter()
        {
            CreateMap<ResortSearchModel, ResortParameters>();
            CreateMap<TourSearchModel, TourParameters>();
            CreateMap<TourVariantSearchModel, TourVariantParameters>();
        }
    }
}