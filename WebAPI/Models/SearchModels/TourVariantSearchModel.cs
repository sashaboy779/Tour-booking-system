using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.Dto.Enums;

namespace WebAPI.Models.SearchModels
{
    public class TourVariantSearchModel : IValidatableObject
    {
        public int TourId { get; set; }
        public int MinTourists { get; set; } 
        public int MaxTourists{ get; set; }
        public double MinPersonPrice { get; set; }
        public double MaxPersonPrice { get; set; }
        
        public bool TravelIncluded { get; set; }
        public TransportType? Transport { get; set; }   
        
        public RoomType? Room { get; set; }

        public Food? Food { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            ValidateId(result);
            ValidateTravel(result);
            ValidatePersonPrice(result);
            ValidateTouristsNumber(result);
            return result;
        }

        private void ValidateId(ICollection<ValidationResult> result)
        {
            if (TourId < 0)
            {
                result.Add(new ValidationResult("TourId cannot be negative"));
            }
        }
        
        private void ValidateTouristsNumber(ICollection<ValidationResult> result)
        {
            if ((MaxTourists != 0 || MinTourists != 0) && MaxTourists <= MinTourists &&
                (MaxTourists != 0 || MinTourists <= 0) && (MinTourists != 0 || MaxTourists <= 0))
            {
                result.Add(new ValidationResult("Tourists number is not valid"));
            }
        }
        
        private void ValidatePersonPrice(ICollection<ValidationResult> result)
        {
            if ((!(Math.Abs(MinPersonPrice) < 0.001) || !(Math.Abs(MinPersonPrice) < 0.001)) &&
                !(MaxPersonPrice > MinPersonPrice))
            {
                result.Add(new ValidationResult("Price is not valid"));
            }
        }
        
        private void ValidateTravel(ICollection<ValidationResult> result)
        {
            if (!TravelIncluded && (TravelIncluded || Transport != null))
            {
                result.Add(new ValidationResult("Travel options is not valid"));
            }
        }
    }
}