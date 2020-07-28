using System;
using System.ComponentModel.DataAnnotations;
using DAL.Entity;

namespace BLL.Dto.Requests
{
    public class TravelUpdateRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsIncluded { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        [Required]
        public DateTime Arrival { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public TransportType TransportType { get; set; }
    }
}
