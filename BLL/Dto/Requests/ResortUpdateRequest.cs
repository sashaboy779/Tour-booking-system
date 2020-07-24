using System.ComponentModel.DataAnnotations;

namespace BLL.Dto.Requests
{
    public class ResortUpdateRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
    }
}
