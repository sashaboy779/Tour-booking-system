using System.Collections.Generic;
using BLL.Dto.QueryParameters;
using BLL.Dto.Responses;
using DAL.Entity;

namespace BLL.Tests
{
    public class SearchFixture
    {
        public readonly Tour Tour;
        public readonly TourDto TourDto;
        public readonly Resort Resort;
        public readonly ResortDto ResortDto;
        public readonly ResortParameters ResortParameters;
        public readonly TourParameters TourParameters;

        public readonly List<Tour> Tours;
        public readonly List<Resort> Resorts;
        public readonly List<TourDto> ToursDto;
        public readonly List<ResortDto> ResortsDto;

        public readonly TourType TourType;

        public SearchFixture()
        {
            Tour = new Tour {Id = 1, Name = "Test Tour"};
            TourDto = new TourDto {Id = 1, Name = "Test Tour"};
            Resort = new Resort {Id = 1, Name = "Test Resort"};
            ResortDto = new ResortDto {Id = 1, Name = "Test Resort"};

            ResortParameters = new ResortParameters();
            TourParameters = new TourParameters {TourType = Dto.Enums.TourType.Hot};
            TourType = TourType.Hot;

            Resorts = new List<Resort>
            {
                new Resort {Id = 1, Name = "First"},
                new Resort {Id = 2, Name = "Second"},
                new Resort {Id = 3, Name = "Third"}
            };

            ResortsDto = new List<ResortDto>
            {
                new ResortDto {Id = 1, Name = "First"},
                new ResortDto {Id = 2, Name = "Second"},
                new ResortDto {Id = 3, Name = "Third"}
            };

            Tours = new List<Tour>
            {
                new Tour {Id = 1, Name = "First"},
                new Tour {Id = 2, Name = "Second"},
                new Tour {Id = 3, Name = "Third"}
            };

            ToursDto = new List<TourDto>
            {
                new TourDto {Id = 1, Name = "First"},
                new TourDto {Id = 2, Name = "Second"},
                new TourDto {Id = 3, Name = "Third"}
            };
        }
    }
}