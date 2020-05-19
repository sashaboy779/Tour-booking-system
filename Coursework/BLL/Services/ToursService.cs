﻿using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using BLL.Interface;
using DAL.Entity;
using DAL.Interface;

namespace BLL.Services
{
    public class ToursService : IToursService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ToursService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public TourDto AddTour(TourPostRequest request)
        {
            var tour = _mapper.Map<Tour>(request);
            _unitOfWork.Tours.Create(tour);
            _unitOfWork.Save();
            return _mapper.Map<TourDto>(tour);
        }

        public TourDto GetTour(int id)
        {
            var tour = _unitOfWork.Tours.Get(id);
            if (tour == null)
                throw new KeyNotFoundException($"Tour with key:{id} not found");
            return _mapper.Map<TourDto>(tour);
        }

        public IEnumerable<TourDto> GetTours()
        {
            var tours = _unitOfWork.Tours.GetAll();
            return _mapper.Map<IEnumerable<TourDto>>(tours);
        }

        public void UpdateTour(TourUpdateRequest request)
        {
            var tour = _mapper.Map<Tour>(request);
            try
            {
                _unitOfWork.Tours.Update(tour);
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (tour == null)
                    throw new KeyNotFoundException($"Tour with key:{request.Id} not found");
            }
        }

        public void DeleteTour(int id)
        {
            var tour = _unitOfWork.Tours.Get(id);
            if (tour == null)
                throw new KeyNotFoundException($"Tour with key:{id} not found");
            _unitOfWork.Tours.Delete(tour);
            _unitOfWork.Save();
        }

        public IEnumerable<TourDto> GetByResort(int resortId)
        {
            var tours = _unitOfWork.Resorts.Get(resortId).Tours;
            return _mapper.Map<IEnumerable<TourDto>>(tours);
        }
    }
}