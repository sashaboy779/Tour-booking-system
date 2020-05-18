using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using BLL.Interface;
using DAL.Entity;
using DAL.Interface;

namespace BLL.Services
{
    internal class TourVariantsService : ITourVariantService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TourVariantsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TourVariantDto AddTourVariant(TourVariantPostRequest request)
        {
            var tourVariant = _mapper.Map<TourVariant>(request);
            _unitOfWork.TourVariants.Create(tourVariant);
            _unitOfWork.Save();
            return _mapper.Map<TourVariantDto>(request);
        }

        public TourVariantDto GetTour(int id)
        {
            var tourVariant = _unitOfWork.TourVariants.Get(id);
            if (tourVariant == null)
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
            var tourVariant = _mapper.Map<TourVariant>(request);
            try
            {
                _unitOfWork.TourVariants.Update(tourVariant);
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (tourVariant == null)
                    throw new KeyNotFoundException($"TourVariant with key:{request.Id} not found");
            }
        }

        public void DeleteTourVariant(int id)
        {
            var tourVariant = _unitOfWork.TourVariants.Get(id);
            if (tourVariant == null)
                throw new KeyNotFoundException($"TourVariant with key:{id} not found");
            _unitOfWork.TourVariants.Delete(tourVariant);
            _unitOfWork.Save();
        }
    }
}