using System;
using DAL.Entity;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using Food = BLL.Dto.Enums.Food;
using RoomType = BLL.Dto.Enums.RoomType;

namespace BLL.Tests.Fixture
{
    public class TourVariantsFixture
    {
        public TourVariant TourVariant { get; set; }
        public TourVariantDto TourVariantDto { get; set; }
        public TourVariantPostRequest TourVariantPostRequest { get; set; }
        public TourVariantUpdateRequest TourVariantUpdateRequest { get; set; }
        public TourVariant NullTourVariant { get; set; }

        public TourVariantsFixture()
        {
            TourVariant = new TourVariant
            {
                TourId = 1,
                PersonPrice = 100,
                TicketsNumber = 8,
                RoomType = DAL.Entity.RoomType.Duplex,
                Food = DAL.Entity.Food.BB,
                Travel = null
            };

            TourVariantDto = new TourVariantDto
            {
                TourId = 1,
                PersonPrice = 100,
                TicketsNumber = 8,
                RoomType = DAL.Entity.RoomType.Duplex,
                Food = DAL.Entity.Food.BB,
                Travel = null
            };

            TourVariantPostRequest = new TourVariantPostRequest
            {
                TourId = 1,
                PersonPrice = 100,
                TicketsNumber = 8,
                RoomType = RoomType.Duplex,
                Food = Food.BB,
                Travel = null
            };
            
            TourVariantUpdateRequest = new TourVariantUpdateRequest
            {
                TourId = 1,
                PersonPrice = 100,
                TicketsNumber = 8,
                RoomType = RoomType.Duplex,
                Food = Food.BB,
                Travel = new TravelUpdateRequest
                {
                    Id = 4,
                    IsIncluded = true,
                    Departure = new DateTime(2020, 08, 06),
                    Arrival = new DateTime(2020, 08, 10)
                }
            };
        }
    }
}