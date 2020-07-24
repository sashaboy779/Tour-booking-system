using System.ComponentModel.DataAnnotations;

namespace BLL.Dto.Requests
{
    public class ResortPostRequest
    {
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
