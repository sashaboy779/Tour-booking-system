using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using BLL.Infrastructure.DTO;
using BLL.Interface;
using DAL.Entity;
using DAL.Identity;
using DAL.Interface;
using Microsoft.AspNet.Identity;

namespace BLL.Services
{
    public class TourVariantsService : ITourVariantService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationUserManager _userManager;

        public TourVariantsService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public TourVariantDto AddTourVariant(TourVariantPostRequest request)
        {
            var tourVariant = _mapper.Map<TourVariant>(request);
            if(request.Travel == null)
                throw new InvalidOperationException("Travel cannot be null");
            try
            {
                _unitOfWork.TourVariants.Create(tourVariant);
                _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                throw new KeyNotFoundException($"Tour with key:{request.TourId} not found");
            }

            return _mapper.Map<TourVariantDto>(tourVariant);
        }

        public TourVariantDto GetTourVariant(int id)
        {
            var tourVariant = _unitOfWork.TourVariants.Get(id);
            if(tourVariant == null)
                throw new KeyNotFoundException($"TourVariant with key:{id} not found");
            return _mapper.Map<TourVariantDto>(tourVariant);
        }

        public IEnumerable<TourVariantDto> GetTourVariants()
        {
            var tourVariants = _unitOfWork.TourVariants.GetAll();
            return _mapper.Map<IEnumerable<TourVariantDto>>(tourVariants);
        }

        public void UpdateTourVariant(TourVariantUpdateRequest request)
        {
            if(request.Travel == null)
                throw new InvalidOperationException("Travel cannot be null");
            var tourVariant = _mapper.Map<TourVariant>(request);
            try
            {
                _unitOfWork.TourVariants.Update(tourVariant);
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new KeyNotFoundException($"TourVariant with key:{request.Id} not found");
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Id:{request.Travel.Id} of Travel does not match id:{request.Id} of TourVariant");
            }

        }

        public void DeleteTourVariant(int id)
        {
            var tourVariant = _unitOfWork.TourVariants.Get(id);
            if(tourVariant == null)
                throw new KeyNotFoundException($"TourVariant with key:{id} not found");
            _unitOfWork.TourVariants.Delete(tourVariant);
            _unitOfWork.Save();
        }

        public IEnumerable<TourVariantDto> GetByTour(int tourId)
        {
            var tourVariants = _unitOfWork.TourVariants.Find(t => t.TourId == tourId);
            return _mapper.Map<IEnumerable<TourVariantDto>>(tourVariants);
        }

        public IEnumerable<TourVariantDto> GetByTourist(string userId)
        {
            var tourist = _userManager.FindById(userId);
            if(tourist == null)
                throw new KeyNotFoundException($"Cannot find user with given id: {userId}");
            var tourVariants = tourist.Tours;
            return _mapper.Map<IEnumerable<TourVariantDto>>(tourVariants);
        }

        public IEnumerable<ApplicationUserDto> GetTourists(int id)
        {
            var tourVariant = _unitOfWork.TourVariants.Get(id);
            if(tourVariant == null)
                throw new KeyNotFoundException($"TourVariant with key:{id} not found");
            var tourists = tourVariant.Tourists;
            return _mapper.Map<IEnumerable<ApplicationUserDto>>(tourists);
        }
    }
}
