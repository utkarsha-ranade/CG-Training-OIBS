using System;
using System.ComponentModel.DataAnnotations;

namespace CapG.OMS.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^\d{10}$")]
        public long MobileNo { get; set; }
        public Gender Gender { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
