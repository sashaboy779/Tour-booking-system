using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using DAL.Entity;

namespace BLL.MapperProfiles
{
    public class RequestToDomain:Profile
    {
        public RequestToDomain()
        {
            CreateMap<ResortPostRequest, Resort>();
            CreateMap<ResortUpdateRequest, Resort>();
            CreateMap<TourPostRequest, Tour>();
            CreateMap<TourUpdateRequest, Tour>();
            CreateMap<TourVariantPostRequest, TourVariant>();
            CreateMap<TourVariantUpdateRequest, TourVariant>();
            CreateMap<TravelPostRequest, Travel>();
            CreateMap<TravelUpdateRequest, Travel>();
        }
    }
}
