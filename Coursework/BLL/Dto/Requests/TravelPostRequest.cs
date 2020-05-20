﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dto.Enums;

namespace BLL.Dto.Requests
{
    public class TravelPostRequest
    {
        public bool IsIncluded { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public TransportType TransportType { get; set; }
    }
}
