using BLL.DTO;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace BLL.Infrastructure.DTO
{
    public class ApplicationUserDTO : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<TourVariantDTO> Tours { get; set; }
    }
}
