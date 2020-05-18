using System.Collections.Generic;
using BLL.Dto.Requests;
using BLL.Dto.Responses;

namespace BLL.Interface
{
    public interface IToursService
    {
        TourDto AddTour(TourPostRequest request);
        TourDto GetTour(int id);
        IEnumerable<TourDto> GetTours();
        void UpdateTour(TourUpdateRequest request);
        void DeleteTour(int id);
    }
}