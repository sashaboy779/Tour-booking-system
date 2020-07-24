using System.Collections.Generic;

namespace DAL.Entity
{
    public class Resort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual List<Tour> Tours { get; set; }
    }
}
