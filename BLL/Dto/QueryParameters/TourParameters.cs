using BLL.Dto.Enums;

namespace BLL.Dto.QueryParameters
{
    public class TourParameters 
    {
        public string TourName { get; set; } 
        public TourType? TourType { get; set; } 
        public double Rating { get; set; } 
    }
}