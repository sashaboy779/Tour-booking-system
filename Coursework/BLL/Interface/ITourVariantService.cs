using System.Collections.Generic;
using BLL.Dto.Requests;
using BLL.Dto.Responses;

namespace BLL.Interface
{
    public interface ITourVariantService
    {
        TourVariantDto AddTourVariant(TourVariantPostRequest request);
        TourVariantDto GetTour(int id);
        IEnumerable<TourVariantDto> GetTourVariants();
        void UpdateTourVariant(TourVariantUpdateRequest request);
        void DeleteTourVariant(int id);
    }
}