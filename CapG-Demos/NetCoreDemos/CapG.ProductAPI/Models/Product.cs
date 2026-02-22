using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapG.ProductAPI.Models
{
    public class Product : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price should be greater than 0")]
        public double Price { get; set; }
        public DateTime MfgDate { get; set; }
        public Category Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //invalid scenario
            if (MfgDate > DateTime.Today)
            {
                yield return new ValidationResult($"{nameof(MfgDate)} is invalid.", new string[] {nameof(MfgDate)});
            }
        }
    }
}
