using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapG.OMS.Models
{
    public class Product: IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(1, double.MaxValue)]
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(CreatedDate > DateTime.Today)
            {
                yield return new ValidationResult($"{nameof(CreatedDate)} is invalid.", new string[] { nameof(CreatedDate) });
            }
        }
    }
}
