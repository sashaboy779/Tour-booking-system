using BLL.Dto.Requests;
using BLL.Dto.Responses;
using Moq;
using DAL.Entity;

namespace BLL.Tests.Fixture
{
    public class ResortFixture
    {
        public Resort Resort { get; set; }
        public ResortDto ResortDto { get; set; }
        public ResortPostRequest ResortPostRequest { get; set; }
        public ResortUpdateRequest ResortUpdateRequest { get; set; }
        public Resort NullResort { get; set; }

        public ResortFixture()
        {
            ResortPostRequest = new ResortPostRequest
            {
                Name = "New Resort",
                City = "Rivne",
                Country = "Ukraine"
            };

            Resort = new Resort
            {
                Id = 1,
                Name = "New Resort",
                City = "Rivne",
                Country = "Ukraine"
            };
            
            ResortDto = new ResortDto
            {
                Id = 1,
                Name = "New Resort",
                City = "Rivne",
                Country = "Ukraine"
            };
            
            ResortUpdateRequest = new ResortUpdateRequest
            {
                Id = 1,
                Name = "New Resort",
                City = "Rivne",
                Country = "Ukraine"
            };
        }
    }
}