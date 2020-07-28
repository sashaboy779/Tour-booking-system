using System.ComponentModel.DataAnnotations;
using BLL.Dto.Enums;

namespace BLL.Dto.Requests
{
    public class TourPostRequest
    {
        [Required]
        public int ResortId { get; set; }   
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public TourType Type { get; set; } 
    }
}
