using DAL.Entity;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<TourVariant> Tours { get; set; }
    }
}
