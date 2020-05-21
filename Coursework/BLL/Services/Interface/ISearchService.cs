using System.Collections.Generic;
using BLL.Dto.QueryParameters;
using BLL.Dto.Responses;

namespace BLL.Services.Interface
{
    public interface ISearchService
    {
        ResortDto GetResortById(int id);
        List<ResortDto> GetResorts(ResortParameters parameters);
        List<TourDto> GetTours(TourParameters parameter);
        TourDto GetTourById(int id);
        List<TourDto> GetToursByRatingMore(double rating);
        List<TourVariantDto> GetTourVariants(TourVariantParameters parameters);
    }
}
