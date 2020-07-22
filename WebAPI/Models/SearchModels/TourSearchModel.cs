using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.Dto.Enums;

namespace WebAPI.Models.SearchModels
{
    public class TourSearchModel : IValidatableObject
    {
        public string TourName { get; set; } 
        public TourType? TourType { get; set; } 
        public double? Rating { get; set; } 
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            if (!Rating.HasValue) return result;
            if (Rating.Value < 0)
            {
                result.Add(new ValidationResult("Rating cannot be less than zero"));
            }

            return result;
        }
    }
}