using AutoMapper;
using BLL.Infrastructure.DTO;
using DAL.Identity;

namespace DependencyResolution
{
    public class DTOProfile : Profile
    {
        public DTOProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
        }
    }
}
