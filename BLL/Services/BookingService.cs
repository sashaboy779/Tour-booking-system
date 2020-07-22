using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using BLL.Dto.TourBooking;
using BLL.Services.Interface;
using DAL.Identity;
using DAL.Interface;
using Microsoft.AspNet.Identity;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public void BookTour(Booking booking)
        {
            var tourist = _userManager.FindById(booking.UserId);
            if (tourist == null)
                throw new KeyNotFoundException($"User with id {booking.UserId} not found");
            var tourVariant = _unitOfWork.TourVariants.Get(booking.TourVariantId);
            if (tourVariant == null)
                throw new KeyNotFoundException($"Tour variant with id {booking.UserId} not found");

            tourVariant.Tourists.Add(tourist);
            tourVariant.TouristsNumber++;
            _unitOfWork.Save();
        }

        public void CancelTourBooking(Booking booking)
        {
            var tourist = _userManager.FindById(booking.UserId);
            if (tourist == null)
                throw new KeyNotFoundException($"User with id {booking.UserId} not found");
            var tourVariant = _unitOfWork.TourVariants.Get(booking.TourVariantId);
            if (tourVariant == null)
                throw new KeyNotFoundException($"Tour variant with id {booking.UserId} not found");

            try
            {
                if (!tourVariant.Tourists.Remove(tourist))
                    throw new InvalidOperationException("This booking does not exist");
                tourVariant.TouristsNumber--;
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException(
                    $"Cant revert booking of tour variant with id {tourVariant.Id} from user with id{tourist.Id}");
            }
        }
    }
}
