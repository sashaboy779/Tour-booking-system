using AutoMapper;
using BLL.Dto.Responses;
using DAL.Entity;

namespace BLL.MapperProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Resort, ResortDto>();
            CreateMap<Tour, TourDto>();
            CreateMap<TourVariant, TourDto>();
            CreateMap<Travel, TravelDto>();
        }
    }
}