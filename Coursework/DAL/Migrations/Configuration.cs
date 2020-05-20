namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Entity;
    using System.Collections.Generic;
    using DAL.EF;
    using Microsoft.AspNet.Identity;
    using DAL.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(ApplicationDbContext context)
        {
            var tv1 = new TourVariant()
            {
                Food = Food.AI,
                PersonPrice = 1000,
                RoomType = RoomType.Honeymoon,
                TicketsNumber = 10,
                TouristsNumber = 6,
            };

            var tv2 = new TourVariant()
            {
                Food = Food.AI,
                PersonPrice = 2000,
                RoomType = RoomType.Honeymoon,
                TicketsNumber = 15,
                TouristsNumber = 1,
                Travel = new Travel()
                {
                    Arrival = new DateTime(2020, 9, 10),
                    Departure = new DateTime(2020, 9, 23),
                    ArrivalCity = "Klang",
                    DepartureCity = "Essen",
                    IsIncluded = true,
                    TransportType = TransportType.Car
                }
            };

            var tv3 = new TourVariant()
            {
                Food = Food.AI,
                PersonPrice = 3000,
                RoomType = RoomType.DeLuxe,
                TicketsNumber = 6,
                TouristsNumber = 1,
                Travel = new Travel()
                {
                    Arrival = new DateTime(2020, 8, 20),
                    Departure = new DateTime(2020, 8, 28),
                    ArrivalCity = "Oshawa",
                    DepartureCity = "Karshi",
                    IsIncluded = true,
                    TransportType = TransportType.Plane
                }
            };

            var tv4 = new TourVariant()
            {
                Food = Food.BB,
                PersonPrice = 4000,
                RoomType = RoomType.Duplex,
                TicketsNumber = 0,
                TouristsNumber = 1,
            };

            var tv5 = new TourVariant()
            {
                Food = Food.BB,
                PersonPrice = 5000,
                RoomType = RoomType.DeLuxe,
                TicketsNumber = 6,
                TouristsNumber = 3,
            };

            var tv6 = new TourVariant()
            {
                Food = Food.RR,
                PersonPrice = 2000,
                RoomType = RoomType.Honeymoon,
                TicketsNumber = 20,
                TouristsNumber = 4,
                Travel = new Travel()
                {
                    Arrival = new DateTime(2020, 7, 2),
                    Departure = new DateTime(2020, 7, 15),
                    ArrivalCity = "Charlotte",
                    DepartureCity = "Envigado",
                    IsIncluded = true,
                    TransportType = TransportType.Plane
                }
            };


            var tour = new Tour()
            {
                Name = "Cool Tour",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ut laoreet tortor. " +
                                          "Aenean in magna blandit, imperdiet mi nec, placerat orci. Quisque id cursus diam, non" +
                                          " porttitor odio. Donec id placerat nibh. Suspendisse potenti. Sed cursus auctor magna " +
                                          "ut posuere. Interdum et malesuada fames ac ante ipsum primis in faucibus. Proin " +
                                          "vulputate nisi at lectus lobortis volutpat sed vitae ligula. Donec tempus augue at " +
                                          "turpis scelerisque pellentesque. Morbi non enim erat. Vestibulum vel faucibus turpis. " +
                                          "Suspendisse at dapibus lorem. Cras auctor nunc vel ligula tincidunt aliquet.",
                Rating = 4.3,
                TourVariants = new List<TourVariant> { tv1, tv2, tv3 },
                Type = TourType.Hot
            };

            var tour2 = new Tour()
            {
                Name = "Go Go Tour",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ut laoreet tortor. " +
                              "Aenean in magna blandit, imperdiet mi nec, placerat orci. Quisque id cursus diam, non" +
                              " porttitor odio. Donec id placerat nibh. Suspendisse potenti. Sed cursus auctor magna " +
                              "ut posuere. Interdum et malesuada fames ac ante ipsum primis in faucibus. Proin " +
                              "vulputate nisi at lectus lobortis volutpat sed vitae ligula. Donec tempus augue at " +
                              "turpis scelerisque pellentesque. Morbi non enim erat. Vestibulum vel faucibus turpis. " +
                              "Suspendisse at dapibus lorem. Cras auctor nunc vel ligula tincidunt aliquet.",
                Rating = 5,
                TourVariants = new List<TourVariant> { tv4, tv5, tv6 },
                Type = TourType.None
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
                Name = "GoGo",
                Tours = new List<Tour> { tour2 }
            };

            context.Resorts.Add(resort);
            context.Resorts.Add(resort2);

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext("Tour")));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext("Tour")));

            var user = new ApplicationUser()
            {
                UserName = "Adminko",
                Email = "bob.lol@mymail.com",
                EmailConfirmed = true,
                FirstName = "Bob",
                LastName = "Wins"
            };

            manager.Create(user, "Password1!");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "Manager" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByName("Adminko");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin" });
        }
    }
}
