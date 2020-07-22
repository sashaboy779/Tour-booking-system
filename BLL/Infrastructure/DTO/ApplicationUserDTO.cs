using BLL.Dto.Responses;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace BLL.Infrastructure.DTO
{
    public class ApplicationUserDto : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<TourVariantDto> Tours { get; set; }
    }
}
