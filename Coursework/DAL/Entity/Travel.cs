using System;

namespace DAL.Entity
{
    public class Travel
    {
        public int Id { get; set; }
        public bool IsIncluded { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public TransportType TransportType { get; set; }
    }
}