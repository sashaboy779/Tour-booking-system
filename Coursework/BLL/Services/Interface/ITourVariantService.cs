using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using BLL.Infrastructure.DTO;

namespace BLL.Interface
{
    public interface ITourVariantService
    {
        TourVariantDto AddTourVariant(TourVariantPostRequest request);
        TourVariantDto GetTour(int id);
        IEnumerable<TourVariantDto> GetTourVariants();
        void UpdateTourVariant(TourVariantUpdateRequest request);
        void DeleteTourVariant(int id);
        IEnumerable<TourVariantDto> GetByTour(int tourId);
        IEnumerable<TourVariantDto> GetByTourist(string userId);
        IEnumerable<ApplicationUserDto> GetTourists(int id);
    }
}
