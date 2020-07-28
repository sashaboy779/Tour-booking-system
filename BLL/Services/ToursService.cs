using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using BLL.Services.Interface;
using DAL.Entity;
using DAL.Repository.Interface;

namespace BLL.Services
{
    public class ToursService : IToursService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ToursService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public TourDto AddTour(TourPostRequest request)
        {
            var tour = mapper.Map<Tour>(request);
            try
            {
                unitOfWork.Tours.Create(tour);
                unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                throw new KeyNotFoundException($"Resort with id:{request.ResortId} not found");
            }

            return mapper.Map<TourDto>(tour);
        }

        public TourDto GetTour(int id)
        {
            var tour = unitOfWork.Tours.Get(id);
            if (tour == null)
                throw new KeyNotFoundException($"Tour with key:{id} not found");
            return mapper.Map<TourDto>(tour);
        }

        public IEnumerable<TourDto> GetTours()
        {
            var tours = unitOfWork.Tours.GetAll();
            return mapper.Map<IEnumerable<TourDto>>(tours);
        }

        public void UpdateTour(TourUpdateRequest request)
        {
            var tour = mapper.Map<Tour>(request);
            try
            {
                unitOfWork.Tours.Update(tour);
                unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (tour == null)
                    throw new KeyNotFoundException($"Tour with key:{request.Id} not found");
            }
        }

        public void DeleteTour(int id)
        {
            var tour = unitOfWork.Tours.Get(id);
            if (tour == null)
                throw new KeyNotFoundException($"Tour with key:{id} not found");
            unitOfWork.Tours.Delete(tour);
            unitOfWork.Save();
        }

        public IEnumerable<TourDto> GetByResort(int resortId)
        {
            var tours = unitOfWork.Resorts.Get(resortId).Tours;
            return mapper.Map<IEnumerable<TourDto>>(tours);
        }
    }
}