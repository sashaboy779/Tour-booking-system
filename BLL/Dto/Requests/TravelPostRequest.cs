using System;
using System.ComponentModel.DataAnnotations;
using BLL.Dto.Enums;

namespace BLL.Dto.Requests
{
    public class TravelPostRequest
    {
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
