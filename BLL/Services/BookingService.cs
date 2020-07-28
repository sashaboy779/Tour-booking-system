using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using BLL.Dto.TourBooking;
using BLL.Services.Interface;
using DAL.Identity;
using DAL.Repository.Interface;
using Microsoft.AspNet.Identity;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public BookingService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public void BookTour(Booking booking)
        {
            var tourist = userManager.FindById(booking.UserId);
            if (tourist == null)
                throw new KeyNotFoundException($"User with id {booking.UserId} not found");
            var tourVariant = unitOfWork.TourVariants.Get(booking.TourVariantId);
            if (tourVariant == null)
                throw new KeyNotFoundException($"Tour variant with id {booking.UserId} not found");

            tourVariant.Tourists.Add(tourist);
            tourVariant.TouristsNumber++;
            unitOfWork.Save();
        }

        public void CancelTourBooking(Booking booking)
        {
            var tourist = userManager.FindById(booking.UserId);
            if (tourist == null)
                throw new KeyNotFoundException($"User with id {booking.UserId} not found");
            var tourVariant = unitOfWork.TourVariants.Get(booking.TourVariantId);
            if (tourVariant == null)
                throw new KeyNotFoundException($"Tour variant with id {booking.UserId} not found");

            try
            {
                if (!tourVariant.Tourists.Remove(tourist))
                    throw new InvalidOperationException("This booking does not exist");
                tourVariant.TouristsNumber--;
                unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException(
                    $"Cant revert booking of tour variant with id {tourVariant.Id} from user with id {tourist.Id}");
            }
        }
    }
}
