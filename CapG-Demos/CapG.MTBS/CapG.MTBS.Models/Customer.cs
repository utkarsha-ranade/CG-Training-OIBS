using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace CapG.MTBS.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [RegularExpression(@"^\d{10}$")]
        public long MobileNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
