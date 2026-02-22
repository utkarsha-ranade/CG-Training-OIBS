using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Capgemini.OIBS.Models
{
    public class Account
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Int64 AccountNo { get; set; }
        [Range(5000,double.MaxValue,ErrorMessage ="Balance should be minimum 5000/-")]
        public double Balance { get; set; }
        [JsonIgnore]
        public double InterestAmount { get; set; } = 0;
        public type AccountType { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}

public enum type
{
    Savings=1,
    Fixed
}