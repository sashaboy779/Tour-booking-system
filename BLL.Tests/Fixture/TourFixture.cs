using BLL.Dto.Requests;
using BLL.Dto.Responses;
using DAL.Entity;
using TourType = BLL.Dto.Enums.TourType;

namespace BLL.Tests.Fixture
{
    public class TourFixture
    {
        public Tour Tour { get; set; }
        public TourDto TourDto { get; set; }
        public TourPostRequest TourPostRequest { get; set; }
        public TourUpdateRequest TourUpdateRequest { get; set; }
        public Tour NullTour { get; set; }

        public TourFixture()
        {
            Tour = new Tour()
            {
                Id = 1,
                Name = "Test Tour",
                ResortId = 5,
                Description = "Bla bla bla",
                Type = DAL.Entity.TourType.Hot
            };

            TourDto = new TourDto()
            {
                Id = 1,
                Name = "Test Tour",
                ResortId = 5,
                Description = "Bla bla bla",
                Type = TourType.Hot
            };

            TourPostRequest = new TourPostRequest()
            {
                ResortId = 5,
                Description = "Bla bla bla",
                Name = "Test Tour",
                Type = TourType.Hot
            };
            
            TourUpdateRequest = new TourUpdateRequest()
            {
                ResortId = 5,
                Description = "Bla bla bla",
                Name = "Test Tour",
                Type = DAL.Entity.TourType.Hot
            };
        }
    }
}