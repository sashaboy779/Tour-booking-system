using System.ComponentModel.DataAnnotations;
using DAL.Entity;

namespace BLL.Dto.Requests
{
    public class TourUpdateRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ResortId { get; set; }   
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public TourType Type { get; set; }
    }
}
