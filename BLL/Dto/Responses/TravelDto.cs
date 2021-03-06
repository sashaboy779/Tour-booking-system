﻿using System;
using DAL.Entity;

namespace BLL.Dto.Responses
{
    public class TravelDto
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
