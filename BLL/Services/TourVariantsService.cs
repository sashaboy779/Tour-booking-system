using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using BLL.Infrastructure.DTO;
using BLL.Services.Interface;
using DAL.Entity;
using DAL.Identity;
using DAL.Repository.Interface;
using Microsoft.AspNet.Identity;

namespace BLL.Services
{
    public class TourVariantsService : ITourVariantService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ApplicationUserManager userManager;

        public TourVariantsService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationUserManager userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public TourVariantDto AddTourVariant(TourVariantPostRequest request)
        {
            var tourVariant = mapper.Map<TourVariant>(request);
            try
            {
                unitOfWork.TourVariants.Create(tourVariant);
                unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                throw new KeyNotFoundException($"Tour with key:{request.TourId} not found");
            }

            return mapper.Map<TourVariantDto>(tourVariant);
        }

        public TourVariantDto GetTourVariant(int id)
        {
            var tourVariant = unitOfWork.TourVariants.Get(id);
            if(tourVariant == null)
                throw new KeyNotFoundException($"TourVariant with key:{id} not found");
            return mapper.Map<TourVariantDto>(tourVariant);
        }

        public IEnumerable<TourVariantDto> GetTourVariants()
        {
            var tourVariants = unitOfWork.TourVariants.GetAll();
            return mapper.Map<IEnumerable<TourVariantDto>>(tourVariants);
        }

        public void UpdateTourVariant(TourVariantUpdateRequest request)
        {
            var tourVariant = mapper.Map<TourVariant>(request);
            try
            {
                unitOfWork.TourVariants.Update(tourVariant);
                unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new KeyNotFoundException($"TourVariant with key:{request.Id} not found");
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Id:{request.Travel.Id} of Travel does not" +
                                                    $" match id:{request.Id} of TourVariant");
            }

        }

        public void DeleteTourVariant(int id)
        {
            var tourVariant = unitOfWork.TourVariants.Get(id);
            if(tourVariant == null)
                throw new KeyNotFoundException($"TourVariant with key:{id} not found");
            unitOfWork.TourVariants.Delete(tourVariant);
            unitOfWork.Save();
        }

        public IEnumerable<TourVariantDto> GetByTour(int tourId)
        {
            var tourVariants = unitOfWork.TourVariants.Find(t => t.TourId == tourId);
            return mapper.Map<IEnumerable<TourVariantDto>>(tourVariants);
        }

        public IEnumerable<TourVariantDto> GetByTourist(string userId)
        {
            var tourist = userManager.FindById(userId);
            if(tourist == null)
                throw new KeyNotFoundException($"Cannot find user with given id: {userId}");
            var tourVariants = tourist.Tours;
            return mapper.Map<IEnumerable<TourVariantDto>>(tourVariants);
        }

        public IEnumerable<ApplicationUserDto> GetTourists(int id)
        {
            var tourVariant = unitOfWork.TourVariants.Get(id);
            if(tourVariant == null)
                throw new KeyNotFoundException($"TourVariant with key:{id} not found");
            var tourists = tourVariant.Tourists;
            return mapper.Map<IEnumerable<ApplicationUserDto>>(tourists);
        }
    }
}
