using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Capgemini.OIBS.Models
{
    public class User : IValidatableObject
    {
        public User()
        {
            Transactions = new HashSet<Transaction>();
        }
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [JsonIgnore]
        public role Role { get; set; } = role.Customer;
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public gender Gender { get; set; }
        [RegularExpression(@"^\d{10}$")]
        public Int64 MobileNo { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [JsonIgnore]
        public bool IsVerified { get; set; } = false;
        [JsonIgnore]
        public bool IsActive { get; set; } = false;
        [JsonIgnore]
        public ICollection<Transaction> Transactions { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth > DateTime.Today.AddYears(-10))
            {
                yield return new ValidationResult("DateOfBirth is invalid. Age should be minimum 10 years.");
            }
        }
    }
}

public enum role
{
    Admin=1,
    Customer
}