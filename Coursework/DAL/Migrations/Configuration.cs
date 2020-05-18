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

            if (roleManager.Roles.Count() == 0)
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
