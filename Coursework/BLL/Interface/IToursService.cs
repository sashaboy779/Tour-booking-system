using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dto.Requests;
using BLL.Dto.Responses;

namespace BLL.Interface
{
    public interface IToursService
    {
        TourDto AddTour(TourPostRequest request);
        TourDto GetTour(int id);
        IEnumerable<TourDto> GetTours();
        TourDto UpdateTour(TourUpdateRequest request);
        TourDto DeleteTour(int id);
    }
}
