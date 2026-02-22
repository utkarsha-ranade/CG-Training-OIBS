using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CapG.EMS.Models
{
    public partial class Employees : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Salary should be greater than 0")]
        public decimal Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int DeptId { get; set; }
        [RegularExpression(@"^\d{10}$")]
        public long MobileNo { get; set; }
        public int Gender { get; set; }

        public virtual Departments Dept { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfJoining > DateTime.Today)
            {
                yield return new ValidationResult($"{nameof(DateOfJoining)} is invalid.", new string[] { nameof(DateOfJoining) });
            }
        }
    }
}
