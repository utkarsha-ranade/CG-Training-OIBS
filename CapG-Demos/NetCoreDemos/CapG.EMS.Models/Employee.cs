using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapG.EMS.Models
{
    public class Employee : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public DateTime DateofJoining { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Salary should be greater than 0")]
        public double Salary { get; set; }
        public int DeptId { get; set; }
        [RegularExpression(@"^\d{10}$")]
        public long MobileNo { get; set; }
        public Gender Gender { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //invalid scenario
            if (DateofJoining > DateTime.Today)
            {
                yield return new ValidationResult($"{nameof(DateofJoining)} is invalid.", new string[] { nameof(DateofJoining) });
            }
        }
    }
}
