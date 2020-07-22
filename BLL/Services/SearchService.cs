using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Dto.QueryParameters;
using BLL.Dto.Responses;
using BLL.Services.Interface;
using DAL.Entity;
using DAL.Interface;

namespace BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SearchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public TourDto GetTourById(int id)
        {
            return mapper.Map<TourDto>(unitOfWork.Tours.Get(id));
        }

        public ResortDto GetResortById(int id)
        {
            return mapper.Map<ResortDto>(unitOfWork.Resorts.Get(id));
        }

        public List<ResortDto> GetResorts(ResortParameters parameters)
        {
            var resorts = unitOfWork.Resorts.Find(x =>
                   (parameters.Name == null || x.Name.Contains(parameters.Name))
                && (parameters.City == null || x.City == parameters.City)
                && (parameters.Country == null || x.Country == parameters.Country)).ToList();
            return mapper.Map<List<ResortDto>>(resorts);
        }

        public List<TourDto> GetTours(TourParameters parameter)
        {
            var tourType = mapper.Map<TourType>(parameter.TourType);

            var tours = unitOfWork.Tours.Find(x =>
                (parameter.TourName == null || x.Name.Contains(parameter.TourName))
                && (parameter.TourType == null || x.Type == tourType)
                && (Math.Abs(parameter.Rating) < 0.000000001 || Math.Abs(parameter.Rating - x.Rating) < 0.000000001));
            return mapper.Map<List<TourDto>>(tours.ToList());
        }

        public List<TourDto> GetToursByRatingMore(double rating)
        {
            return mapper.Map<List<TourDto>>(unitOfWork.Tours.Find(x => x.Rating > rating).ToList());
        }

        public List<TourVariantDto> GetTourVariants(TourVariantParameters parameter)
        {
            var roomType = mapper.Map<RoomType>(parameter.Room);
            var foodType = mapper.Map<Food>(parameter.Food);
            var transportType = mapper.Map<TransportType>(parameter.Transport);

            var variants = unitOfWork.TourVariants.Find(x => parameter.TourId == x.TourId 
                                                             && x.TicketsNumber > 0).ToList();
            var filtered = variants.Where(x =>
                (parameter.MinTourists == parameter.MaxTourists 
                 || x.TouristsNumber >= parameter.MinTourists && x.TouristsNumber <= parameter.MaxTourists)
                && (Math.Abs(parameter.MinPersonPrice - parameter.MaxPersonPrice) < 0.0001 
                     || x.PersonPrice >= parameter.MinPersonPrice && x.PersonPrice <= parameter.MaxPersonPrice)
                && (parameter.Food == null || x.Food == foodType)
                && (parameter.Room == null || x.RoomType == roomType)
                && parameter.TravelIncluded == x.Travel.IsIncluded 
                    && (parameter.Transport == null || x.Travel.TransportType == transportType )).ToList();
            
            return mapper.Map<List<TourVariantDto>>(filtered);
        }
    }
}