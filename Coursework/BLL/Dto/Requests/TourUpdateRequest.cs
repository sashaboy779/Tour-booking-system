using DAL.Entity;

namespace BLL.Dto.Requests
{
    public class TourUpdateRequest
    {
        public int ResortId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TourType Type { get; set; }
    }
}