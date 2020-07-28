using AutoMapper;
using BLL.Infrastructure.DTO;
using DAL.Identity;

namespace BLL.MapperProfiles
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
        }
    }
}
