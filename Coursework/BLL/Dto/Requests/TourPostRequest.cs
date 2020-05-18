using BLL.Dto.Enums;

namespace BLL.Dto.Requests
{
    public class TourPostRequest
    {
        public int ResortId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TourType Type { get; set; }
    }
}