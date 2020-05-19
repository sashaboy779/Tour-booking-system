using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dto.Enums;

namespace BLL.Dto.Responses
{
    public class TourDto
    {
        public int Id { get; set; }
        public int ResortId { get; set; }   
        public string Name { get; set; }
        public string Description { get; set; }
        public TourType Type { get; set; }
        public double Rating { get; set; }
    }
}
