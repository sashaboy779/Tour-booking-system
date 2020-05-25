using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.SearchModels
{
    public class ResortSearchModel : IValidatableObject
    {
        public string Name { get; set; } 
        public string Country { get; set; } 
        public string City { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}