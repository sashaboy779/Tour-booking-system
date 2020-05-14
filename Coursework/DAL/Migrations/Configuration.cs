namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Entity;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.TourContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TourContext context)
        {
            var tv1 = new TourVariant()
            {
                Food = Food.AI,
                PersonPrice = 2000,
                RoomType = RoomType.Duplex,
                TicketsNumber = 6,
                TouristsNumber = 2,
                Travel = new Travel()
                {
                    Arrival = new DateTime(2020, 5, 25),
                    Departure = new DateTime(2020, 6, 1),
                    ArrivalCity = "Kyiv",
                    DepartureCity = "Rivne",
                    IsIncluded = true,
                    TransportType = TransportType.Car
                }
            };

            var tv2 = new TourVariant()
            {
                Food = Food.AI,
                PersonPrice = 2000,
                RoomType = RoomType.Duplex,
                TicketsNumber = 6,
                TouristsNumber = 2,
                Travel = new Travel()
                {
                    Arrival = new DateTime(2020, 6, 2),
                    Departure = new DateTime(2020, 6, 15),
                    ArrivalCity = "Kyiv",
                    DepartureCity = "Rivne",
                    IsIncluded = true,
                    TransportType = TransportType.Car
                }
            };

            var tv3 = new TourVariant()
            {
                Food = Food.AI,
                PersonPrice = 4000,
                RoomType = RoomType.DeLuxe,
                TicketsNumber = 6,
                TouristsNumber = 2,
                Travel = new Travel()
                {
                    Arrival = new DateTime(2020, 6, 2),
                    Departure = new DateTime(2020, 6, 15),
                    ArrivalCity = "Kyiv",
                    DepartureCity = "Rivne",
                    IsIncluded = true,
                    TransportType = TransportType.Plane
                }
            };

            var tour = new Tour()
            {
                Name = "Visit to the capital",
                Description = "Bla",
                Rating = 4.3,
                TourVariants = new List<TourVariant> { tv1, tv2, tv3 },
                Type = TourType.Hot
            };

            var resort = new Resort()
            {
                City = "Kyiv",
                Country = "Ukraine",
                Name = "New Resort",
                Tours = new List<Tour> { tour }
            };

            var resort2 = new Resort()
            {
                City = "London",
                Country = "UK",
                Name = "GoGo"
            };

            context.Resorts.AddOrUpdate(resort, resort2);
        }
    }
}
