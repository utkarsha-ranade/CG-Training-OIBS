using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Capgemini.OIBS.Models
{
    public class Nominee : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Relation Relation { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public gender Gender { get; set; }
        public int AccountId { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
        [JsonIgnore]
        public Int64 AccountNo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth > DateTime.Today.AddYears(-10))
            {
                yield return new ValidationResult("DateOfBirth is invalid. Age should be minimum 10 years.");
            }
        }
    }
}
